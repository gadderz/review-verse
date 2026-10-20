# ADR-0014 — Contrato do Especialista Backend

Estado: Aceito
Versão da constituição: 0.15
Origem da autorização: o autor respondeu “atende” à proposta de responsabilidades,
autonomia, testes, entregas e passagem de trabalho do Especialista Backend.
Substitui: nenhum; detalha o ADR-0012 conforme a organização do ADR-0013.
Substituído por: nenhum.

## Contexto

Os especialistas Backend e Frontend foram adotados no
[ADR-0012](0012-especialistas-backend-frontend-e-arquitetura.md). A divisão com
Arquitetura e Planejamento foi confirmada no
[ADR-0013](0013-arquitetura-e-planejamento-tecnico.md). Faltava detalhar a atuação
do Backend, incluindo o Worker e a responsabilidade pelas verificações.

## Decisão

Adotar o [contrato comum Backend](../../.jarvis/agents/backend.md) apresentado
ao autor. O especialista implementa e verifica o servidor do recorte autorizado:
domínio, API .NET, persistência PostgreSQL, migrações, Worker, integrações e
integração com identidade e autorização, conforme a Feature.

Recebe critérios, contratos e plano técnico, contribui com o Arquiteto e detalha
suas tarefas. Tem autonomia para organização local do código, refatorações
pertinentes, tratamento de erros e testes dentro dos contratos. Mudanças de
contrato ou premissas técnicas exigem alinhamento com o Arquiteto e o Frontend
quando afetado. Alterações de escopo e decisões confirmadas seguem a constituição.

Escreve e executa testes da sua área e os cenários de integração atribuídos no
plano. Mantém regras e autorização na API e respeita os limites de dados dos
módulos. Entrega código, testes, migrações e configurações pertinentes, contratos
de consumo atualizados, progresso e evidências ao Revisor e ao Coordenador.

O Worker integra essa especialidade. Este contrato não escolhe frameworks de
persistência, testes ou agendamento e não amplia autorizações de execução ou
delegação. A conclusão do recorte Backend não conclui automaticamente a Feature.

## Alternativas consideradas

Foi apresentada e aprovada uma proposta concreta de contrato Backend. Não houve
comparação adicional de alternativas nesta revisão; a especialização e o papel
do Arquiteto já estavam definidos nos ADRs anteriores.

## Consequências

O contrato passa a orientar a atuação Backend na sessão principal e os futuros
adaptadores. Skill e perfil nativo próprios ainda precisam ser configurados e
verificados na FEAT-004. A aprovação do contrato não comprova sua execução em
outro agente nem a conclusão dos contratos dos demais papéis.

## Fontes afetadas

- Contrato Backend, instruções compartilhadas, fluxo e guias do Jarvis.
- Constituição, arquivo da versão 0.15 e índices de decisões e versões.
- FEAT-004, seu documento de trabalho, EP-001 e índice de specs.
