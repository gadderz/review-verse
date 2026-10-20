# ADR-0025 — Módulo inicial do Catálogo na API modular

Estado: Aceito
Versão da constituição: 0.26
Origem da autorização: pedido do autor para seguir ao planejamento da FEAT-006, após confirmar sua especificação; escolha técnica do Arquiteto dentro dessa autorização e dos artigos 4 e 7 da constituição. Não autoriza implementação nesta etapa.
Substitui: nenhum; detalha as decisões vigentes para a FEAT-006.
Substituído por: nenhum.

## Contexto

A arquitetura vigente exige uma API .NET modular, mas a árvore ainda contém dois hosts de exemplo. A FEAT-006 precisa de um limite de módulo sem reorganizar áreas que ainda não serão implementadas.

## Decisão

Usar ReviewVerse.Game.Catalog.API como host inicial e criar uma biblioteca ReviewVerse.Game.Catalog, com Domain, Application e Infrastructure organizados em pastas. Controller e contratos HTTP ficam no host; caso de uso, dados e registro de dependências ficam no módulo. O host chama contrato explícito de aplicação. Não introduzir um serviço HTTP independente ou acesso compartilhado às tabelas do Catálogo. O nome do host não define a organização final dos demais módulos.

## Alternativas consideradas

Foram avaliados manter tudo no host, criar um projeto por camada e separar um único módulo em biblioteca. A biblioteca mantém o limite sem exigir vários projetos novos ou refatorar Reviews nesta entrega.

## Consequências

O Backend terá um ponto explícito de composição e contratos de aplicação sem entidades EF no retorno HTTP. A API de Reviews e o Worker atuais continuam fora da execução desta Feature. A decisão detalha a base aprovada, sem comprovar migração já realizada.

## Fontes afetadas

- [FEAT-006](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md) e [EP-002](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Arquitetura inicial](../drafts/arquitetura-inicial.md) e documento de trabalho da execução.
- Constituição, snapshot 0.26 e índices de ADRs, versões e specs.
