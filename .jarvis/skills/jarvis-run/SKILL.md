---
name: jarvis-run
description: "Iniciar o ReviewVerse local e suas dependências para uso e teste manual, informar URLs e logs e registrar os recursos iniciados para parada posterior."
---

# Executar localmente

Leia [AGENTS.md](../../../AGENTS.md) e o
[guia local](../../../docs/desenvolvimento/catalogo-local.md). Um pedido para
rodar o projeto autoriza preparação, build e processos locais necessários.
Não exige criar Feature para usar o ambiente existente nem autoriza implementar
componentes faltantes, mudar regras de negócio ou publicar remotamente.

O recorte funcional atual é o Catálogo com PostgreSQL. Reviews é host inicial;
Worker não tem armazenamento Hangfire configurado e não há frontend Next.js.
Não apresentar esses componentes como prontos. Conforme surgirem novas Features,
conferir os serviços reais antes de ampliar o auxiliar e o guia.

Na raiz, use Python 3 no macOS/Linux:

```sh
python3 .jarvis/scripts/local_environment.py status
python3 .jarvis/scripts/local_environment.py start
```

O auxiliar confere SDK .NET 10/Docker, lê a configuração Compose sem publicá-la,
reutiliza dependências já ativas, inicia catalog-db, restaura ferramentas, compila,
aplica migrações e prepara a massa fictícia de desenvolvimento. `--no-seed`
preserva a massa atual; `--port 5081` escolhe outra porta sem matar seu ocupante.
Para usar também identidade, adicionar `--identity`: Keycloak e seu PostgreSQL
são iniciados, mas a consulta pública não depende deles. A prontidão da API é
verificada por consulta HTTP real; readiness funcional do Keycloak é separada.

Se Docker estiver parado ou faltar acesso a socket/cache, relatar a causa e
respeitar permissões do ambiente. Não trocar por banco em memória, iniciar o
daemon global silenciosamente ou declarar sucesso sem verificação. Uma falha
de startup tenta parar somente os recursos iniciados pelo auxiliar.

Entregar URL da API/Scalar, resultado da consulta, dados fictícios preparados,
serviços reutilizados e limites reais. Estado/PIDs e logs ficam em
`.jarvis/runtime/`, ignorado pelo Git e sem conexão/credenciais no registro.
Não expor `.env` ou Compose resolvido. Para encerrar, usar `jarvis-stop` ou o
subcomando `stop` do mesmo auxiliar; nunca `pkill dotnet` ou encerramento por porta.
