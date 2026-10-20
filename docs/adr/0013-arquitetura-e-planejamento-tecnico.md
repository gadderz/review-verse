# ADR-0013 — Arquitetura e planejamento técnico no mesmo agente

Estado: Aceito
Versão da constituição: 0.14
Origem da autorização: o autor aprovou a proposta de unir Arquitetura e
Planejamento técnico após discutir responsabilidades, benefícios e riscos.
Substitui: nenhum; complementa o ADR-0012.
Substituído por: nenhum.

## Contexto

O [ADR-0012](0012-especialistas-backend-frontend-e-arquitetura.md) introduziu os
especialistas Backend, Frontend e Arquiteto, deixando em aberto a relação com
o Planejador. A discussão comparou um agente dedicado a planejamento com a
concentração de desenho e planejamento técnico no Arquiteto.

## Decisão

O Arquiteto assume duas atividades explícitas: desenhar a solução técnica e
transformá-la em um plano executável. Não haverá um Planejador separado nesta
organização inicial. Os seis papéis são Coordenador, Especificador, Arquiteto,
Especialista Backend, Especialista Frontend e Revisor.

O Arquiteto define abordagem, limites, contratos, dados, integrações e tratamento
de falhas conforme a mudança. Estrutura o documento de trabalho da branch com
tarefas, dependências, responsáveis e estratégia de testes, incorporando as
contribuições dos especialistas.

Backend e Frontend detalham e ajustam as tarefas de suas áreas e escrevem e
executam os testes correspondentes. Escolhas rotineiras dentro dos contratos
não exigem novo parecer do Arquiteto. Mudanças de contratos ou premissas técnicas
exigem alinhamento entre os responsáveis; alterações de escopo ou de decisões
confirmadas seguem a constituição e a autoridade do autor.

O Coordenador acompanha andamento, dependências e impedimentos e consolida
resultados. O Revisor verifica a solução e as evidências e também pode revisar
o plano antes da implementação. Um plano pequeno pode reutilizar a arquitetura
vigente, sem criar uma etapa obrigatória de aprovação técnica para cada ajuste.

## Alternativas consideradas

- Arquiteto e Planejador separados: especializa a decomposição, mas adiciona
  passagem de contexto e alinhamento dos mesmos contratos e dependências.
- Arquiteto responsável também pelo planejamento técnico: mantém a relação
  entre decisões e execução, com menos passagens. Foi a opção adotada.

## Consequências

O Arquiteto pode concentrar trabalho ou detalhar tarefas excessivamente; o plano
deve ser proporcional e receber contribuições dos especialistas. A separação
futura pode ser reavaliada se o volume ou atrasos observados justificarem.

O contrato comum documenta a atuação em uma sessão. Ele não comprova descoberta
ou execução de novos perfis nas ferramentas. Configuração e testes dos perfis
especializados permanecem tarefas da FEAT-004, sem delegação automática.

## Fontes afetadas

- Contrato comum do Arquiteto, fluxo e guia do Jarvis.
- Skill e perfil existentes de especificação, para delimitar a passagem ao Arquiteto.
- Constituição, arquivo da versão 0.14 e índices de decisões e versões.
- FEAT-004, seu documento de trabalho, EP-001 e índice de specs.
