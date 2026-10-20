# ADR-0004 — Especificações hierárquicas e documento de trabalho

Estado: Aceito
Versão da constituição: 0.5
Origem da autorização: confirmação explícita do autor para adotar Épicos,
Features e specs próximas da execução no documento de trabalho.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

O fluxo inicial previa uma spec por mudança, reunindo resultado, plano técnico,
tarefas e evidências. O autor propôs organizar o trabalho em Épicos e Features,
com especificações permanentes e detalhamento temporário nas branches de Feature.
Foi recomendada a consolidação dos resultados antes de encerrar esse detalhamento.

## Decisão

Toda mudança tem especificação na hierarquia Épico → Feature → tarefas do
documento de trabalho. Specs de Épicos e Features são duradouras e mantêm estado,
o que foi feito e o que falta para concluir. Cada Feature referencia seu Épico,
e cada Épico relaciona as Features que compõem seu escopo.

O Épico descreve objetivo, escopo, limites e condições de conclusão. A Feature
descreve comportamento, critérios de aceitação e dependências. O plano técnico
e as especificações das tarefas menores ficam em um documento de trabalho por
branch que executa a Feature, vinculado à spec duradoura.

O documento de trabalho é temporário no ciclo de execução, mas versionado
enquanto ativo para permitir retomada. Antes de removê-lo, consolidar resultados,
pendências e evidências na Feature, atualizar o Épico e preservar decisões em ADRs.
Não remover um documento com execução pendente sem transferir seu contexto.

Usar os estados Rascunho, Planejado, Em andamento, Bloqueado e Concluído. Uma
Feature exige critérios atendidos e evidências; o Épico exige suas condições de
conclusão e Features concluídas ou retiradas do escopo por decisão registrada.
Correções posteriores podem reusar a Feature e abrir outro documento de trabalho.

## Alternativas consideradas

- Manter a spec independente por mudança, com plano e tarefas no mesmo arquivo.
- Manter permanentemente todo o detalhamento técnico de execução nas Features.

Foi adotada a hierarquia com detalhamento de execução temporário, preservando
as informações duradouras antes de encerrar o documento de trabalho.

## Consequências

Toda execução precisa ter vínculo com uma Feature e um Épico, inclusive ajustes
pequenos que reutilizem specs existentes. O progresso permanente pode ser lido
sem abrir a branch; outra sessão retoma o detalhe ativo pelo documento de trabalho.

O encerramento exige consolidação para evitar perda de contexto. A definição de
Features e Épicos de produto continua a depender de seu escopo real; o exemplo
do Catálogo de Jogos não aprova automaticamente uma lista de entregas.

## Fontes afetadas

- Artigo 2 e histórico da constituição, na versão 0.5.
- Fluxo, guia e templates de Épico, Feature e documento de trabalho do Jarvis.
- Índices de specs, ADRs e versões e instruções compartilhadas.
