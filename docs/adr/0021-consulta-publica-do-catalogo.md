# ADR-0021 — Consulta pública do catálogo de jogos

Estado: Aceito
Versão da constituição: 0.22
Origem da autorização: O autor aprovou o recorte do retorno apresentado, que incluía explicitamente acesso público.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A primeira entrega é de leitura do catálogo. A proposta de retorno incluiu acesso público para permitir busca antes dos fluxos pessoais de conta, Backlog e Reviews.

## Decisão

A consulta por nome da FEAT-006 é pública e não exige conta, token ou e-mail confirmado. Operações administrativas continuam exigindo autorização; as restrições de e-mail confirmado para Backlog e Reviews permanecem vigentes.

## Alternativas consideradas

Foi apresentada a proposta de consulta pública. Não houve comparação detalhada de modelos de autenticação nesta etapa.

## Consequências

A leitura não depende da entrega de login ou da integração Keycloak. Esta decisão não autoriza escrita pública no catálogo e não comprova configuração de autenticação/autorização implementada.

## Fontes afetadas

- [FEAT-006 — Consulta de jogos por nome pela API](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md).
- [EP-002 — Catálogo de Jogos](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Visão do projeto](../drafts/visao-do-projeto.md) e [arquitetura inicial](../drafts/arquitetura-inicial.md).
- Constituição, cópia da versão 0.22, índices de decisões, versões e specs.
