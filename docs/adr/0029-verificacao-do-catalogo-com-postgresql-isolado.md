# ADR-0029 — Verificação do Catálogo com PostgreSQL isolado

Estado: Aceito
Versão da constituição: 0.30
Origem da autorização: pedido do autor para seguir ao planejamento da FEAT-006, após confirmar sua especificação; escolha técnica do Arquiteto dentro dessa autorização e dos artigos 4 e 7 da constituição. Não autoriza implementação nesta etapa.
Substitui: nenhum; detalha as decisões vigentes para a FEAT-006.
Substituído por: nenhum.

## Contexto

O autor escolheu PostgreSQL em Docker, com OrbStack no ambiente local. A primeira Feature não possui testes e precisa verificar regras dependentes do banco sem usar os dados da identidade ou do desenvolvimento.

## Decisão

Adicionar serviços catalog-db e catalog-db-tests ao Compose, com imagem postgres:16-bookworm, UTF-8 e locale en_US.utf8. Desenvolvimento usa volume próprio e porta local padrão 55432; testes usam banco reviewverse_catalog_tests, tmpfs, profile catalog-tests e porta 55433, configuráveis. Usar dois projetos xUnit.net v2 com VSTest para testes unitários e de integração. Integração usa Microsoft.AspNetCore.Mvc.Testing 10 e WebApplicationFactory com provider e pipeline reais. Exigir conexão explícita do banco de testes, conferir seu nome antes de limpar dados e serializar fixtures que o compartilham.

## Alternativas consideradas

Foram considerados Compose explícito e provisionamento por Testcontainers. Compose aproveita a ferramenta já disponível e dispensa integração de socket específica. Simulações do provider não demonstram comparação, SQL ou integridade no PostgreSQL.

## Consequências

Fixar versões exatas estáveis dos pacotes na implementação e usar a mesma imagem nos dois bancos. Portas e credenciais são configuráveis. Não iniciar ou remover serviços da identidade para testar o catálogo. Falta de infraestrutura gera pendência/falha explícita. A decisão define o desenho, sem provar execução de contêineres. Referências: [imagem oficial](https://hub.docker.com/_/postgres), [integração ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-10.0) e [xUnit.net v2](https://xunit.net/docs/getting-started/v2/getting-started).

## Fontes afetadas

- [FEAT-006](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md) e [EP-002](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Arquitetura inicial](../drafts/arquitetura-inicial.md) e documento de trabalho da execução.
- Constituição, snapshot 0.30 e índices de ADRs, versões e specs.
