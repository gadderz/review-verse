# FEAT-006 — Consulta de jogos por nome pela API

Épico: [EP-002 — Catálogo de Jogos](../epics/EP-002-catalogo-de-jogos.md)
Estado: Concluído

## Necessidade e comportamento esperado

Permitir que um consumidor da API encontre jogos pelo nome no catálogo do
ReviewVerse. Essa é a primeira entrega funcional especificada para o produto e
prepara o consumo por uma interface futura, sem exigir Backlog ou Reviews.

A consulta lê o catálogo persistido do produto e apresenta jogos agregados,
sem transformar cada plataforma em um resultado separado. Não pesquisa a IGDB
em tempo real nem importa jogos como efeito da leitura.

O recorte foi confirmado pelo autor e implementado na branch
`feat/006-game-search-api`. As verificações e a revisão foram concluídas, com achados corrigidos e
evidências consolidadas nesta spec. O catálogo completo
continua no Épico EP-002.

## Fontes e decisões

- [Visão do projeto](../../drafts/visao-do-projeto.md): consulta por nome,
  agregação por jogo, plataformas, fonte IGDB e idiomas da POC.
- [Arquitetura inicial](../../drafts/arquitetura-inicial.md): consulta no Catálogo,
  persistência PostgreSQL e alimentação separada pelo Worker/administração.
- [Roteiro da POC](../../drafts/plano-da-poc.md): busca, paginação e integração
  ainda precisam de detalhamento; as etapas não estão implementadas.
- [ADR-0001](../../adr/0001-testes-automatizados-por-comportamento.md),
  constituição 0.2: testes automatizados por comportamento.
- [ADR-0007](../../adr/0007-limites-de-modulos-e-evolucao-da-arquitetura.md),
  constituição 0.8: limites de módulos e arquitetura vigente.
- [ADR-0008](../../adr/0008-conclusao-baseada-em-criterios-e-evidencias.md),
  constituição 0.9: evidências necessárias à conclusão.
- [ADR-0013](../../adr/0013-arquitetura-e-planejamento-tecnico.md),
  constituição 0.14, e [ADR-0017](../../adr/0017-contrato-do-especificador.md),
  constituição 0.18: especificação e passagem ao Arquiteto.
- Pedido do autor: trabalhar somente na especificação; planejar após a revisão,
  abrir branch da Feature para implementar com Backend, revisar com Jarvis e
  consolidar antes do commit em inglês no padrão Conventional Commits.
- [ADR-0019](../../adr/0019-massa-controlada-na-primeira-consulta.md), versão
  0.20: massa controlada; importação IGDB em outra Feature.
- [ADR-0020](../../adr/0020-comparacao-de-nomes-na-consulta.md), versão 0.21:
  correspondência textual e validação do termo.
- [ADR-0021](../../adr/0021-consulta-publica-do-catalogo.md), versão 0.22:
  acesso público à consulta.
- [ADR-0022](../../adr/0022-retorno-minimo-da-consulta.md), versão 0.23:
  identificador, título original e plataformas; localização permanece no Épico.
- [ADR-0023](../../adr/0023-paginacao-da-consulta-de-jogos.md), versão 0.24:
  paginação e ordenação estáveis com dados inalterados.
- [ADR-0024](../../adr/0024-postgresql-local-em-docker.md), versão 0.25:
  PostgreSQL local em Docker, considerando OrbStack no ambiente do autor.
- [ADR-0025](../../adr/0025-modulo-inicial-do-catalogo.md), versão 0.26:
  módulo em biblioteca e host inicial da API modular.
- [ADR-0026](../../adr/0026-persistencia-do-catalogo-com-ef-core.md), versão
  0.27: EF Core/Npgsql 10, migrações e preparação explícita da massa.
- [ADR-0027](../../adr/0027-busca-literal-com-unaccent.md), versão 0.28:
  busca literal, normalização e agregação no PostgreSQL.
- [ADR-0028](../../adr/0028-contrato-http-da-consulta-de-jogos.md), versão
  0.29: contrato HTTP da consulta e erros.
