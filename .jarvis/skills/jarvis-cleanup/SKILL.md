---
name: jarvis-cleanup
description: "Compactar a documentação de Features encerradas do ReviewVerse em histórico mínimo por Épico, preservando contratos, evidências e recuperação pelo Git."
---

# Compactação documental

Leia [AGENTS.md](../../../AGENTS.md), artigo 2 da
[constituição](../../constitution.md), [índice de specs](../../../docs/specs/README.md)
e [ADR-0032](../../../docs/adr/0032-compactacao-de-features-encerradas.md).
Identifique o conjunto pedido. Um pedido de diagnóstico/simulação não autoriza
remoção; um pedido de limpeza autoriza aplicar a compactação elegível nesse escopo.

## Elegibilidade

Conferir spec, Épico e evidências de aprovação final e merge, inclusive no GitHub
quando disponível. Só compactar Features Concluídas, aprovadas e integradas, sem
critérios, achados, entrega ou integração pendentes. Não deduzir aprovação pelo
estado. Se não for possível verificar, relatar como pendente, sem remover.
Dependências futuras não impedem compactar uma entrega completa, mas seus
contratos/regras precisam continuar acessíveis. Não usar idade como critério.

## Compactar

1. Identificar documentos redundantes da Feature, referências de entrada e regras
   que ainda só existem neles. Conferir histórico Git antes de remover: arquivos
   não commitados ficam fora da remoção. Não há limpeza por glob ou por pasta inteira.
2. Preservar regras/contratos vigentes no guia apropriado ou no próprio resumo.
   Não transformar requisito em mera referência a um commit antigo.
3. Consolidar em `docs/specs/history/EP-NNN.md`, uma seção `## FEAT-NNN — nome`
   por Feature, com âncora `feat-nnn` explícita. Guardar ID, Épico, resultado e
   critérios entregues, fontes atuais dos contratos, decisões relevantes,
   evidências/limites/exceções, aprovação, PR/SHA integrado e SHA do documento
   original (`git show <sha>:<caminho>`). Nunca apagar pendências para torná-la elegível.
4. Atualizar Épico, índice e os links editáveis para a entrada consolidada.
   Se houver referência em ADR/snapshot imutável, manter no caminho original
   uma ficha mínima com ID, resultado e link canônico, em vez de alterar a
   decisão histórica ou quebrar a navegação. Relatar esses arquivos preservados.
   Verificar referências antes de remover somente documentos redundantes sem
   referências pendentes. Repetir links e `git diff --check`.
5. Relatar arquivos eliminados, histórico preservado, exclusões e verificação.
   Reabrir uma Feature compactada mantendo o ID e criando novo plano quando necessário.

Manter ADRs, snapshots, constituição, Épicos, contratos dos agentes, skills,
guias operacionais e specs ativas. Não reescrever o histórico Git nem fazer
push/merge como consequência implícita da limpeza. Criar o arquivo por Épico
somente quando houver entrada; a skill não exige uma nova spec por arquivo limpo.
