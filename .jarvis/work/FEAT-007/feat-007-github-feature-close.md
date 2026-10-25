# Trabalho — FEAT-007 — Padrão de integração no GitHub

Feature: [FEAT-007](../../../docs/specs/features/FEAT-007-integracao-no-github-apos-aprovacao-final.md)
Épico: [EP-001](../../../docs/specs/epics/EP-001-jarvis.md)
Branch: `feat/007-github-feature-close`
Estado: Bloqueado

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

Estado: Bloqueado
Atende: fechamento da entrega conforme ADR-0030 e etapa 7 do fluxo.
Responsável: Coordenador na sessão principal.
Dependências: aprovações finais da FEAT-007 e da FEAT-006 recebidas; acesso ao
GitHub e cumprimento das exigências remotas.
Objetivo: publicar e integrar somente o conjunto autorizado.
Resultado esperado: aprovação, branches, PR, verificações e resultado remoto
registrados na Feature; impedimentos e próxima ação preservados quando houver.
Arquivos ou componentes: specs, índices, branch e PR no GitHub.
Verificação prevista: base remota atualizada, diferenças conferidas, links locais,
git diff --check, checks/revisões remotos e confirmação do resultado do merge.
O que foi feito: aprovações das duas Features registradas; branch padrão main
confirmada no GitHub; fetch origin e pushes executados. Nenhum PR encontrado
para reutilizar; tentativa de criação recusada por HTTP 403.
O que falta: resolver o HTTP 403 do conector na criação de PR; depois integrar
primeiro a FEAT-006, depois a FEAT-007, conferir exigências remotas e registrar
o resultado dos dois PRs.

## Evidências

| Tarefa | Verificação | Resultado |
| --- | --- | --- |
| T-01 | Branch e árvore inicial | FEAT-006 limpa; ramo documental criado, preservando 5be4309. |
| T-02 | Conferência documental | Passou: links, estados, cenários, integridade, snapshot e git diff --check. |
| T-03 | Registro da aprovação e dependência | Passou: 32 links locais em quatro arquivos, git diff --check e constituição idêntica ao snapshot 0.31; nenhuma alteração de código, ADR ou versão. |
| T-03 | Publicação e registro do impedimento | Passou: push das duas branches confirmado por git ls-remote, 62 links locais em seis arquivos, git diff --check e snapshot 0.31; código/testes/configuração iguais a 5be4309. Falhou: criação do PR, HTTP 403 da API GitHub. Merge não executado. |

## Aprovação e integração no GitHub

- FEAT-007: aprovação final recebida em 25/10/2026, mensagem “feature aprovada”
  após a revisão de f1388a3. A aprovação permanece válida para a integração.
- FEAT-006: aprovação final recebida em 25/10/2026, nova mensagem “feature
  aprovada” em resposta à pergunta explícita sobre integrar o commit 5be4309.
- Origin/main atualizado por fetch: 279d51c. GitHub confirma main como padrão e
  não retornou PRs existentes. A diferença inclui ambas as Features; a versão
  0.31 também depende dos registros de decisão incorporados pela FEAT-006.
- Push executado para ambas as branches em 25/10/2026: FEAT-006 em 5be4309 e
  publicação inicial da FEAT-007 em 0c51abf. Os registros posteriores de
  aprovação/impedimento seguem na branch da FEAT-007.
- Criação do PR da FEAT-006 tentada com base main; GitHub respondeu HTTP 403,
  `Resource not accessible by integration`. Não houve PR nem merge. Não foi
  repetida a mesma operação para FEAT-007 antes de resolver o impedimento.
- `gh` não está instalado e não há configuração local desse cliente. O push
  usa SSH; o conector disponível não conseguiu executar a operação de PR.
  Corrigir seu acesso de escrita ou disponibilizar cliente autenticado com
  permissões adequadas. Nenhuma permissão foi alterada ou regra remota contornada.

## Retomada dos PRs

1. Corrigir o acesso à criação/integração de PRs. Reutilizar as duas aprovações
   já recebidas; o impedimento é de acesso, não de autorização do autor.
2. Atualizar origin/main e conferir se já existem PRs ou merges dessas branches.
3. Criar/reutilizar o PR `feat/006-game-search-api` → `main`, título
   `feat(catalog): add game search by name`, para o commit 5be4309. Descrever
   consulta pública, PostgreSQL, paginação/plataformas e vínculo à FEAT-006;
   informar as evidências registradas de nove unitários/37 integrados, build e
   formatação, sem alegar nova execução local. Registrar o aviso NU1903
   preexistente no Worker e limites de IGDB/produção. Conferir exigências e
   integrar preservando o commit original quando permitido pelo repositório.
4. Atualizar a base e integrar `feat/007-github-feature-close` → `main`, título
   `docs(jarvis): require GitHub integration after final approval`. O resultado
   é o padrão de integração após aprovação final, com ADR-0030/0.31, instruções,
   templates e registros de fechamento; mudança documental. Comparar somente
   as diferenças restantes após FEAT-006, revalidar links/diff e cumprir checks.
5. Confirmar ambos os resultados remotos e consolidar URLs dos PRs, commits,
   verificações e conflitos nas Features. Remover este documento somente após
   consolidar a retomada e as evidências duradouras.

## Retomada e consolidação

- Feito: decisão e fontes do processo redigidas, revisão documental concluída,
  ambas as aprovações finais recebidas, base remota conferida e branches publicadas.
- Falta: corrigir o acesso aos PRs e concluir a integração das duas entregas.
- Próxima ação: seguir a retomada dos PRs acima após resolver o HTTP 403,
  sem reconfirmar as aprovações existentes.
- Antes de remover: consolidar resultados e retomada na Feature sem declarar
  ações remotas não executadas ou perder contexto da integração pendente.