- [ADR-0029](../../adr/0029-verificacao-do-catalogo-com-postgresql-isolado.md),
  versão 0.30: ambientes isolados e estratégia de testes.

## Escopo e dependências

### Recorte confirmado

- Consulta pública por nome pela API, sem conta, token ou e-mail confirmado.
- Leitura real em PostgreSQL, com massa controlada de desenvolvimento/testes
  reproduzível, em contêiner Docker no ambiente local com OrbStack.
  A massa não comprova carga ou integração com a IGDB.
- Busca por trecho literal do título original, ignorando caixa e acentos e
  removendo espaços somente das pontas. Sem aproximação por erros de digitação,
  busca por palavras independentes ou interpretação de curingas.
- Cada item retorna identificador estável do jogo no produto, título original
  e plataformas disponíveis, com identificadores e nomes. Jogos homônimos
  distintos preservam suas identidades; plataformas não duplicam o jogo.
- Paginação com página 1 e 20 jogos por padrão, com tamanho entre 1 e 100.
  A resposta informa página, tamanho e total de jogos correspondentes.
- Ordenação crescente pelo título sem distinção de caixa/acentos, seguida do
  identificador do jogo para desempate. A ordenação vale antes da paginação.
- Termo obrigatório de 1 a 200 caracteres após remover espaços das pontas;
  entradas inválidas retornam erro de validação, sem executar uma listagem geral.
- Ausência de correspondências é um resultado vazio bem-sucedido. Falha da
  persistência retorna erro de serviço e não é apresentada como catálogo vazio.

Os valores de limite, as regras de comparação e o conteúdo da resposta foram
confirmados pelo autor. Rota, nomes/tipos dos campos HTTP, formato dos erros,
tecnologias de acesso a dados e estrutura dos projetos estão definidos no
plano técnico da execução, respeitando o comportamento desta spec. Seu resumo
duradouro está nos ADRs 0025 a 0029.

### Fora desta primeira entrega

Importação/sincronização IGDB, Worker, carga real dos 100 jogos, endpoints de
administração, filtros por gênero/plataforma, detalhes por identificador, capa,
sinopse e demais metadados da página, interface web, conta, Backlog e Reviews.

Títulos traduzidos e pesquisa em nomes alternativos ficam para evolução,
conforme ADR-0022. A visão continua exigindo títulos e sinopses traduzidos
quando disponíveis na fonte para a apresentação da POC. O recorte não altera
essa obrigação do Épico nem conclui a interface localizada.

### Dependências e limites

| Dependência | Situação e impacto |
| --- | --- |
| Definições de comportamento | D-01 a D-05 resolvidas pelo autor e registradas em ADRs. Não há dúvida material aberta para iniciar o planejamento. |
| Persistência do Catálogo em PostgreSQL | Implementada com EF Core/Npgsql, migração inicial e preparação explícita de dados; verificada em PostgreSQL 16.15. |
| Dados para consulta e testes | Massa controlada persistida confirmada. Sua preparação deve ser reproduzível, sem criar nesta Feature uma API pública de escrita ou substituir a carga real exigida pelo Épico. |
| Ambiente local do banco | PostgreSQL 16 em Docker, com serviços próprios para desenvolvimento e testes, considerando OrbStack. Serviços isolados executados no OrbStack e verificados com locale en_US.utf8. |
| API .NET modular | Host inicial e biblioteca do módulo definidos no ADR-0025. A organização das demais áreas continua em detalhamento; o plano não implementa sua migração. |
| Testes automatizados | Projetos de testes unitários e integrados implementados; nove testes unitários e 37 integrados passaram, sem ignorados. |
| IGDB, Worker e administração | Continuam necessários ao catálogo completo, mas não são pré-requisitos para concluir esta primeira consulta. IGDB entra em outra Feature; credenciais externas não são necessárias para ler jogos já persistidos. |
| Keycloak e Frontend | A consulta pública não depende de login. Não há entrega de interface nesta Feature; Frontend participa quando houver esse recorte. |

