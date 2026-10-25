#!/usr/bin/env python3
"""Ambiente local do Catálogo; estado privado, sem credenciais e com recursos próprios."""
import argparse
import fcntl
import json
import os
from pathlib import Path
import signal
import socket
import subprocess
import sys
import time
import urllib.error
import urllib.request

ROOT = Path(__file__).resolve().parents[2]
RUNTIME = ROOT / '.jarvis' / 'runtime'
API = ROOT / 'src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog.API'
MODULE = ROOT / 'src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog'


class LocalError(Exception):
    pass


def command(args, *, env=None, diagnostic=False):
    """Capturar saída: Compose resolvido e ferramentas podem conter dados privados."""
    result = subprocess.run(args, cwd=ROOT, env=env, text=True, capture_output=True)
    if diagnostic:
        log = RUNTIME / 'setup.log'
        with log.open('a') as output:
            log.chmod(0o600)
            output.write(result.stdout + result.stderr)
    if result.returncode:
        detail = 'consulte .jarvis/runtime/setup.log' if diagnostic else 'confira ferramentas e acesso ao Docker'
        raise LocalError(f'Falhou {args[0]} {args[1] if len(args) > 1 else ""}; {detail}.')
    return result.stdout


def compose(*args):
    return command(['docker', 'compose', *args])


def process_identity(pid):
    result = subprocess.run(['ps', '-p', str(pid), '-o', 'stat=', '-o', 'lstart=', '-o', 'args='],
                            text=True, capture_output=True)
    fields = result.stdout.strip().split(maxsplit=1)
    if not fields or fields[0].startswith('Z'):
        return None
    # Estado R/S pode mudar; início e comando identificam a mesma instância.
    return fields[1] if len(fields) == 2 else None


def stop_process(record):
    pid = record['pid']
    identity = process_identity(pid)
    if identity is None:
        return
    if identity != record['identity'] or os.getpgid(pid) != pid:
        raise LocalError(f'PID {pid} não corresponde à execução registrada; nenhum sinal enviado.')
    os.killpg(pid, signal.SIGTERM)
    until = time.monotonic() + 5
    while time.monotonic() < until and process_identity(pid) == identity:
        time.sleep(0.1)
    if process_identity(pid) == identity and os.getpgid(pid) == pid:
        os.killpg(pid, signal.SIGKILL)


def save(state):
    path = RUNTIME / 'state.json'
    temporary = path.with_suffix('.tmp')
    temporary.write_text(json.dumps(state, indent=2) + '\n')
    temporary.chmod(0o600)
    temporary.replace(path)


def load():
    path = RUNTIME / 'state.json'
    if not path.exists():
        return {'repo': str(ROOT), 'processes': [], 'containers': []}
    state = json.loads(path.read_text())
    if state.get('repo') != str(ROOT):
        raise LocalError('O registro pertence a outro checkout; não será utilizado.')
    return state


def container_info(cid):
    return json.loads(command(['docker', 'inspect', cid]))[0]


def shutdown(state):
    errors = []
    for record in list(reversed(state['processes'])):
        try:
            stop_process(record)
            state['processes'].remove(record)
            save(state)
        except (LocalError, OSError) as exc:
            errors.append(str(exc))
    for record in list(reversed(state['containers'])):
        try:
            info = container_info(record['id'])
            labels = info['Config'].get('Labels') or {}
            if (labels.get('com.docker.compose.project') != record['project'] or
                    labels.get('com.docker.compose.service') != record['service']):
                raise LocalError('Contêiner não corresponde ao recurso registrado; preservado.')
            if info['State']['Running']:
                command(['docker', 'stop', '--time', '10', record['id']])
            state['containers'].remove(record)
            save(state)
        except (LocalError, OSError) as exc:
            errors.append(str(exc))
    if not state['processes'] and not state['containers']:
        (RUNTIME / 'state.json').unlink(missing_ok=True)
    if errors:
        raise LocalError('Parada incompleta: ' + '; '.join(errors))


def ready(url):
    try:
        with urllib.request.urlopen(url + '/api/games?name=jarvis-probe', timeout=2) as response:
            body = json.load(response)
            return response.status == 200 and {'items', 'page', 'pageSize', 'total'} <= body.keys()
    except (OSError, ValueError, urllib.error.URLError):
        return False


def ensure_container(service, config, state):
    old_ids = compose('ps', '--all', '--quiet', service).split()
    if old_ids and container_info(old_ids[0])['State']['Running']:
        print(f'{service}: reutilizado; não será parado por jarvis-stop.')
        return
    # start/up separado da espera: registrar propriedade mesmo se a saúde falhar.
    try:
        compose('up', '-d', '--no-deps', service)
    finally:
        for cid in compose('ps', '--all', '--quiet', service).split():
            if not any(r['id'] == cid for r in state['containers']):
                state['containers'].append({'id': cid, 'service': service, 'project': config['name']})
                save(state)
    until = time.monotonic() + 45
    while time.monotonic() < until:
        ids = compose('ps', '--all', '--quiet', service).split()
        if ids:
            info = container_info(ids[0])['State']
            if info.get('Health', {}).get('Status') == 'healthy':
                return
            if info['Running'] and 'Health' not in info:
                return
            if not info['Running'] or info.get('Health', {}).get('Status') == 'unhealthy':
                break
        time.sleep(0.5)
    raise LocalError(f'{service}: não ficou disponível; confira docker compose logs {service}.')


