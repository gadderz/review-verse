# Trabalho — FEAT-008

Feature: [FEAT-008](../../../docs/specs/features/FEAT-008-manutencao-e-execucao-local-do-jarvis.md)
Épico: [EP-001](../../../docs/specs/epics/EP-001-jarvis.md)
Branch: `feat/008-jarvis-maintenance`
Estado: Em andamento

## Plano e tarefas

| Tarefa | Responsável | Dependência | Resultado e verificação |
| --- | --- | --- | --- |
| T-01 / AC-01 | Coordenador | Pedido explícito | Regra de commit do plano nas entradas, fluxo, Arquiteto e template; conferir diff e commit deste plano. |
| T-02 / AC-05 | Coordenador/Arquiteto | T-01 | Restringir ADRs a decisões relevantes e registrar evolução sem reescrever históricos; conferir referências e snapshots. |
| T-03 / AC-02 | Coordenador | T-02 | Skill de compactação, histórico por Épico e preservação de contratos; exercitar seleção em exemplos isolados. |
| T-04 / AC-03 e AC-04 | Backend na sessão principal | T-01 | Skills run/stop e auxiliar de processos/Compose; testar propriedade dos recursos, repetição, falha e parada em isolamento. |
| T-05 / AC-06 | Coordenador | T-02 a T-04 | Validadores de skills, scripts, links, histórico e git diff --check; consolidar limites na Feature. |

Plano: três skills comuns em `.jarvis/skills`, descoberta local em `.agents/skills`.
Execução gerenciada por Python 3 com estado/logs ignorados, sem segredos no estado;
Compose e processos identificados individualmente para preservar recursos alheios.
O Catálogo é o recorte funcional atual; serviços incompletos não serão simulados
como prontos. Compactação mantém contrato vigente e IDs em histórico por Épico.

## Progresso e retomada

- T-01 concluída: regra e plano inicial no commit `c1403d0` antes da implementação.
- T-02 concluída: ADR-0031/0.32 e ADR-0032/0.33, fontes e índices alinhados.
- T-03 concluída: skill cleanup com compactação por Épico, elegibilidade e
  proteção de contratos/referências imutáveis; nenhuma limpeza real executada.
- T-04 concluída: skills run/stop e auxiliar; oito testes de propriedade passaram.
  Startup real com migração/seed e --no-seed, HTTP 200, repetição e parada passaram.
- T-05 concluída: oito skills validadas e descobertas; 488 links em 79 documentos,
  histórico, snapshot e git diff --check passaram. Evidências na Feature.
- Próxima ação: revisão/aprovação final e integração da FEAT-008. Preservar plano
  enquanto houver contexto de fechamento; não executar limpeza do acervo sem pedido.
- Aprovação final, PR e merge: pendentes; autorização atual cobre implementação.
