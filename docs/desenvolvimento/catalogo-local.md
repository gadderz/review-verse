# Catálogo local — FEAT-006

A consulta pública é `GET /api/games`. O banco do produto roda em Docker;
o ambiente foi exercitado com OrbStack. A integração IGDB pertence a outra
Feature. A massa local contém 25 jogos fictícios.

## Preparar

Requisitos: SDK .NET 10, Docker e Compose. Confira `dotnet --list-sdks` e
`docker context show`. Copie `.env.example` para `.env` se ainda não tiver
configuração local e ajuste as senhas. `.env` é ignorado pelo Git.

Na raiz, carregue as variáveis na sessão do terminal:

```sh
set -a
source .env
set +a
export ConnectionStrings__Catalog="Host=127.0.0.1;Port=${CATALOG_DB_PORT};Database=reviewverse_catalog;Username=${CATALOG_DB_USER};Password=${CATALOG_DB_PASSWORD}"
export ConnectionStrings__CatalogTests="Host=127.0.0.1;Port=${CATALOG_TEST_DB_PORT};Database=reviewverse_catalog_tests;Username=${CATALOG_TEST_DB_USER};Password=${CATALOG_TEST_DB_PASSWORD}"
docker compose up -d --wait catalog-db
dotnet restore ReviewVerse.slnx
dotnet tool restore
dotnet build ReviewVerse.slnx
dotnet ef database update --project src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog.csproj --startup-project src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog.API/ReviewVerse.Game.Catalog.API.csproj --no-build
DOTNET_ENVIRONMENT=Development dotnet run --project src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog.API --no-launch-profile --no-build -- --catalog-seed
```

Não publique as conexões ou o conteúdo expandido do Compose. Senhas
hexadecimais aleatórias evitam delimitadores que exigiriam escape na conexão.
User-secrets também podem fornecer `ConnectionStrings:Catalog` à API; a factory
de migração usa a variável explícita `ConnectionStrings__Catalog`.

Os serviços `catalog-db` (porta padrão 55432, volume próprio) e
`catalog-db-tests` (55433, tmpfs, profile `catalog-tests`) usam
`postgres:16-bookworm`, UTF-8 e locale `en_US.utf8`. Em conflito de porta,
ajuste `.env` e recarregue as conexões. Os serviços de identidade `iam`, `db`
e seu volume não são necessários para esta consulta. O Compose tem valores
fictícios de fallback limitados ao ambiente local para preservar seu carregamento
sem `.env`; a configuração local pode substituí-los com credenciais próprias.

Migrações criam o schema `catalog`, suas tabelas e `unaccent` em `public`;
a conta de preparação precisa dessas permissões. A API normal não aplica
migrações nem seed. Na implantação, dê à aplicação somente as permissões de
leitura necessárias. A normalização declarada no modelo omite o schema padrão
da extensão para manter o snapshot do provider consistente; a migração cria
explicitamente a extensão em `public` e a consulta qualifica essa função.

O seed usa IDs fixos e inclui dois jogos chamados `Eco`, caracteres literais
e um jogo multiplataforma. Reexecutá-lo atualiza sua própria massa por ID,
sem duplicar associações ou apagar jogos externos. Ele só funciona em
Development/Testing e encerra sem abrir servidor HTTP.

## Executar e consumir

```sh
DOTNET_ENVIRONMENT=Development dotnet run --project src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog.API --no-launch-profile --no-build --urls http://localhost:5080
```

Exemplos no arquivo
[`ReviewVerse.Game.Catalog.API.http`](../../src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog.API/ReviewVerse.Game.Catalog.API.http).
OpenAPI: `/openapi/v1.json`; Scalar: `/scalar/v1`, em Development.

```sh
curl 'http://localhost:5080/api/games?name=acao&page=1&pageSize=20'
```

| Entrada | Regra |
| --- | --- |
| `name` | Obrigatória, trecho literal sem distinguir caixa/acentos, Trim nas pontas; entre 1 e 200 unidades UTF-16 (`string.Length`). |
| `page` | Inteiro positivo de 32 bits; padrão 1. |
| `pageSize` | Inteiro de 1 a 100; padrão 20. |

Parâmetros escalares repetidos são inválidos. `%`, `_`, barra invertida,
pontuação e espaços internos são literais; faça URL-encoding do termo.
Não há pesquisa aproximada ou em nomes alternativos. Traduções e capa ficam
para evolução. Não são necessários token ou credenciais IGDB.

Sucesso: `200 application/json` com `items`, `page`, `pageSize` e `total`.
Cada jogo tem `id` (UUID do produto), `title` e `platforms` com `id`/`name`.
Arrays vazios são `[]`. Total e páginas contam jogos; plataformas não duplicam
resultados e homônimos preservam identidades. Ordenar por título normalizado
sem caixa/acentos e UUID antes de paginar; plataformas por nome normalizado
e UUID. O texto retornado é preservado.

Sem correspondência, lista vazia/total zero. Página além do fim, lista vazia e
total correto, preservando página/tamanho solicitados. Total, itens e plataformas
de uma resposta usam o mesmo snapshot; requisições distintas podem refletir
alterações posteriores do catálogo.

| Falha | Resultado `application/problem+json` |
| --- | --- |
| 400 | `title: Invalid request`, `code: validation_error`, `errors` por parâmetro. |
| 503 | Banco indisponível/timeout; `title: Catalog unavailable`, `code: catalog_unavailable`. |
| 500 | Falha inesperada, incluindo SQL/esquema incompatível; `code: internal_error`. |

Erros têm `type: about:blank`, `status` e `traceId`, sem SQL, stack trace,
credenciais ou host do banco na resposta, inclusive em Development. Validação
antecede o acesso ao banco. Sem retries automáticos; timeouts iniciais de
3 segundos para conexão e 5 para comando. Cancelamento do cliente é propagado.

## Verificar e encerrar

```sh
docker compose --profile catalog-tests up -d --wait catalog-db-tests
dotnet test tests/ReviewVerse.Game.Catalog.UnitTests/ReviewVerse.Game.Catalog.UnitTests.csproj
dotnet test tests/ReviewVerse.Game.Catalog.IntegrationTests/ReviewVerse.Game.Catalog.IntegrationTests.csproj --logger trx
dotnet csharpier --check src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog src/ReviewVerse.Game.Catalog/ReviewVerse.Game.Catalog.API tests/ReviewVerse.Game.Catalog.UnitTests tests/ReviewVerse.Game.Catalog.IntegrationTests
git diff --check
docker compose --profile catalog-tests stop catalog-db-tests
docker compose stop catalog-db
```

Os testes integrados exigem conexão explícita e confirmam o nome real do banco
`reviewverse_catalog_tests` antes de limpar tabelas. Aplicam as migrações reais,
serializam os cenários e não usam fallback para desenvolvimento ou identidade.
Para execuções simultâneas, use serviços/conexões isolados.

A suíte cobre busca, Unicode, caracteres literais, agregação, homônimos,
paginação, validações, falhas de conexão e SQL e repetição de migrações/seed.
A indisponibilidade usa host separado apontando a porta sem listener, sem
parar o banco dos demais testes. TRX fica em `TestResults/`, ignorado pelo Git.
A [FEAT-006](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md)
consolida resultados por critério, revisão e limites.

Parar o banco de desenvolvimento preserva seu volume; testes usam tmpfs.
Não use `down -v` nesta composição para limpar o Catálogo: ela também contém
a identidade do projeto.
