---
name: jarvis-stop
description: "Parar os processos e contêineres iniciados por jarvis-run no ReviewVerse, preservando serviços preexistentes, volumes e processos de outros projetos."
---

# Encerrar execução local

Leia [AGENTS.md](../../../AGENTS.md). Um pedido de parada autoriza encerrar a
execução gerenciada; não exige nova Feature. Na raiz, executar:

```sh
python3 .jarvis/scripts/local_environment.py status
python3 .jarvis/scripts/local_environment.py stop
python3 .jarvis/scripts/local_environment.py status
```

O auxiliar identifica grupos de processos por PID, início e comando. Não envia
sinais quando a identidade mudou, evitando PID reutilizado. Para contêineres,
confere o ID e os labels Compose; só para serviços iniciados por essa execução.
Serviços reutilizados não são assumidos como próprios. Volumes, contêineres e
redes não são removidos; logs são mantidos para diagnóstico.

Sem registro, informar que não há recursos gerenciados; não procurar vítimas
por nome/porta. Se falhar a parada, manter a informação para retomada e relatar
o recurso que continua pendente. Não apagar um registro pendente, usar
`docker compose down -v`, `pkill` ou encerrar processos alheios.
