# ADR-0020 — Comparação de nomes na consulta de jogos

Estado: Aceito
Versão da constituição: 0.21
Origem da autorização: O autor confirmou que a recomendação de busca apresentada na especificação atende.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A busca por nome está confirmada para a POC, mas a correspondência textual precisava de definição observável antes do planejamento.

## Decisão

Buscar por trecho literal do título original registrado no catálogo, ignorando maiúsculas/minúsculas e acentos e removendo espaços somente nas pontas do termo. Pontuação, espaços internos, % e _ são literais. Não há aproximação por erros de digitação. O termo é obrigatório e aceita de 1 a 200 caracteres após remover espaços das pontas; ausência, vazio ou excesso geram erro de validação, sem listar todo o catálogo.

## Alternativas consideradas

Foram apresentadas busca por trecho, por prefixo e por nome exato. O autor aprovou a recomendação por trecho.

## Consequências

Os testes precisam cobrir comparação, acentos, caixa, espaços e caracteres literais no PostgreSQL. O Arquiteto definirá o mecanismo técnico e o contrato de validação, preservando o comportamento aprovado.

## Fontes afetadas

- [FEAT-006 — Consulta de jogos por nome pela API](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md).
- [EP-002 — Catálogo de Jogos](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Visão do projeto](../drafts/visao-do-projeto.md) e [arquitetura inicial](../drafts/arquitetura-inicial.md).
- Constituição, cópia da versão 0.21, índices de decisões, versões e specs.
