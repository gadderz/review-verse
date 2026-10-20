# ADR-0026 — Persistência e migrações do Catálogo com EF Core

Estado: Aceito
Versão da constituição: 0.27
Origem da autorização: pedido do autor para seguir ao planejamento da FEAT-006, após confirmar sua especificação; escolha técnica do Arquiteto dentro dessa autorização e dos artigos 4 e 7 da constituição. Não autoriza implementação nesta etapa.
Substitui: nenhum; detalha as decisões vigentes para a FEAT-006.
Substituído por: nenhum.

## Contexto

O catálogo ainda não possui persistência. A massa controlada precisa de schema reproduzível e identidade estável, preparada separadamente da leitura pública.

## Decisão

Usar EF Core 10 com provider Npgsql 10, CatalogDbContext e migrações versionadas no módulo. Direcionar o provider ao PostgreSQL 16. O schema catalog contém games e platforms com UUIDs e associação game_platforms com PK composta e FKs; título não é único. Histórico de migrações no mesmo schema. Aplicar migrações explicitamente, sem DDL ou seed no startup normal. Preparar massa com IDs fixos por modo CLI --catalog-seed do host, restrito a Development/Testing, idempotente e sem servidor HTTP. Seed não faz parte da migração de esquema.

## Alternativas consideradas

Foram avaliados driver PostgreSQL direto com scripts de migração e EF Core com migrações. EF Core foi escolhido para manter evolução do modelo e histórico; SQL parametrizado permanece disponível para a consulta específica, sem repositório genérico.

## Consequências

A execução adicionará versões exatas compatíveis de pacotes e dotnet-ef ao manifesto local, preservando CSharpier. Migrações e seed precisam de testes de reaplicação e integridade. IGDB, dados administrativos e detalhes futuros não são antecipados pelo modelo mínimo. Referências: [provider Npgsql 10](https://www.npgsql.org/efcore/release-notes/10.0.html) e [migrações EF Core](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying).

## Fontes afetadas

- [FEAT-006](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md) e [EP-002](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Arquitetura inicial](../drafts/arquitetura-inicial.md) e documento de trabalho da execução.
- Constituição, snapshot 0.27 e índices de ADRs, versões e specs.
