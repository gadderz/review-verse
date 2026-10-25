# ADR-0027 — Busca literal e agregação no PostgreSQL

Estado: Aceito
Versão da constituição: 0.28
Origem da autorização: pedido do autor para seguir ao planejamento da FEAT-006, após confirmar sua especificação; escolha técnica do Arquiteto dentro dessa autorização e dos artigos 4 e 7 da constituição. Não autoriza implementação nesta etapa.
Substitui: nenhum; detalha as decisões vigentes para a FEAT-006.
Substituído por: nenhum.

## Contexto

As regras aprovadas exigem ignorar caixa e acentos, preservar caracteres literais, ordenar antes de paginar e não duplicar jogos por suas plataformas.

## Decisão

Habilitar unaccent em public por migração. Comparar o trecho com strpos(lower(public.unaccent(title)), lower(public.unaccent(@name))) > 0. Ordenar por lower(public.unaccent(title)) COLLATE "C" e UUID. Manter SQL estático e parâmetros. Calcular offset em 64 bits, consultar total e página de jogos antes das plataformas e montar o retorno na ordem da página. As leituras de uma resposta compartilham transação REPEATABLE READ. O adaptador pode usar SQL parametrizado pelas APIs do EF Core para LIMIT/OFFSET de 64 bits e EF para carregar as plataformas em lote.

## Alternativas consideradas

Foram avaliados LIKE com escape e normalização em coluna/aplicação. strpos preserva caracteres literais diretamente; unaccent aplica a comparação no banco e evita manter outra representação do título. Paginar joins de plataformas foi descartado por alterar totais e tamanho das páginas.

## Consequências

A consulta requer a extensão no banco. A implementação deve verificar Unicode, caixa, acentos e caracteres literais contra PostgreSQL. Não introduzir wrapper IMMUTABLE, índice especial ou promessa de capacidade sem medição. A transação estabiliza uma resposta; páginas de requisições diferentes podem refletir alterações posteriores. Referências: [unaccent](https://www.postgresql.org/docs/16/unaccent.html), [isolamento](https://www.postgresql.org/docs/16/transaction-iso.html) e [SQL pelo EF Core](https://learn.microsoft.com/en-us/ef/core/querying/sql-queries).

## Fontes afetadas

- [FEAT-006](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md) e [EP-002](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Arquitetura inicial](../drafts/arquitetura-inicial.md) e documento de trabalho da execução.
- Constituição, snapshot 0.28 e índices de ADRs, versões e specs.