### Definições após a revisão com o autor

| ID | Questão revisada | Definição confirmada |
| --- | --- | --- |
| D-01 | Dados controlados ou carga real IGDB? | Resolvida: massa controlada de desenvolvimento/testes persistida; IGDB em outra Feature (ADR-0019). |
| D-02 | Comparação do nome e validação do termo? | Resolvida: trecho literal, sem distinguir caixa/acentos, espaços das pontas removidos e termo de 1 a 200 caracteres; regras completas no ADR-0020. |
| D-03 | Campos e idiomas do retorno? | Resolvida: identificador, título original e plataformas; capa, traduções e nomes alternativos ficam para evolução. A localização da POC permanece obrigatória (ADR-0022). |
| D-04 | Acesso público? | Resolvida: leitura sem autenticação; operações administrativas e pessoais mantêm suas próprias regras (ADR-0021). |
| D-05 | Limites e ordenação da paginação? | Resolvida: página 1/tamanho 20 por padrão, máximo 100, título normalizado e identificador; validação e página além do fim conforme ADR-0023. |

O autor confirmou as recomendações de busca e retorno e escolheu massa
controlada. Acrescentou a instrução de banco em contêiner Docker com OrbStack
no ambiente local, registrada no ADR-0024. Não há dúvida material pendente de
comportamento ou escopo nesta Feature. Escolhas técnicas pertencem ao plano.

## Critérios de aceitação

AC-01 a AC-08 descrevem o comportamento definido para a entrega. As questões
D-01 a D-05 estão resolvidas. Os oito critérios foram implementados, verificados e revisados; evidências abaixo.

| ID | Resultado observável |
| --- | --- |
| AC-01 | Dado um catálogo persistido com jogos, um cliente sem autenticação consulta um termo válido pela API e recebe sucesso com identificador estável, título e plataformas de cada jogo correspondente. |
| AC-02 | Dado o título `Ação no Espaço`, consultas por `AÇÃO`, `acao` e `  espaço  ` encontram o jogo. Um título sem o trecho procurado não é retornado. `%` e `_` não funcionam como curingas; espaços internos e pontuação não são removidos. |
| AC-03 | Dado um jogo em várias plataformas, a busca retorna um único item com as plataformas sem repetição; total e paginação contam jogos. Dois jogos distintos com o mesmo título continuam sendo dois resultados com identificadores diferentes. |
| AC-04 | Dado termo válido sem correspondências ou catálogo sem jogos, a API retorna sucesso, lista vazia e total zero. Não busca dados na IGDB nem cria registros como efeito da consulta. |
| AC-05 | Dado termo ausente, vazio, composto apenas por espaços ou maior que 200 caracteres após remover espaços das pontas, a API retorna erro de validação identificando a entrada inválida; não retorna todos os jogos. |
| AC-06 | Dados jogos suficientes para várias páginas, a API retorna 20 itens por padrão, aceita tamanho de 1 a 100 e aplica ordenação por título sem distinção de caixa/acentos e identificador antes de paginar. Com dados inalterados, percorrer as páginas não repete nem omite jogos, inclusive em empates. A resposta informa página, tamanho e total de jogos. |
| AC-07 | Página/tamanho não inteiros ou menores que 1 e tamanho maior que 100 retornam erro de validação. Uma página válida além do fim retorna sucesso com lista vazia, página/tamanho solicitados e o total correto de jogos correspondentes. |
| AC-08 | Dado PostgreSQL indisponível durante uma consulta válida, o cliente recebe erro de serviço distinguível de resultado vazio, sem detalhes internos de infraestrutura ou credenciais na resposta. O catálogo persistido continua consultável sem credenciais ou disponibilidade da IGDB. |

## Condições de conclusão da Feature

- Decisões adotadas registradas e escopo e contratos coerentes no plano;
  resolver novas dúvidas materiais que surgirem antes da execução afetada.
