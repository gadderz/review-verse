# ADR-0019 — Massa controlada na primeira consulta do catálogo

Estado: Aceito
Versão da constituição: 0.20
Origem da autorização: O autor escolheu explicitamente usar massa controlada de desenvolvimento/teste e deixar IGDB para outra Feature.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A primeira Feature precisa verificar a consulta persistida, enquanto a integração IGDB ainda contém estruturas vazias. A proposta separou a leitura do catálogo da carga externa completa.

## Decisão

Concluir a FEAT-006 usando uma massa controlada de desenvolvimento e testes persistida em PostgreSQL. A preparação dos dados deve ser reproduzível. A importação real da IGDB entra em outra Feature do EP-002; permanece obrigatória para concluir o catálogo da POC.

## Alternativas consideradas

Foram apresentadas massa controlada persistida e inclusão da importação real IGDB já na primeira entrega. O autor escolheu a primeira opção.

## Consequências

A consulta pode ser implementada e verificada sem credenciais IGDB ou Worker pronto. A massa controlada não comprova integração, popularidade, elegibilidade ou carga inicial de 100 jogos. Não criar uma API pública de escrita como atalho para preparar os dados.

## Fontes afetadas

- [FEAT-006 — Consulta de jogos por nome pela API](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md).
- [EP-002 — Catálogo de Jogos](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Visão do projeto](../drafts/visao-do-projeto.md) e [arquitetura inicial](../drafts/arquitetura-inicial.md).
- Constituição, cópia da versão 0.20, índices de decisões, versões e specs.
