# ADR-0032 — Compactação de Features encerradas

Estado: Aceito
Versão da constituição: 0.33
Origem da autorização: pedido do autor em 25/10/2026 para criar uma skill de
limpeza, com critério recomendado pelo agente e histórico mínimo recuperável.
Substitui: nenhum; complementa o ciclo documental do ADR-0004.
Substituído por: nenhum.

## Decisão e motivo

Compactar somente Features concluídas, aprovadas e integradas, sem pendências
de entrega, revisão ou integração. Não usar prazo de retenção arbitrário.
Agrupar resumos em `docs/specs/history/EP-NNN.md`, com âncora por Feature.
Manter specs detalhadas enquanto houver contexto ativo; o Épico permanece.

Cada resumo preserva ID/nome, Épico, comportamento e critérios entregues,
fontes atuais dos contratos/regras, decisões relevantes, evidências e limites,
aprovação, PR e SHA integrado/origem para recuperar o documento original no Git.
Regras sem outra fonte precisam ser mantidas no resumo ou promovidas ao guia
adequado antes de remover a spec detalhada. Atualizar os links editáveis; quando
um registro imutável ainda aponta ao caminho antigo, manter ali uma ficha mínima
com link ao histórico consolidado. Não reescrever ADRs ou snapshots para limpar specs.

## Consequências

Reduz arquivos ativos sem depender apenas da conversa. Não apagar ADRs, versões
da constituição, guias operacionais ou contexto pendente. A skill é criada agora;
nenhuma Feature existente é compactada sem um pedido de limpeza.
Alternativas: mover tudo para outra pasta não reduz arquivos; apagar apenas por
idade perde contexto; manter cada spec para sempre mantém o crescimento atual.
Fontes: artigo 2, fluxo, índice de specs e skill jarvis-cleanup.
Execução: [FEAT-008](../specs/features/FEAT-008-manutencao-e-execucao-local-do-jarvis.md).
