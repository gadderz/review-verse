# ADR-0006 — Fontes, decisões e tratamento de conflitos

Estado: Aceito
Versão da constituição: 0.7
Origem da autorização: o autor confirmou a redação proposta para o artigo 3
e pediu a próxima revisão.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A base já distinguia decisões, propostas e implementação, e as decisões passaram
a ser registradas em ADRs. Faltava explicitar a responsabilidade de cada fonte
e diferenciar uma documentação desatualizada de uma dúvida sobre a intenção do autor.

## Decisão

Identificar propostas, decisões adotadas, implementação observada e resultados
verificados. Usar constituição, ADRs, visão, arquitetura, specs e documento de
trabalho conforme suas responsabilidades, e código e verificações como evidência
do que está implementado e validado.

Registrar decisões tomadas na conversa em ADRs e fontes afetadas antes de
orientar a execução, respeitando a autorização existente. Preservar o histórico
e os vínculos de substituição; uma spec não altera silenciosamente uma decisão vigente.

Em caso de contradição, consultar as decisões vigentes. Atualizar uma fonte
desatualizada quando a decisão já resolver o conflito; se a intenção permanecer
ambígua, apresentar a questão ao autor antes de implementar o comportamento
afetado e continuar o trabalho independente.

## Alternativas consideradas

- Manter a redação inicial com uma orientação geral de expor contradições.
- Explicitar a responsabilidade das fontes e distinguir atualização documental
  de ambiguidade que exige discussão com o autor.

O autor confirmou a segunda redação apresentada.

## Consequências

O agente pode corrigir documentos desatualizados com base em decisões já tomadas,
sem tratar essa correção como uma decisão nova. Dúvidas sobre a intenção continuam
sendo discutidas antes de afetar a implementação.

Decisões e evidências precisam sobreviver à conversa e permitir retomada por outra
sessão ou ferramenta. Essa decisão não redefine a arquitetura nem comprova a
implementação do produto.

## Fontes afetadas

- Artigo 3 e histórico da constituição, na versão 0.7.
- FEAT-002, Épico EP-001 e índices de ADRs, specs e versões.
