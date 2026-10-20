---
name: jarvis-review
description: "Revisar specs, planos ou implementações do ReviewVerse contra os critérios, ADRs e evidências do Jarvis, sem editar o trabalho revisado."
---

# Revisão com Jarvis

Leia [AGENTS.md](../../../AGENTS.md), a
[constituição](../../constitution.md), o [fluxo](../../workflow.md) e o
[índice de specs](../../../docs/specs/README.md). Identifique a raiz real do
repositório e o alvo pedido: uma spec, um plano, uma Feature, alterações locais
ou um intervalo de commits.

Siga o [contrato do Revisor](../../agents/reviewer.md), adotado no
[ADR-0018](../../../docs/adr/0018-contrato-do-revisor.md), para responsabilidades,
entregas e limites. Este arquivo descreve o procedimento de execução da skill.

## Reunir o contexto

Leia a Feature, seu Épico, os ADRs e as fontes pertinentes. Consulte o documento
de trabalho ativo quando existir e compare suas afirmações com o código e com
as verificações disponíveis. Se o pedido já identificar o alvo, não exija outro
formato de entrada para começar a revisão.

## Revisar

Compare critérios de aceitação, escopo, dependências, implementação e evidências.
Em specs, procure ambiguidades que alterem comportamento, requisitos sem fonte
e condições de conclusão que não possam ser verificadas. Em implementações,
verifique regras afetadas, contratos, limites entre módulos e regressões pertinentes.

Confira a política de testes e as exceções registradas. Execute verificações
pertinentes quando possível e diferencie o que passou, falhou ou não foi
executado. Não trate compilação, validação de formato ou uma tarefa marcada
como prova de um comportamento que essas verificações não cobrem.

Atue sem editar código, specs, índices, decisões ou configurações do projeto.
Não marque a Feature como concluída nem adote decisões como consequência da
revisão. Uma eventual implementação das correções segue o escopo autorizado
em outra etapa; este papel produz o relato de revisão.

## Relatar

Apresente achados por impacto, com localização, evidência e consequência.
Separe dúvidas de achados demonstrados. Evite apontamentos apenas de estilo
que não afetem os critérios ou o funcionamento. Se não houver achados, diga
isso e indique a cobertura e os limites reais da verificação.
