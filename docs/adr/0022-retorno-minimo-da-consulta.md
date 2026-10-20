# ADR-0022 — Retorno mínimo da primeira consulta de jogos

Estado: Aceito
Versão da constituição: 0.23
Origem da autorização: O autor confirmou que o recorte proposto para o retorno atende, incluindo o adiamento de títulos traduzidos e nomes alternativos.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

Os metadados completos e a apresentação localizada fazem parte do catálogo da POC. Para a primeira API, foi proposto um retorno reduzido que permite identificar jogos e plataformas.

## Decisão

Cada resultado da FEAT-006 contém identificador estável do jogo no produto, título original e plataformas disponíveis, com identificadores e nomes. Um jogo aparece uma única vez com suas plataformas sem repetição; jogos homônimos distintos mantêm identificadores distintos. Capa, títulos traduzidos, pesquisa em nomes alternativos e demais metadados ficam para evolução. A apresentação localizada com traduções disponíveis e fallback continua obrigatória no Épico e na POC.

## Alternativas consideradas

Foram oferecidos o recorte mínimo recomendado, inclusão de capa e inclusão de títulos traduzidos já nesta Feature. O autor aprovou o recorte recomendado.

## Consequências

A primeira API não conclui detalhes do jogo nem interface localizada. Os critérios verificam agregação e identidade; tipos e nomes de campos pertencem ao futuro contrato técnico. A fonte IGDB e suas traduções continuam no escopo das Features posteriores.

## Fontes afetadas

- [FEAT-006 — Consulta de jogos por nome pela API](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md).
- [EP-002 — Catálogo de Jogos](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Visão do projeto](../drafts/visao-do-projeto.md) e [arquitetura inicial](../drafts/arquitetura-inicial.md).
- Constituição, cópia da versão 0.23, índices de decisões, versões e specs.
