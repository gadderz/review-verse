# FEAT-003 — Skills e perfis do Jarvis no Codex

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Concluído

## Necessidade e comportamento esperado

Disponibilizar a especificação e a revisão do Jarvis como skills locais e perfis
de agente do Codex. Os procedimentos devem consultar as mesmas regras e specs
do repositório, mantendo retomada, rastreabilidade e limites de autorização.

## Fontes e decisões

- [Constituição](../../../.jarvis/constitution.md).
- [Guia do Jarvis](../../../.jarvis/README.md).
- [ADR-0010 — Validação no Codex](../../adr/0010-validacao-inicial-no-codex.md), versão 0.11.
- [ADR-0011 — Skills e perfis](../../adr/0011-skills-comuns-e-perfis-locais.md), versão 0.12.
- Orientação do autor: testar somente no Codex nesta etapa; OpenCode aguarda
  configuração e Claude Code aguarda instalação.
- [Codex — skills](https://developers.openai.com/codex/skills).
- [Codex — agentes](https://developers.openai.com/codex/subagents).

## Escopo e dependências

Inclui `jarvis-spec`, `jarvis-review`, perfis de especificação e revisão e uma
validação local no Codex disponível. Implementação continua na sessão principal.
Não inclui instalar ferramentas, testar outros clientes nem executar subagentes
automaticamente. Os testes nas outras ferramentas permanecem no Épico EP-001.

## Critérios de aceitação

| ID | Resultado observável |
| --- | --- |
| AC-01 | As duas skills têm frontmatter válido, gatilhos específicos e referências acessíveis às regras e templates do Jarvis. |
| AC-02 | A skill de especificação organiza Épico, Feature e documento de trabalho, respeitando o escopo pedido e registrando dúvidas e decisões conforme as regras existentes. |
| AC-03 | A skill de revisão compara critérios, fontes e evidências e relata achados sem alterar automaticamente o trabalho revisado nem declarar como passado o que não foi verificado. |
| AC-04 | Perfis locais do Codex direcionam cada papel à skill correspondente, herdam modelo e permissões e não disparam delegação automática. |
| AC-05 | A descoberta das skills pelo Codex instalado é verificada; validação estrutural e exercício nesta sessão têm evidências registradas, com limites explícitos sobre testes independentes. |
| AC-06 | O estado de cada ferramenta é documentado; pendências do OpenCode e Claude Code não impedem a conclusão desta Feature do Codex. |

## O que já foi feito

- Lidas as instruções do projeto e as orientações oficiais de skills e agentes.
- Identificado o Codex CLI 0.163.0 disponível e o endpoint local `skills/list`.
- Registradas as decisões em ADR-0010 e ADR-0011, com versões 0.11 e 0.12.
- Preparadas as skills e os perfis; validador oficial e parser TOML passaram.
- Instalados quatro links locais de descoberta, sem instalação global.
- Descobertas as duas skills pelo Codex CLI com escopo `repo` e habilitadas.
- Aplicados os procedimentos nesta sessão e documentados os limites da verificação.
- Criado o [guia de integração e uso](../../../.jarvis/integrations/README.md).

## O que falta

Nenhuma pendência nos critérios desta etapa. Avaliação independente de agentes,
seleção automática e testes no OpenCode e Claude Code continuam como próximos
trabalhos do Épico, conforme o escopo que vier a ser definido.

## Evidências

| Critério | Resultado e evidência |
| --- | --- |
| AC-01 | Atendido: `quick_validate.py` oficial retornou `Skill is valid!` para as duas skills; frontmatter, metadados e referências locais conferidos. |
| AC-02 | Atendido no exercício desta sessão: `jarvis-spec` foi carregada explicitamente e aplicada à conferência da FEAT-003, seu Épico, plano, critérios e limites. O resultado é esta spec e o contexto consolidado; não houve implementação do produto. |
| AC-03 | Atendido no exercício desta sessão: `jarvis-review` foi carregada explicitamente para comparar critérios, arquivos e evidências. Não apontou inconsistências no recorte verificado; registrou limites de execução independente, sem editar o alvo durante a revisão. A consolidação posterior foi feita pela sessão principal. |
| AC-04 | Atendido estruturalmente: perfis TOML contêm somente nome, descrição e instruções que direcionam à skill, sem override de modelo ou permissões. A instrução do papel veda delegação automática. Não foi executado um subagente para comprovar seu comportamento em runtime. |
| AC-05 | Atendido: Codex CLI 0.163.0, handshake do app-server e `skills/list` com `forceReload` retornaram `jarvis-spec` e `jarvis-review` com `enabled: true` e `scope: repo`, nos caminhos comuns de `.jarvis/skills/`. Nenhum turno adicional foi iniciado. |
| AC-06 | Atendido: guia de integração distingue preparação, descoberta e execução. OpenCode e Claude Code estão explicitamente não testados; sua indisponibilidade não bloqueia esta Feature. |

### Limites e verificações complementares

- O exercício foi conduzido pela sessão principal com as skills carregadas
  explicitamente. Não é uma avaliação independente nem prova seleção automática.
- `config/read` não retornou uma lista de perfis nesta consulta. O formato e as
  referências foram verificados; não se afirma que agentes foram executados.
- Passaram links locais, `git diff --check`, sequência de ADRs e versões,
  identidade da cópia 0.12 e hashes dos registros anteriores.
- O validador usou PyYAML em diretório temporário; não foi adicionada dependência
  à aplicação. A descoberta precisou executar o servidor local fora do sandbox,
  com aprovação, sem criar tarefas ou enviar prompts a modelos adicionais.

Estas são mudanças de instruções e configuração do processo. A validação
documental e de integração não requer exceção à política de testes do produto.

## Próxima ação

Feature concluída. Usar as skills em uma tarefa concreta no Codex e retomar os
testes nos outros clientes quando estiverem disponíveis. As evidências e o guia
permitem continuar sem o documento temporário desta execução.
