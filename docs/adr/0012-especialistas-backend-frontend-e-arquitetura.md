# ADR-0012 — Especialistas em Backend, Frontend e Arquitetura

Estado: Aceito
Versão da constituição: 0.13
Origem da autorização: pedido explícito do autor para especializar o Implementador
em Backend e Frontend e incluir um Arquiteto especialista.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A proposta inicial de papéis da FEAT-004 tinha um Implementador genérico e um
Planejador. O autor solicitou especializações para a implementação e a inclusão
de um especialista em Arquitetura.

## Decisão

O desenho dos agentes do Jarvis terá especialistas em Backend e Frontend no
lugar do Implementador genérico e incluirá um Arquiteto especialista.
Os contratos detalhados, a passagem de trabalho e a configuração serão
definidos na FEAT-004.

A proposta de o Arquiteto assumir também o planejamento técnico permanece em
discussão. Esta decisão não adota essa união nem define o número final de papéis.

## Alternativas consideradas

- Proposta inicial com Implementador genérico e Planejador.
- Especializar a implementação em Backend e Frontend e incluir Arquitetura,
  conforme solicitado pelo autor.

## Consequências

Os contratos precisam explicitar os limites entre as especialidades, a
responsabilidade por testes e a coordenação das entregas que atravessam API e
interface. A adoção dos papéis não comprova que seus perfis estejam configurados
ou testados e não inicia delegação automática.

## Fontes afetadas

- Histórico da constituição e arquivo da versão 0.13.
- FEAT-004, documento de trabalho e índices de acompanhamento do Jarvis.
