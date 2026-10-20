# ADR-0016 — Contrato do Coordenador

Estado: Aceito
Versão da constituição: 0.17
Origem da autorização: o autor respondeu “atende” à proposta de responsabilidades,
autonomia, entregas e passagem de trabalho do Coordenador.
Substitui: nenhum; detalha a organização do ADR-0013.
Substituído por: nenhum.

## Contexto

O [ADR-0013](0013-arquitetura-e-planejamento-tecnico.md) definiu seis papéis e
concentrou desenho e planejamento técnico no Arquiteto. Os contratos Backend e
Frontend foram adotados nos [ADRs 0014](0014-contrato-do-especialista-backend.md)
e [0015](0015-contrato-do-especialista-frontend.md). Faltava detalhar a coordenação
do conjunto, sua responsabilidade pelo progresso e seus limites de autoridade.

## Decisão

Adotar o [contrato comum do Coordenador](../../.jarvis/agents/coordinator.md)
apresentado ao autor. O Coordenador atua na sessão principal, conecta pedido,
especificação, planejamento, execução, revisão e consolidação e mantém estado
real, responsáveis, dependências, impedimentos e próxima ação explícitos.

Organiza a passagem entre papéis e acompanha o trabalho, preservando a autoria
técnica do Arquiteto e dos especialistas e a função de verificação do Revisor.
Consolida resultados, critérios atendidos e pendências na Feature, no Épico e
nos índices, com base nas tarefas e evidências realmente produzidas.

Executa a coordenação e as ações já autorizadas sem reconfirmação a cada etapa.
O fluxo é proporcional: uma sessão pode assumir papéis distintos e uma tarefa
pequena não precisa acionar todos separadamente. Delegação depende de autorização
e suporte do ambiente; troca de papel não equivale a revisão independente.

Garante que decisões adotadas tenham ADR, versão e fontes atualizadas, sem
atribuir adoção a propostas. Mudanças técnicas são alinhadas entre os responsáveis;
dúvidas materiais de regras, escopo ou decisões confirmadas retornam ao autor
quando as fontes vigentes não as resolverem.

Conclui a entrega somente com critérios e evidências conforme a constituição.
Preserva o contexto de retomada e consolida ou transfere as informações antes
de remover o plano temporário. Não amplia o escopo nem as permissões existentes.

## Alternativas consideradas

Foi apresentada e aprovada uma proposta concreta de contrato do Coordenador.
Não houve comparação adicional de alternativas nesta revisão; sua posição
na sessão principal e a divisão técnica já integravam a proposta discutida.

## Consequências

O contrato orienta a coordenação na sessão principal, sem exigir skill ou perfil
nativo separado. Contratos detalhados de Especificador e Revisor e configuração
dos novos perfis especializados permanecem pendentes na FEAT-004. A aprovação
deste contrato não comprova execução de subagentes ou conclusão da Feature.

## Fontes afetadas

- Contrato do Coordenador, instruções compartilhadas, fluxo e guias do Jarvis.
- Constituição, arquivo da versão 0.17 e índices de decisões e versões.
- FEAT-004, seu documento de trabalho, EP-001 e índice de specs.