def connection(config):
    db = config['services']['catalog-db']
    env = db['environment']
    port = next(p['published'] for p in db['ports'] if int(p['target']) == 5432)
    def quote(value):
        return '"' + str(value).replace('"', '""') + '"'
    return ';'.join(f'{key}={quote(value)}' for key, value in {
        'Host': '127.0.0.1', 'Port': port, 'Database': env['POSTGRES_DB'],
        'Username': env['POSTGRES_USER'], 'Password': env['POSTGRES_PASSWORD'],
    }.items())


def start(args, state):
    for record in state['processes']:
        if process_identity(record['pid']) == record['identity']:
            if ready(state['url']):
                if args.identity and not state.get('with_identity'):
                    raise LocalError('Pare a execução atual antes de reiniciar com --identity.')
                print(f'Já ativo: {state["url"]}/scalar/v1 (log em .jarvis/runtime/catalog-api.log).')
                return
            raise LocalError('Há uma execução registrada ainda indisponível; use status/stop antes de reiniciar.')
    if state['processes'] or state['containers']:
        shutdown(state)
    with socket.socket() as probe:
        try:
            probe.bind(('127.0.0.1', args.port))
        except OSError:
            raise LocalError(f'Porta {args.port} ocupada. Escolha --port; nenhum processo será encerrado.')
    command(['docker', 'info', '--format', '{{.ServerVersion}}'])
    sdk = command(['dotnet', '--list-sdks'])
    if not any(line.startswith('10.') for line in sdk.splitlines()):
        raise LocalError('É necessário SDK .NET 10.')
    config = json.loads(compose('config', '--format', 'json'))
    env = dict(os.environ, DOTNET_ENVIRONMENT='Development', ASPNETCORE_ENVIRONMENT='Development',
               ConnectionStrings__Catalog=connection(config), DOTNET_CLI_USE_MSBUILD_SERVER='0',
               MSBUILDDISABLENODEREUSE='1')
    state.update(url=f'http://127.0.0.1:{args.port}', with_identity=args.identity)
    save(state)
    try:
        ensure_container('catalog-db', config, state)
        if args.identity:
            ensure_container('db', config, state)
            ensure_container('iam', config, state)
        for argv in [
            ['dotnet', 'tool', 'restore'],
            ['dotnet', 'build', str(API / 'ReviewVerse.Game.Catalog.API.csproj'), '--nologo',
             '--disable-build-servers', '-m:1', '-nodeReuse:false', '-p:UseSharedCompilation=false'],
            ['dotnet', 'ef', 'database', 'update', '--project', str(MODULE / 'ReviewVerse.Game.Catalog.csproj'),
             '--startup-project', str(API / 'ReviewVerse.Game.Catalog.API.csproj'), '--no-build'],
        ]:
            command(argv, env=env, diagnostic=True)
        dll = API / 'bin/Debug/net10.0/ReviewVerse.Game.Catalog.API.dll'
        if not args.no_seed:
            command(['dotnet', str(dll), '--catalog-seed'], env=env, diagnostic=True)
        log = RUNTIME / 'catalog-api.log'
        with log.open('w') as output:
            log.chmod(0o600)
            process = subprocess.Popen(['dotnet', str(dll), '--urls', state['url']], cwd=ROOT,
                                       env=env, stdin=subprocess.DEVNULL, stdout=output,
                                       stderr=subprocess.STDOUT, start_new_session=True)
        identity = process_identity(process.pid)
        if not identity:
            process.terminate()
            try:
                process.wait(timeout=5)
            except subprocess.TimeoutExpired:
                process.kill()
                process.wait(timeout=5)
            raise LocalError('API encerrou ao iniciar; consulte .jarvis/runtime/catalog-api.log.')
        state['processes'].append({'pid': process.pid, 'identity': identity})
        save(state)
        until = time.monotonic() + 30
        while process.poll() is None and time.monotonic() < until:
            if ready(state['url']):
                print(f'API: {state["url"]}/api/games?name=acao\nScalar: {state["url"]}/scalar/v1')
                print('Log: .jarvis/runtime/catalog-api.log; parar: local_environment.py stop')
                if args.identity:
                    print('Keycloak iniciado em http://localhost:8080; disponibilidade funcional não verificada.')
                return
            time.sleep(0.3)
        raise LocalError('API não ficou pronta; consulte .jarvis/runtime/catalog-api.log.')
    except BaseException:
        shutdown(state)
        raise


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('action', choices=['start', 'stop', 'status'])
    parser.add_argument('--port', type=int, default=5080)
    parser.add_argument('--no-seed', action='store_true', help='Não reaplicar a massa fictícia de desenvolvimento.')
    parser.add_argument('--identity', action='store_true', help='Iniciar também Keycloak e seu PostgreSQL.')
    args = parser.parse_args()
    if not 1 <= args.port <= 65535:
        parser.error('Porta deve estar entre 1 e 65535.')
    RUNTIME.mkdir(mode=0o700, parents=True, exist_ok=True)
    RUNTIME.chmod(0o700)
    with (RUNTIME / 'lock').open('a') as lock:
        try:
            fcntl.flock(lock, fcntl.LOCK_EX | fcntl.LOCK_NB)
        except BlockingIOError:
            raise LocalError('Outra operação de ambiente está em andamento.')
        state = load()
        if args.action == 'start':
            start(args, state)
        elif args.action == 'stop':
            shutdown(state)
            print('Execução gerenciada encerrada; recursos preexistentes e volumes preservados.')
        else:
            print(json.dumps({'url': state.get('url'), 'processes': [
                {'pid': p['pid'], 'active': process_identity(p['pid']) == p['identity']}
                for p in state['processes']], 'containers_started_here': state['containers']}, indent=2))


if __name__ == '__main__':
    try:
        main()
    except (LocalError, OSError, ValueError, KeyError, StopIteration) as error:
        print(f'Jarvis: {error}', file=sys.stderr)
        sys.exit(1)
