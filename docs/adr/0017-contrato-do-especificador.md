# ADR-0017 — Contrato do Especificador

Estado: Aceito
Versão da constituição: 0.18
Origem da autorização: o autor respondeu “atende” à proposta de responsabilidades,
autonomia, entregas e passagem de trabalho do Especificador.
Substitui: nenhum; detalha a organização do ADR-0013.
Substituído por: nenhum.

## Contexto

A organização dos seis papéis foi adotada no
[ADR-0013](0013-arquitetura-e-planejamento-tecnico.md), com desenho e planejamento
técnico sob o Arquiteto. A skill `jarvis-spec` e o perfil `jarvis_spec` já existem.
Faltava revisar o contrato detalhado de especificação e sua passagem ao Arquiteto
e ao Coordenador, cujo contrato está no [ADR-0016](0016-contrato-do-coordenador.md).

## Decisão

Adotar o [contrato comum do Especificador](../../.jarvis/agents/specifier.md)
apresentado ao autor. O papel transforma necessidades em specs de Épicos e
Features com comportamento, limites, exclusões, dependências e critérios
verificáveis, reusando os recortes existentes quando pertinentes.

Mantém vínculos, conteúdo, progresso e pendências coerentes com decisões e
evidências, em alinhamento com a consolidação do Coordenador. Resolve organização
e redação dentro da intenção e autorização existentes. Usa as fontes vigentes
para esclarecer o que já foi decidido e leva ao autor dúvidas materiais ainda
abertas que alterem regras, escopo ou decisões confirmadas, mantendo trabalho
independente em andamento.

Entrega ao Arquiteto comportamento, critérios, dependências e dúvidas para o
desenho e o plano técnico. As tarefas da própria especificação e o contexto de
passagem ficam no documento de trabalho da execução. Não antecipa escolhas
técnicas ainda abertas nem transforma hipóteses em requisitos aceitos.

Critérios descrevem resultados observáveis. Evidências de implementação entram
na spec quando disponíveis; a spec pronta ou o estado Planejado não comprovam
entrega nem concedem autorização para implementar. Pedidos só de especificação
permanecem nesse escopo. O papel não amplia autorização para delegação ou ações
externas; decisões adotadas seguem o procedimento de ADRs e versões.

## Alternativas consideradas

Foi apresentada e aprovada uma proposta concreta de contrato do Especificador.
Não houve comparação adicional de alternativas nesta revisão; a hierarquia de
specs e a divisão do planejamento técnico já estavam adotadas.

## Consequências

O contrato passa a orientar a sessão e a skill e o perfil existentes de
especificação. O alinhamento das referências não comprova execução independente
do perfil. O contrato do Revisor e a configuração dos novos perfis especializados
continuam pendentes na FEAT-004.

## Fontes afetadas

- Contrato do Especificador, skill e perfil existentes, instruções, fluxo e guias.
- Constituição, arquivo da versão 0.18 e índices de decisões e versões.
- FEAT-004, seu documento de trabalho, EP-001 e índice de specs.
