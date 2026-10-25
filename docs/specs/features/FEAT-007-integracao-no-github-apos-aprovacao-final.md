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

Nenhuma pendência no recorte documental. Aprovação final recebida; integração
remota depende de resolver a inclusão da FEAT-006, conforme a seção própria.

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
- Aprovação final desta entrega para integração: autor respondeu “feature
  aprovada” após a revisão do commit `f1388a3`, em 25/10/2026, nesta sessão.
- Origem: `feat/007-github-feature-close`; remoto `origin`; destino `main`,
  confirmado como branch padrão pelo GitHub.
- Base remota atualizada por `git fetch origin`: `279d51c` em 25/10/2026.
  A diferença inclui `5be4309` (FEAT-006) e `f1388a3` (FEAT-007).
- Push, PR, conflitos e merge: não executados nesta retomada. Consulta ao
  GitHub não encontrou PRs existentes para reutilizar.
- Dependência: a FEAT-006 ainda não está na base remota. Além da ancestralidade
  Git, a constituição 0.31 referencia os ADRs 0019 a 0029, incorporados pela
  FEAT-006. Publicar/integrar esta branch completa também incluiria essa entrega.
- Retomada: pergunta enviada ao autor sobre incluir a FEAT-006 na aprovação.
  A aprovação da FEAT-007 permanece válida, sem necessidade de reconfirmação.
  Com a dependência autorizada, executar a etapa 7 respeitando o recorte aprovado.

## Próxima ação

Regra documental concluída e aprovada. Resolver com o autor a inclusão da
FEAT-006 na integração, preservando sua entrega local `5be4309`, e executar a
etapa 7 quando o conjunto a integrar estiver autorizado.

O documento de trabalho é preservado para eventual integração posterior.
Commit local da entrega: `f1388a3`,
`docs(jarvis): require GitHub integration after final approval`.
Esse commit não comprova publicação remota.
