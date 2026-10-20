# Especificações do ReviewVerse

Toda mudança possui spec na hierarquia Épico → Feature → tarefas do documento
de trabalho. A decisão está no
[ADR-0004](../adr/0004-especificacoes-hierarquicas-e-documento-de-trabalho.md) e
no artigo 2 da [constituição](../../.jarvis/constitution.md).

## Índice de Épicos

| Épico | Estado | O que foi feito e o que falta |
| --- | --- | --- |
| [EP-001 — Jarvis](epics/EP-001-jarvis.md) | Em andamento | Constituição e skills locais do Codex disponíveis; testes nos outros clientes pendentes. |

## Índice de Features

| Feature | Épico | Estado | O que foi feito e o que falta |
| --- | --- | --- | --- |
| [FEAT-001 — Especificações hierárquicas](features/FEAT-001-especificacoes-hierarquicas.md) | EP-001 | Concluído | Modelo, templates e fluxo aplicados; evidências consolidadas na Feature, sem pendências neste recorte. |
| [FEAT-002 — Revisão da constituição](features/FEAT-002-revisao-da-constituicao.md) | EP-001 | Concluído | Revisão inicial concluída na versão 0.10; decisões, versões e evidências consolidadas. |
| [FEAT-003 — Skills e perfis no Codex](features/FEAT-003-skills-e-perfis-no-codex.md) | EP-001 | Concluído | Skills descobertas pelo CLI e perfis conferidos estruturalmente; guia e limites registrados. |
| [FEAT-004 — Contratos dos agentes](features/FEAT-004-contratos-dos-agentes.md) | EP-001 | Concluído | Seis contratos adotados; cinco skills descobertas no Codex e cinco perfis conferidos estruturalmente. Evidências e limites consolidados. |
| [FEAT-005 — Revisão integrada](features/FEAT-005-revisao-integrada-do-jarvis.md) | EP-001 | Concluído | Três desalinhamentos corrigidos; integridade, formatos, descoberta e cópia isolada conferidos. Base inicial pronta para commit e piloto no Codex, com limites registrados. |

Os Épicos e Features de produto, incluindo Catálogo de Jogos, ainda serão
especificados conforme o trabalho for iniciado. A base de produto existente
permanece na visão, na arquitetura e no roteiro da POC.

## Arquivos e vínculos

| Nível | Local | Conteúdo |
| --- | --- | --- |
| Épico | `docs/specs/epics/EP-NNN-nome.md` | Objetivo, escopo, condições de conclusão, Features e progresso. |
| Feature | `docs/specs/features/FEAT-NNN-nome.md` | Épico pai, comportamento, critérios, dependências, resultados e evidências. |
| Trabalho da branch | `.jarvis/work/<feature-id>/<identificador-da-branch>.md` | Feature e branch reais, plano técnico, specs das tarefas, progresso e retomada. |

Usar números sequenciais próprios para Épicos e Features, sem reutilizar IDs.
A Feature mantém seu identificador ao longo de correções e branches posteriores.
O Épico lista suas Features com links; cada Feature aponta para seu Épico.
Manter o índice e as specs coerentes a cada mudança de progresso.

Usar os templates de [Épico](../../.jarvis/templates/epic.md),
[Feature](../../.jarvis/templates/feature.md) e
[trabalho](../../.jarvis/templates/work.md). Criar somente registros com escopo
identificado. Uma tarefa pequena pode reusar as specs existentes; tudo continua
especificado, sem criar um novo Épico ou Feature para cada edição.

## Estados

| Estado | Significado |
| --- | --- |
| Rascunho | Escopo ou critérios ainda em definição. |
| Planejado | Escopo e critérios definidos; trabalho ainda não iniciado. |
| Em andamento | Há execução ou verificação em curso. |
| Bloqueado | Um impedimento registrado impede o avanço do recorte atual. |
| Concluído | Condições de conclusão atendidas e resultados consolidados. |

Registrar a causa, o que falta resolver e a próxima ação quando houver bloqueio.
O estado não comprova autorização nem substitui evidência. Uma Feature exige
seus critérios atendidos; um Épico exige suas condições e Features concluídas ou
retiradas do escopo por decisão registrada. Preservar vínculos das Features
retiradas e o ADR correspondente. Não inferir conclusão pelo encerramento da branch.

## Ciclo do documento de trabalho

O documento pertence à execução de uma Feature em uma branch, é versionável
enquanto ativo e pode conter todas as tarefas menores. A cada tarefa, registrar
resultado esperado e verificação; a cada interrupção, deixar contexto de retomada.

Antes de removê-lo, transferir resultados, evidências e pendências para a Feature,
atualizar o Épico e preservar decisões em ADRs. Não deixar links duradouros para
um arquivo que será removido. Se outra branch continuar a execução, transferir
o contexto pendente e conferir que possa ser retomado antes de encerrar o plano.

O fechamento de um documento não encerra necessariamente a Feature. Correções
posteriores podem abrir outro documento ligado à mesma spec. O procedimento
completo está no [fluxo do Jarvis](../../.jarvis/workflow.md).
