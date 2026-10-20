# FEAT-005 — Revisão integrada da base Jarvis

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Concluído

## Necessidade e comportamento esperado

Revisar o Jarvis como conjunto antes do piloto de produto e verificar se a base
SDD está consistente para o uso inicial no Codex. Corrigir desalinhamentos com
decisões já adotadas e preparar somente os arquivos do Jarvis para commit na
branch `main`, conforme autorização explícita do autor.

## Fontes e decisões

- [Constituição 0.19](../../../.jarvis/constitution.md) e [fluxo](../../../.jarvis/workflow.md).
- [Contratos e integração](../../../.jarvis/integrations/README.md).
- [Índice de ADRs](../../adr/README.md), em especial ADRs 0004, 0006, 0013 e 0018.
- [FEAT-004](FEAT-004-contratos-dos-agentes.md), com as evidências e os limites da configuração.
- Pedido do autor: revisar a base antes de exercitá-la e fazer commit das alterações
  do Jarvis na `main` se estiver pronta.

## Escopo e dependências

Inclui constituição, ADRs e versões, hierarquia e ciclo das specs, templates,
contratos, skills, perfis, pontos de entrada, guias e o conjunto candidato ao
commit. A revisão é feita na mesma sessão que construiu a base e não é independente.

Correções alinham fontes às decisões vigentes; não introduzem novos princípios,
não reescrevem ADRs aceitos ou snapshots e não implementam o produto. Execução
independente dos perfis e testes no Claude Code/OpenCode permanecem pendentes
conforme o escopo já documentado no Épico.

## Critérios de aceitação

| ID | Resultado observável |
| --- | --- |
| AC-01 | Princípios, decisões, specs, templates, papéis e procedimentos foram confrontados e os achados têm evidência e resolução explícitas. |
| AC-02 | Correções preservam as decisões e versões aceitas e eliminam os desalinhamentos identificados. |
| AC-03 | Links, hierarquia, estados, YAML, TOML e descoberta das cinco skills no Codex têm resultados registrados; uma cópia isolada preserva os vínculos relativos da configuração. |
| AC-04 | O parecer distingue prontidão da base inicial de validação em produção, exercício independente de agentes e testes em outros clientes. |
| AC-05 | O conjunto candidato ao commit contém apenas alterações do Jarvis e sincronizações documentais relacionadas, com verificação de diferenças e mensagem em inglês no padrão Conventional Commits. |

## O que já foi feito

- Lidos princípios, fluxo, templates, ADRs, contratos, skills e perfis e comparados
  com as specs e o estado real do repositório.
- Concluída a fase de leitura e relato sem editar o alvo; correções e consolidação
  são executadas depois pela sessão principal, conforme a autorização existente.
- Identificados e resolvidos os três achados abaixo, sem alterar princípios ou registros aceitos.
- Verificados formatos, vínculos, estados, histórico, descoberta CLI e configuração
  em cópia isolada. A base passou no recorte de uso inicial no Codex.

## Achados e tratamento

| ID | Impacto e evidência | Tratamento |
| --- | --- | --- |
| R-01 | Médio: o fluxo e o ADR-0013 exigem responsáveis e dependências por tarefa, mas o template de trabalho omite esses campos. Isso facilita planos sem autoria e ordem de execução explícitas. | Resolvido: campos Responsável e Dependências adicionados conforme o fluxo vigente. |
| R-02 | Médio: contrato e ADR-0018 incluem revisão de planos, mas as descrições da skill e do perfil de revisão omitem esse alvo. A descoberta descreve um escopo mais estreito que o contrato. Não foi demonstrada falha de seleção automática. | Resolvido: descrição, entrada, metadados e perfil incluem planos; CLI retornou a descrição atualizada. A seleção automática continua sem avaliação comportamental. |
| R-03 | Baixo: AC-05 da FEAT-001 compara o snapshot 0.5 com a constituição “atual”, que agora é 0.19. O ADR-0001 também preserva uma consequência histórica sobre dispensa de nova spec, anterior ao ADR-0004. | Resolvido: critério vinculado ao texto adotado na versão 0.5; índice de ADRs esclarece a regra posterior sem alterar o ADR original. |

## O que falta

Nenhuma pendência na revisão de consistência e prontidão da base inicial.
Execução independente de perfis, seleção automática e testes no Claude Code e
OpenCode continuam no Épico e não foram apresentados como validados.

## Evidências

| Critério | Resultado e evidência |
| --- | --- |
| AC-01 | Passou: leitura cruzada de princípios, decisões, fluxo, templates, seis contratos, cinco skills e cinco perfis; achados R-01 a R-03 registrados acima. |
| AC-02 | Passou: fontes corrigidas conforme ADRs existentes; SHA-256 dos 18 ADRs e das 17 cópias preservado. Constituição 0.19 idêntica ao snapshot e princípios inalterados desde o encerramento da revisão inicial em 0.10. |
| AC-03 | Passou: links locais, hierarquia e estados das cinco Features, YAML, TOML e dez vínculos relativos conferidos. Validador oficial passou para as cinco skills; cópia isolada preservou configuração e referências dentro do repositório copiado. |
| AC-04 | Passou: parecer e guias distinguem prontidão estrutural, execução de agentes, seleção automática e outros clientes. Nenhum turno de modelo ou subagente foi iniciado. |
| AC-05 | Passou na preparação: diferenças revisadas e conjunto limitado aos arquivos do Jarvis e sincronizações documentais relacionadas; mensagem em inglês no padrão Conventional Commits e execução autorizada na main. |

O Codex CLI 0.163.0 retornou as cinco skills habilitadas com escopo `repo` e a
descrição atualizada de `jarvis-review`, incluindo planos. A consulta usou
`initialize`, `skills/list` com recarga forçada e `config/read`. A primeira
tentativa encerrou no ambiente restrito; a repetição aprovada fora do sandbox
passou, sem iniciar threads ou turnos de modelo.

Passaram `git diff --check` e conferências locais via Python de links, estados,
formatos, integridade e cópia isolada. Essa cópia foi criada em diretório
temporário com links relativos preservados e removida após a conferência.
O índice de versões preserva a ausência histórica documentada de 0.1 e 0.2.

## Parecer e limites

A base SDD está consistente para o uso inicial no Codex: escopo e critérios
vivem nas specs duradouras; desenho, tarefas, autoria e dependências vivem no
plano; decisões e versões são rastreáveis; conclusão exige evidências e
consolidação; contratos e pontos de entrada compartilham as mesmas fontes.
Os três achados foram resolvidos sem mudar os princípios aprovados.

A revisão foi feita na mesma sessão da construção. Não foi revisão independente,
piloto de produto ou avaliação comportamental dos perfis. Descoberta e formato
não comprovam comportamento dos agentes. Não foram executados testes .NET ou
Next.js porque não houve mudança no código executável do produto.

## Conjunto preparado para commit

Inclui `.jarvis/`, os dez links locais em `.agents/skills/` e `.codex/agents/`,
`AGENTS.md`, `CLAUDE.md`, ADRs, specs e integração em `docs/README.md`. Inclui
também a sincronização já aprovada do parágrafo de limites dos módulos em
`docs/drafts/arquitetura-inicial.md`, vinculada ao ADR-0007. Nenhum código da
aplicação ou configuração global foi alterado.

Mensagem: `feat(jarvis): add specification-driven development foundation`.
O commit é a etapa final autorizada após a conferência do índice na `main`.
Seu identificador permanente deve ser consultado no histórico Git desta Feature.

## Próxima ação

Após o commit do conjunto revisado na `main`, escolher com o autor a primeira
Feature de produto para o piloto do Jarvis.
