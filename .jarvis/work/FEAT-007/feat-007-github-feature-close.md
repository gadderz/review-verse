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

## Evidências

| Tarefa | Verificação | Resultado |
| --- | --- | --- |
| T-01 | Branch e árvore inicial | FEAT-006 limpa; ramo documental criado, preservando 5be4309. |
| T-02 | Conferência documental | Passou: links, estados, cenários, integridade, snapshot e git diff --check. |

## Aprovação e integração no GitHub

- Regra autorizada; integração das entregas depende de aprovação final.
- FEAT-007: aprovação final pendente; push/PR/merge não executados.
- FEAT-006: pergunta enviada ao autor sobre integrar agora o commit 5be4309.
- O eventual aceite da FEAT-006 não publica automaticamente a FEAT-007.
- `gh` não está instalado; cliente específico não é requisito da regra.
  Ferramentas GitHub disponíveis, ainda sem uso para publicação ou merge.

## Retomada e consolidação

- Feito: decisão e fontes do processo redigidas.
- Falta: eventual integração, que depende da aprovação final da entrega;
  documentação já verificada e consolidada.
- Próxima ação: se FEAT-006 for aprovada, atuar na branch/commit
  correspondentes, preservando a separação das alterações da FEAT-007.
- Antes de remover: consolidar resultados e retomada na Feature sem declarar
  ações remotas não executadas ou perder contexto da integração pendente.