- Todos os critérios aprovados atendidos, com evidências vinculadas a cada ID.
- Testes automatizados das regras e verificação integrada da API com PostgreSQL,
  incluindo persistência, agregação, comparação de nomes e paginação. Testes
  somente em memória não comprovam o comportamento no banco escolhido.
- Política de testes cumprida; eventual exceção registra motivo, risco e
  alternativa realizada, conforme a constituição.
- Contrato da API e instruções para preparar dados e reproduzir as verificações
  no PostgreSQL em Docker documentados, incluindo validações e falhas;
  compilação registrada separadamente.
- Revisão de implementação com `jarvis-review`, achados impeditivos corrigidos
  e resultados consolidados na Feature, no Épico e no índice, conforme pedido.
- Antes de remover o documento de trabalho, preservar evidências e contexto de
  retomada nas fontes duradouras. O commit segue inglês e Conventional Commits.

A entrega pode ser verificada em ambiente local reproduzível. Não há requisito
de publicar a API em produção para concluir este recorte. Carga real de 100
jogos, POC completa e conclusão do Épico não são comprovadas por esta consulta.

## O que já foi feito

- Especificação confirmada e plano registrado conforme ADRs 0019 a 0029.
- Consulta pública `GET /api/games` implementada com massa controlada, título
  original e plataformas agregadas. Validações, paginação e erros documentados.
- Módulo do Catálogo, PostgreSQL em Docker, migrações explícitas e seed idempotente
  de 25 jogos fictícios implementados. Não há integração IGDB nesta entrega.
- Nove testes unitários e 37 integrados passaram com PostgreSQL real no OrbStack.
- Migrações e seed CLI repetidos duas vezes; seed recusado em Production.
  Consulta HTTP e persistência verificadas após reiniciar host e contêiner.
- Guia duradouro e exemplos em
  [Catálogo local](../../desenvolvimento/catalogo-local.md).

## O que falta

Nenhuma pendência funcional ou de evidência neste recorte. Importação IGDB,
interface e demais entregas continuam no Épico e não foram concluídas por esta Feature.

## Evidências

Verificações de 20/10/2026, SDK 10.0.100, PostgreSQL 16.15 em Docker/OrbStack,
locale en_US.utf8. Classes `GameSearchQueryTests` e `GameSearchTests` nos projetos
`tests/ReviewVerse.Game.Catalog.UnitTests` e `tests/ReviewVerse.Game.Catalog.IntegrationTests`.

| Critério | Verificação | Resultado e evidência duradoura |
| --- | --- | --- |
| AC-01 | `AnonymousSearchAggregatesPlatformsAndKeepsHomonyms`; smoke HTTP com Kestrel. | Passou: acesso sem token, título, UUIDs e plataformas reais persistidas. |
| AC-02 | `MatchesCaseAccentsAndTrimmedLiteralSubstring`, `PreservesLiteralCharacters`. | Passou: quatro variações de caixa/acentos/Unicode e seis casos literais, inclusive espaços internos. |
| AC-03 | `AnonymousSearchAggregatesPlatformsAndKeepsHomonyms`, `PaginationTraversesGamesInNormalizedOrderIncludingTies`, `MigrationsAndSeedAreRepeatableAndKeepExistingData`. | Passou: homônimos independentes, agregação, total por jogo e PK composta contra associação duplicada. |
| AC-04 | `EmptyCatalogAndNoMatchReturnEmptyArraysWithoutWriting`. | Passou: banco vazio e termo inexistente retornam 200/lista vazia; dados preservados, sem cliente ou credenciais IGDB. |
| AC-05 | `RejectsInvalidRequestsWithConsistentProblemDetails`, `ValidatesNameLengthAfterTrim`; testes unitários. | Passou: nome ausente/vazio/branco, limites 200/201 após Trim e validação anterior ao banco. |
| AC-06 | `PaginationTraversesGamesInNormalizedOrderIncludingTies`. | Passou: 125 jogos, páginas padrão 1/20, limites 1/100, empates na fronteira e percurso sem repetições/omissões. |
| AC-07 | `RejectsInvalidRequestsWithConsistentProblemDetails`, `PaginationTraversesGamesInNormalizedOrderIncludingTies`; `CalculatesLargePageOffsetWithoutOverflow`. | Passou: entradas inválidas, repetidas, página além do fim e int.MaxValue com total correto e offset de 64 bits. |
| AC-08 | `DatabaseOutageReturns503AndInvalidInputStillReturns400`, `SqlDefectsReturnGeneric500InsteadOf503`. | Passou: falha de conexão vira 503, erro SQL vira 500; sem detalhes internos em Development. Leitura funciona sem IGDB. |

