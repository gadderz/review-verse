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

Nenhuma pendência no recorte documental. As duas entregas foram aprovadas e
publicadas; PRs e merges aguardam resolver o acesso do conector GitHub.

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

No fechamento após as aprovações, os pushes das duas branches foram confirmados
por `git ls-remote`. Passaram 62 links locais nos seis arquivos de registro,
`git diff --check`, identidade do snapshot 0.31 e preservação do código, testes,
configuração, ADRs e versões. A criação do PR falhou com HTTP 403 da API GitHub;
merge não executado. Os resultados de acesso não alteram a validação documental
dos critérios acima.

## Aprovação final e integração no GitHub

- Aprovação da decisão: pedido do autor registrado no ADR-0030.
- Aprovação final desta entrega para integração: autor respondeu “feature
  aprovada” após a revisão do commit `f1388a3`, em 25/10/2026, nesta sessão.
- Origem: `feat/007-github-feature-close`; remoto `origin`; destino `main`,
  confirmado como branch padrão pelo GitHub.
- Base remota atualizada por `git fetch origin`: `279d51c` em 25/10/2026.
  A diferença inclui `5be4309` (FEAT-006) e `f1388a3` (FEAT-007).
- Push: executado em 25/10/2026 para `origin/feat/007-github-feature-close`;
  publicação inicial em `0c51abf`, com registros de retomada posteriores nesta
  mesma branch. A FEAT-006 também foi publicada em sua branch própria.
- PR, conflitos e merge: não executados para esta Feature. A consulta ao
  GitHub não encontrou PRs existentes; a criação do PR da dependência FEAT-006
  foi recusada pela API com HTTP 403, `Resource not accessible by integration`.
  Sem essa integração, não foi antecipado PR ou merge da FEAT-007.
- Dependência: a FEAT-006 ainda não está na base remota. Além da ancestralidade
  Git, a constituição 0.31 referencia os ADRs 0019 a 0029, incorporados pela
  FEAT-006. Publicar/integrar esta branch completa também incluiria essa entrega.
- Autorização da dependência: em 25/10/2026, o autor respondeu novamente
  “feature aprovada” à pergunta explícita sobre integrar a FEAT-006 (`5be4309`).
  Ambas as entregas estão autorizadas, sem necessidade de reconfirmação.
- Impedimento: o push SSH funciona, mas o conector não conseguiu criar PR.
  Não há `gh` nem configuração local desse cliente. É necessário corrigir o
  acesso da conexão GitHub ou disponibilizar um cliente autenticado com as
  permissões de criação e integração de PRs.
- Retomada: após resolver o acesso, atualizar a base, conferir PRs existentes,
  integrar primeiro a FEAT-006 e depois a FEAT-007 na main, preservando o
  recorte de cada PR e registrando os resultados reais. As aprovações seguem
  válidas; não é necessário pedi-las novamente.

## Próxima ação

Regra documental concluída e aprovada; branches publicadas. Resolver o acesso
de escrita do conector para concluir a etapa 7 das duas entregas autorizadas,
preservando o commit `5be4309` da FEAT-006 e registrando cada resultado remoto.

O documento de trabalho é preservado para eventual integração posterior.
Commit local da entrega: `f1388a3`,
`docs(jarvis): require GitHub integration after final approval`.
A publicação das branches está registrada acima; nenhum merge foi realizado.
