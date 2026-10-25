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

Nenhuma pendência no recorte documental. A dependência FEAT-006 já foi
integrada; resta integrar o PR #2 desta Feature e consolidar o resultado real.

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
merge não executado nessa tentativa. Na retomada com GitHub CLI autenticado,
a FEAT-006 foi integrada pelo PR #1 e o PR #2 desta Feature foi criado.
Os resultados de acesso não alteram a validação documental dos critérios acima.

Preparação do PR #2 após atualizar a base: passaram 227 links locais em
17 arquivos documentais, `git diff --check`, snapshot 0.31 idêntico e preservação
dos 57 ADRs/versões anteriores. Código, testes e configuração iguais à base
aprovada. A árvore do merge da FEAT-006 é idêntica à do commit `5be4309`.

## Aprovação final e integração no GitHub

- Aprovação da decisão: pedido do autor registrado no ADR-0030.
- Aprovação final desta entrega para integração: autor respondeu “feature
  aprovada” após a revisão do commit `f1388a3`, em 25/10/2026, nesta sessão.
- Origem: `feat/007-github-feature-close`; remoto `origin`; destino `main`,
  confirmado como branch padrão pelo GitHub.
- Base remota atualizada por `git fetch origin`: `13851ab` em 25/10/2026,
  após merge da FEAT-006. As diferenças restantes são documentais.
- Push: executado em 25/10/2026 para `origin/feat/007-github-feature-close`;
  publicação inicial em `0c51abf`, com registros de retomada posteriores nesta
  mesma branch. A FEAT-006 também foi publicada em sua branch própria.
- PR: [#2 — docs(jarvis): require GitHub integration after final approval](https://github.com/gadderz/review-verse/pull/2),
  criado pelo GitHub CLI autenticado; origem e destino conferidos acima.
- Conflitos e merge desta Feature: ainda não executados nesta retomada;
  conferir o estado e as exigências do PR antes de integrar.
- Dependência atendida: FEAT-006 integrada pelo
  [PR #1](https://github.com/gadderz/review-verse/pull/1), merge `13851ab`,
  preservando o commit `5be4309` e os ADRs 0019 a 0029 na base remota.
- Autorização da dependência: em 25/10/2026, o autor respondeu novamente
  “feature aprovada” à pergunta explícita sobre integrar a FEAT-006 (`5be4309`).
  Ambas as entregas estão autorizadas, sem necessidade de reconfirmação.
- Impedimento anterior superado: o conector retornava HTTP 403; o autor
  instalou e autenticou o GitHub CLI. Acesso de gadderz ao repositório e criação
  de ambos os PRs confirmados; nenhuma permissão remota foi alterada pelo agente.
- Retomada: conferir o PR #2 atualizado, suas exigências e o commit exato;
  integrar e consolidar o resultado remoto. As aprovações seguem válidas.

## Próxima ação

Regra documental concluída e aprovada; FEAT-006 integrada. Concluir a etapa 7
pelo PR #2 e consolidar seu resultado remoto antes de encerrar o documento de
trabalho.

O documento de trabalho é preservado para eventual integração posterior.
Commit local da entrega: `f1388a3`,
`docs(jarvis): require GitHub integration after final approval`.
A publicação das branches e o merge da dependência estão registrados acima;
o merge desta Feature ainda não foi realizado.