Comandos efetivamente executados: `dotnet build ReviewVerse.slnx --no-restore -m:1 -nodeReuse:false`, testes dos dois `.csproj` acima e testes
integrados com `--logger trx`. Resultado: nove unitários e 37 integrados,
zero falhas/ignorados na execução final do Backend. As primeiras execuções
integradas detectaram inconsistência no snapshot da extensão e mapeamento de
falha transitória do EF; corrigidos e verificados novamente.

Build passou com aviso NU1903 preexistente: `Newtonsoft.Json` 11.0.1 transitivo
no Worker/Hangfire, fora do código alterado desta Feature. Não houve exceção à
política de testes. Os comandos que exigem socket/daemon/cache foram executados
fora do sandbox após aprovação; resultados reais não foram substituídos por simulação.

O fluxo local confirmou a aplicação repetida da migração e do seed CLI,
recusa do seed em Production e persistência após reinício da API e do contêiner
de desenvolvimento. A massa é fictícia e não comprova importação IGDB, carga de
100 jogos reais, desempenho com 10 usuários ou implantação de produção.

## Revisão e tratamento dos achados

Revisão com `jarvis-review` na mesma sessão da implementação, sem independência.
Alvo: diferenças da FEAT-006, plano, critérios, ADRs 0019 a 0029, testes, migração,
Compose e instruções locais. A fase de Revisor preservou o alvo; correções foram
feitas depois pelo papel Backend. Não surgiram dúvidas de escopo ou nova decisão.

| Achado | Evidência e consequência | Tratamento |
| --- | --- | --- |
| R-01 — Médio | Em `Contracts/GameSearchRequest.cs`, campos nullable/string geravam metadados OpenAPI sem obrigatoriedade de name e com paginação textual, divergindo do contrato. O teste inicial verificava só a presença dos parâmetros. | Corrigido com `GameSearchOpenApiTransformer`: name obrigatório, paginação inteira, padrões e limites. `OpenApiDocumentsTheContract` passou verificando esses metadados e os códigos de resposta. |
| R-02 — Médio | `docker compose --env-file /dev/null config --services` falhava por variáveis obrigatórias dos novos serviços, impedindo carregar a composição de identidade sem configuração do Catálogo. | Valores locais fictícios de fallback, com portas limitadas a loopback; `.env` permite credenciais próprias. `ComposeStillLoadsWithoutCatalogEnvironmentVariables` passou; o comando voltou a listar serviços sem erro. |

Após as correções, nova conferência do recorte e execução final: nove testes
unitários e 37 integrados passaram, zero falhas e zero ignorados. Build passou;
CSharpier local 0.28.2 e `git diff --check` passaram. Nenhum achado impeditivo
permaneceu aberto. A revisão não comprova importação IGDB, produção, capacidade
ou regressões de fluxos de conta/Reviews ainda não implementados.

O documento de trabalho foi consolidado nesta Feature, nos ADRs e no guia local
antes de seu encerramento. Os arquivos de teste e a migração permitem reproduzir
as verificações sem depender do plano temporário ou de TRX local. As decisões
permanecem nos ADRs 0019 a 0029 e nas versões 0.20 a 0.30, sem alterar registros
anteriores. Commit preparado: `feat(catalog): add game search by name`.

## Próxima ação

Usar o guia local para consumir a consulta e especificar a próxima Feature do
Catálogo, incluindo a importação IGDB em seu próprio recorte. Consultar o
histórico Git desta branch para o commit da entrega; não houve merge ou publicação.
