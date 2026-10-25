---
name: jarvis-spec
description: Criar ou detalhar specs de Épicos e Features do ReviewVerse com necessidade, escopo, critérios, dependências e progresso no Jarvis.
---

# Especificação com Jarvis

Leia [AGENTS.md](../../../AGENTS.md), a
[constituição](../../constitution.md), o [fluxo](../../workflow.md) e o
[índice de specs](../../../docs/specs/README.md). Identifique a raiz real do
repositório antes de resolver caminhos ou executar comandos.

Siga o [contrato do Especificador](../../agents/specifier.md), adotado no
[ADR-0017](../../../docs/adr/0017-contrato-do-especificador.md), para responsabilidades,
entregas e limites. Este arquivo descreve o procedimento de execução da skill.

## Preparar a especificação

Identifique o resultado pedido: discutir uma ideia, especificar, planejar ou
implementar. Especificar e planejar não autorizam iniciar código do produto.
Consulte as regras de produto, arquitetura e ADRs pertinentes, distinguindo
decisões confirmadas, propostas e estado implementado.

Localize o Épico e a Feature existentes. Reuse-os quando cobrirem o pedido;
caso contrário, use os templates de [Épico](../../templates/epic.md) e
[Feature](../../templates/feature.md), com o próximo identificador livre.
Mantenha os vínculos entre pai e filha e o índice coerentes.

Defina necessidade, escopo, critérios observáveis, dependências e dúvidas.
Não transforme exemplos em entregas aprovadas. Discuta dúvidas que mudem
comportamento ou escopo e continue o detalhamento independente delas.

## Documento de trabalho e passagem ao Arquiteto

Confira a branch real e mantenha no documento de trabalho as tarefas da própria
especificação, resultados esperados, verificações e contexto de retomada,
conforme o [template](../../templates/work.md). A passagem ao Arquiteto reutiliza
esse documento na mesma execução da Feature.

Entregue comportamento, critérios verificáveis, dependências e dúvidas abertas.
O desenho e o plano técnico de implementação pertencem ao
[Arquiteto](../../agents/architect.md), conforme o
[ADR-0013](../../../docs/adr/0013-arquitetura-e-planejamento-tecnico.md).
Um pedido só de plano técnico deve seguir esse contrato, sem iniciar outros
agentes automaticamente. Uma sessão pode assumir o papel correspondente.

Mantenha o comportamento duradouro na Feature e a estratégia técnica no plano.
Registre decisões relevantes conforme o
[procedimento de ADRs](../../../docs/adr/README.md), sem atribuir aceitação a
uma hipótese ou à simples criação de um arquivo.

## Entregar

Confira referências, estados e pendências. Informe quais specs foram criadas ou
atualizadas, o que já está definido, o que falta e a próxima ação. Não marque
conclusão de implementação com base apenas no plano. Preserve o documento de
trabalho enquanto houver contexto pendente e siga a consolidação do fluxo ao encerrá-lo.
