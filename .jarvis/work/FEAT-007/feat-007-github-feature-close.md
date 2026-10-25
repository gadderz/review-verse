# Trabalho — FEAT-007 — Padrão de integração no GitHub

Feature: [FEAT-007](../../../docs/specs/features/FEAT-007-integracao-no-github-apos-aprovacao-final.md)
Épico: [EP-001](../../../docs/specs/epics/EP-001-jarvis.md)
Branch: `feat/007-github-feature-close`
Estado: Em andamento

## Objetivo e plano

Registrar aprovação final → push → PR/merge no GitHub, incluindo conflitos e
validação. Esta branch deriva da FEAT-006 local, sem modificar o commit 5be4309.
Mudança somente documental: ADR-0030, constituição 0.31, fluxo, Coordenador,
templates, AGENTS.md, guia e índices. Aprovações finais não são presumidas.

## Tarefas especificadas

### T-01 — Registrar regra e alinhar fontes

Estado: Concluído
Atende: AC-01 a AC-04.
Responsável: Especificador/Coordenador na sessão principal.
Dependências: pedido explícito do autor.
Objetivo: tornar o fechamento remoto parte do processo versionado.
Resultado esperado: ADR, versão, procedimento e templates com aprovação explícita.
Arquivos ou componentes: fontes do Jarvis e specs.
Verificação prevista: leitura cruzada e preservação dos registros anteriores.
O que foi feito: documentos redigidos no recorte autorizado.
O que falta: conferência em T-02.

### T-02 — Conferir, consolidar e preparar commit

Estado: Concluído
Atende: AC-01 a AC-05.
Responsável: Coordenador na sessão principal.
Dependências: T-01.
Objetivo: entregar mudança documental verificável.
Resultado esperado: referências, estados e sequência válidos; evidências na
Feature e commit local em inglês, sem integração remota não aprovada.
Arquivos ou componentes: diferenças desta branch e fontes relacionadas.
Verificação prevista: links, hashes, snapshot idêntico, cenários do processo
e `git diff --check`.
O que foi feito: conferidos 16 arquivos, 219 links locais, cenários, tabelas e
57 registros históricos preservados; snapshot 0.31 idêntico à constituição.
Passou git diff --check, incluindo arquivos novos; resultados na Feature.
O que falta: nenhuma pendência de verificação documental.

### T-03 — Integrar a entrega aprovada no GitHub

Estado: Em andamento
Atende: fechamento da entrega conforme ADR-0030 e etapa 7 do fluxo.
Responsável: Coordenador na sessão principal.
Dependências: aprovação final da FEAT-007 recebida; autorização da inclusão da
FEAT-006 ainda em esclarecimento, pois também consta nas diferenças para main.
Objetivo: publicar e integrar somente o conjunto autorizado.
Resultado esperado: aprovação, branches, PR, verificações e resultado remoto
registrados na Feature; impedimentos e próxima ação preservados quando houver.
Arquivos ou componentes: specs, índices, branch e PR no GitHub.
Verificação prevista: base remota atualizada, diferenças conferidas, links locais,
git diff --check, checks/revisões remotos e confirmação do resultado do merge.
O que foi feito: aprovação da FEAT-007 registrada; branch padrão main confirmada
no GitHub; fetch origin executado; nenhum PR encontrado para reutilizar.
O que falta: resolver a autorização da FEAT-006 antes de publicar o conjunto,
criar o PR, conferir exigências remotas e integrar.

## Evidências

| Tarefa | Verificação | Resultado |
| --- | --- | --- |
| T-01 | Branch e árvore inicial | FEAT-006 limpa; ramo documental criado, preservando 5be4309. |
| T-02 | Conferência documental | Passou: links, estados, cenários, integridade, snapshot e git diff --check. |
| T-03 | Registro da aprovação e dependência | Passou: 32 links locais em quatro arquivos, git diff --check e constituição idêntica ao snapshot 0.31; nenhuma alteração de código, ADR ou versão. |

## Aprovação e integração no GitHub

- FEAT-007: aprovação final recebida em 25/10/2026, mensagem “feature aprovada”
  após a revisão de f1388a3. A aprovação permanece válida para a integração.
- FEAT-006: pergunta enviada ao autor sobre incluir o commit 5be4309 na aprovação.
- Origin/main atualizado por fetch: 279d51c. GitHub confirma main como padrão e
  não retornou PRs existentes. A diferença inclui ambas as Features; a versão
  0.31 também depende dos registros de decisão incorporados pela FEAT-006.
- Push/PR/merge ainda não executados; falta autorização para a dependência.
- `gh` não está instalado; cliente específico não é requisito da regra.
  Ferramentas GitHub disponíveis, ainda sem uso para publicação ou merge.

## Retomada e consolidação

- Feito: decisão e fontes do processo redigidas, revisão documental concluída,
  aprovação final da FEAT-007 recebida e base remota conferida.
- Falta: autorização da inclusão da FEAT-006 e execução da integração remota.
- Próxima ação: incorporar a resposta sobre a dependência e executar a etapa 7
  com o conjunto autorizado, sem reconfirmar a aprovação da FEAT-007.
- Antes de remover: consolidar resultados e retomada na Feature sem declarar
  ações remotas não executadas ou perder contexto da integração pendente.
