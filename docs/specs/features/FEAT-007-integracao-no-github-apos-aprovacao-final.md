# FEAT-007 — Integração no GitHub após aprovação final

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Concluído

## Necessidade e comportamento esperado

Tornar push, merge no GitHub e resolução de conflitos parte padrão do fechamento
de uma Feature depois da aprovação final do autor. O Coordenador executa a
integração autorizada, preserva contribuições e registra o resultado real,
sem depender de nova instrução para cada comando.

Pedido confirmado em 25/10/2026. A autorização para registrar a regra não é
aprovação automática para publicar ou integrar a FEAT-006 ou outra entrega.

## Fontes e decisões

- [ADR-0030](../../adr/0030-integracao-no-github-apos-aprovacao-final.md),
  constituição 0.31: integração após aprovação final.
- [Fluxo](../../../.jarvis/workflow.md), etapa 7.
- [Coordenador](../../../.jarvis/agents/coordinator.md).
- [FEAT-001](FEAT-001-especificacoes-hierarquicas.md): consolidação e retomada.

## Escopo e dependências

Inclui regra na constituição, fluxo, Coordenador, instruções de entrada, guia,
templates e índices. Registra aprovação e integração em campos próprios, sem
criar estados adicionais ou redefinir critérios do produto.

Não inclui implementar automação executável ou alterar proteções do GitHub.
A execução futura exige acesso ao remoto e cumprimento de suas regras.
Não exige cliente específico e não inclui push/merge sem aprovação final.

## Critérios de aceitação

| ID | Resultado observável |
| --- | --- |
| AC-01 | Constituição, fluxo e Coordenador exigem push e merge no GitHub após aprovação final explícita e reutilizam a autorização concedida sem confirmação por comando. |
| AC-02 | O fluxo define atualização da base, resolução de conflitos preservando contribuições, revalidação das áreas afetadas e retorno ao autor quando houver mudança material de comportamento/escopo. |
| AC-03 | Templates e instruções distinguem entrega técnica, aprovação e integração; registram branches, PR, commits, conflitos, resultado remoto e retomada de impedimentos sem antecipar sucesso. |
| AC-04 | ADR-0030, constituição 0.31, snapshot e índices estão coerentes, preservando registros anteriores. |
| AC-05 | Links e `git diff --check` passam; cenários sem aprovação, aprovado, conflito e impedimento são confrontados com as instruções. A verificação documental não é apresentada como integração remota executada. |

## O que já foi feito

- Regra adotada no ADR-0030 e incorporada nas fontes do processo.
- Campos de aprovação e integração adicionados aos templates.
- Branch documental `feat/007-github-feature-close` criada a partir da entrega
  local da FEAT-006; seu commit 5be4309 não foi modificado.

## O que falta

Nenhuma pendência no recorte documental. Aprovação final e integração remota
continuam com seu estado real na seção própria, sem integração presumida.

## Evidências

| Critério | Verificação | Resultado |
| --- | --- | --- |
| AC-01 | Constituição, fluxo, Coordenador e AGENTS.md. | Passou: gate explícito e execução de push/merge sem reconfirmar ações já aprovadas. |
| AC-02 | Conflito técnico, mudança material e checks impedidos. | Passou na revisão documental: preservar contribuições, revalidar, consultar autor em mudança material e registrar impedimentos. |
| AC-03 | Campos dos templates e retomada. | Passou: aprovação, origem/destino, PR, commits, conflitos e resultado remoto explícitos; retomada preservada. |
| AC-04 | Integridade dos registros e snapshot 0.31. | Passou: constituição idêntica ao snapshot; 57 ADRs/versões anteriores comparados ao HEAD e preservados. |
| AC-05 | Links, estados, cenários e `git diff --check`. | Passou: 16 arquivos documentais, 219 links locais, tabelas e diferenças conferidos, incluindo arquivos novos. |

Mudança documental. Build e testes .NET não se aplicam; não há exceção à política
de testes de negócio. Push, PR e merge não foram executados como teste da regra.

## Aprovação final e integração no GitHub

- Aprovação da decisão: pedido do autor registrado no ADR-0030.
- Aprovação final desta entrega para integração: ainda não registrada.
- Origem: `feat/007-github-feature-close`; remoto `origin`; destino a conferir.
- Push, PR, conflitos e merge: não executados nesta etapa documental.
- Retomada: após aprovação final, conferir a base remota e executar a etapa 7.

## Próxima ação

Regra documental concluída. Quando uma entrega receber aprovação final, executar
sua integração conforme a etapa 7. Para FEAT-006, o autor foi consultado sobre
aprovar agora o commit 5be4309; não houve resposta de aprovação nesta etapa.
Para publicar esta FEAT-007, registrar sua própria aprovação final e conferir
as diferenças da branch; ela deriva da entrega local FEAT-006.

O documento de trabalho é preservado para eventual integração posterior.
Commit local preparado em inglês: `docs(jarvis): require GitHub integration after final approval`.
Consultar o histórico da branch para seu identificador; não confundir esse commit
com publicação remota.
