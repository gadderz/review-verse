# ADR-0028 — Contrato HTTP da consulta de jogos

Estado: Aceito
Versão da constituição: 0.29
Origem da autorização: pedido do autor para seguir ao planejamento da FEAT-006, após confirmar sua especificação; escolha técnica do Arquiteto dentro dessa autorização e dos artigos 4 e 7 da constituição. Não autoriza implementação nesta etapa.
Substitui: nenhum; detalha as decisões vigentes para a FEAT-006.
Substituído por: nenhum.

## Contexto

A spec definiu o comportamento e deixou rota, representação, binding e formato de erros ao planejamento técnico.

## Decisão

Expor GET /api/games com name obrigatório, page inteiro positivo de 32 bits e pageSize de 1 a 100, padrões 1 e 20. name usa Trim e limite de 1 a 200 unidades UTF-16 de string.Length. Parâmetros escalares repetidos são inválidos. Retornar 200 com items, page, pageSize e total de 64 bits; cada item tem id UUID, title e platforms com id/name. Arrays são retornados mesmo vazios. Entrada inválida retorna 400 ValidationProblemDetails. Indisponibilidade/timeout do banco retorna 503 ProblemDetails; erro inesperado retorna 500 genérico. Incluir code e traceId, sem SQL ou configuração interna. Cancelamento do cliente não é convertido em 503.

## Alternativas consideradas

A rota e o envelope são escolhas técnicas da primeira API dentro do recorte confirmado. Adotar ProblemDetails aproveita o suporte do ASP.NET Core. Não houve comparação detalhada de convenções de versionamento ou outros formatos de erro nesta etapa.

## Consequências

O contrato e os exemplos ficam no plano e serão documentados em OpenAPI e guia duradouro na implementação. Preservar resposta vazia bem-sucedida para página além do fim e conferir binding, limites, overflow e falhas no pipeline real. Referência: [tratamento de erros ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-10.0).

## Fontes afetadas

- [FEAT-006](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md) e [EP-002](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Arquitetura inicial](../drafts/arquitetura-inicial.md) e documento de trabalho da execução.
- Constituição, snapshot 0.29 e índices de ADRs, versões e specs.
