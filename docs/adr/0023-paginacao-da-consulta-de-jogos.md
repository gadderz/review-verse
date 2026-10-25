# ADR-0023 — Paginação e ordenação da consulta de jogos

Estado: Aceito
Versão da constituição: 0.24
Origem da autorização: O autor aprovou o recorte do retorno apresentado, que incluía paginação de 20 itens, máximo 100 e ordenação por título e identificador.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A API precisa limitar respostas e permitir percorrer todos os jogos correspondentes sem duplicação causada por plataformas ou empates de títulos.

## Decisão

Usar página 1 e tamanho 20 por padrão, com tamanho entre 1 e 100 e páginas inteiras a partir de 1. Ordenar por título sem distinção de caixa/acentos e depois pelo identificador do jogo, antes de paginar. Informar página, tamanho e total de jogos correspondentes. Valores não inteiros, menores que 1 ou tamanho maior que 100 geram erro de validação. Página válida além do fim retorna sucesso com lista vazia e total correto. Ausência de correspondências retorna lista vazia e total zero.

## Alternativas consideradas

Foi apresentada essa proposta de paginação e ordenação; não houve comparação detalhada de outras estratégias.

## Consequências

Os testes precisam verificar limites, totais por jogo, empates e percurso sem repetições/omissões com dados inalterados. Não há promessa de uma visão imutável entre páginas enquanto o catálogo muda. Rota e representação HTTP serão definidas no plano.

## Fontes afetadas

- [FEAT-006 — Consulta de jogos por nome pela API](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md).
- [EP-002 — Catálogo de Jogos](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Visão do projeto](../drafts/visao-do-projeto.md) e [arquitetura inicial](../drafts/arquitetura-inicial.md).
- Constituição, cópia da versão 0.24, índices de decisões, versões e specs.
