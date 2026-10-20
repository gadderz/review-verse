# FEAT-002 — Revisão dos princípios da constituição

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Concluído

## Necessidade e comportamento esperado

Revisar com o autor os princípios ainda propostos da constituição, discutindo
uma redação concreta por rodada. Cada decisão adotada deve ser registrada em
ADR próprio, com nova versão da constituição e cópia histórica preservada.

## Fontes e decisões

- [Constituição atual](../../../.jarvis/constitution.md).
- [Índice de ADRs](../../adr/README.md).
- [ADR-0005 — Produto, escopo e simplicidade](../../adr/0005-produto-escopo-e-simplicidade.md), versão 0.6.
- [ADR-0006 — Fontes, decisões e conflitos](../../adr/0006-fontes-decisoes-e-tratamento-de-conflitos.md), versão 0.7.
- [ADR-0007 — Limites de módulos e arquitetura](../../adr/0007-limites-de-modulos-e-evolucao-da-arquitetura.md), versão 0.8.
- [ADR-0008 — Conclusão e evidências](../../adr/0008-conclusao-baseada-em-criterios-e-evidencias.md), versão 0.9.
- [ADR-0009 — Autonomia, portabilidade e continuidade](../../adr/0009-autonomia-portabilidade-e-continuidade.md), versão 0.10.
- [Visão do projeto](../../drafts/visao-do-projeto.md).
- [Arquitetura atual](../../drafts/arquitetura-inicial.md).

## Escopo e dependências

Inclui a revisão dos artigos 1, 3, 4, 6 e 7, com registro das propostas, decisões
e pendências. Os artigos 2, 5, 8 e 9 já têm decisões registradas, respeitando o
alcance dessas decisões. Esta Feature não redefine o produto nem implementa
funcionalidades da POC ou configura agentes e skills.

## Critérios de aceitação

| ID | Resultado observável |
| --- | --- |
| AC-01 | Cada artigo do escopo é apresentado ao autor com proposta concreta e justificativa, referenciando as fontes aplicáveis. |
| AC-02 | Cada decisão adotada tem ADR e versão próprios, fontes coerentes e cópia arquivada; propostas abertas não aparecem como confirmadas. |
| AC-03 | Spec, Épico e índice indicam quais artigos foram revisados, o que foi decidido e o que falta. |
| AC-04 | Antes de concluir a Feature, resultados e evidências estão consolidados e os documentos de trabalho não contêm contexto pendente sem transferência. |

## O que já foi feito

- Concluída a revisão do artigo 1, sobre produto e escopo, com redação aceita.
- Conferidas as fontes de orçamento, capacidade e objetivos do ReviewVerse.
- Registrada a decisão no ADR-0005 e na constituição 0.6.
- Concluída a revisão do artigo 3 com redação aceita, registrada no ADR-0006 e
  na constituição 0.7.
- Concluída a revisão do artigo 4, com decisão no ADR-0007, constituição 0.8
  e fonte de arquitetura alinhada aos limites aceitos.
- Concluída a revisão do artigo 6, com decisão no ADR-0008 e constituição 0.9.
- Concluída a revisão do artigo 7, com decisão no ADR-0009 e constituição 0.10.
- Redação revisada consolidada, verificações concluídas e contexto de encerramento
  preservado nesta Feature e nos ADRs antes da remoção do documento temporário.

## Revisões e decisões

| Artigo | Situação da revisão | Pendência |
| --- | --- | --- |
| 1 — Produto e escopo | Revisado e aceito | Nenhuma; decisão no ADR-0005, versão 0.6. |
| 3 — Fontes e decisões | Revisado e aceito | Nenhuma; decisão no ADR-0006, versão 0.7. |
| 4 — Arquitetura | Revisado e aceito | Nenhuma; decisão no ADR-0007, versão 0.8. |
| 6 — Conclusão | Revisado e aceito | Nenhuma; decisão no ADR-0008, versão 0.9. |
| 7 — Autonomia e portabilidade | Revisado e aceito | Nenhuma; decisão no ADR-0009, versão 0.10. |

## O que falta

Nenhuma pendência nos critérios desta Feature. Configuração de agentes e skills
e validação em sessões reais das ferramentas continuam no Épico EP-001, conforme
o escopo que vier a ser definido; não são resultados desta revisão documental.

## Evidências

- Artigo 1: a visão atual confirma produto e portfólio, base inicial pequena,
  crescimento, orçamento e alvo de validação. A arquitetura distingue proposta
  de dimensionamento de capacidade comprovada.
- O autor aceitou a redação apresentada para o artigo 1; o ADR-0005 registra
  a decisão e a constituição 0.6 incorpora esse texto.
- O autor aceitou a redação do artigo 3; o ADR-0006 registra as responsabilidades
  das fontes e o tratamento de conflitos, incorporados na constituição 0.7.
- O autor aceitou o artigo 4; o ADR-0007 registra limites de módulos, contratos
  e evolução da arquitetura, incorporados à constituição 0.8 e à fonte técnica.
- O autor aceitou o artigo 6; o ADR-0008 registra as condições de conclusão,
  incorporadas à constituição 0.9.
- O autor aceitou o artigo 7; o ADR-0009 registra autonomia, portabilidade e
  continuidade, incorporadas à constituição 0.10.
- O autor aceitou o artigo 7; o ADR-0009 registra autonomia, portabilidade e
  continuidade, incorporadas à constituição 0.10.
- Verificação da rodada do artigo 3: passaram as checagens de links locais,
  formatação, correspondência com o texto aceito, sequência de ADRs e versões,
  identidade da cópia 0.7 e integridade dos registros anteriores. O artigo 4
  vigente foi preservado naquela rodada, antes de sua adoção na versão 0.8.
- Verificação da rodada do artigo 4: passaram links, formatação, correspondência
  com a redação aceita, alinhamento da fonte técnica, sequência de ADRs e versões,
  identidade da cópia 0.8 e integridade do histórico. O artigo 6 vigente foi
  preservado naquela rodada, antes de sua adoção na versão 0.9.
- Verificação da rodada do artigo 6: passaram links, formatação, correspondência
  com o texto aceito, sequência de ADRs e versões, identidade da cópia 0.9 e
  integridade do histórico. O artigo 7 vigente foi preservado durante a preparação
  de sua proposta.
- Verificação final: passaram links locais, formatação, correspondência do artigo 7
  com o texto aceito, preservação dos demais artigos, sequência dos nove ADRs e
  suas versões, identidade da cópia 0.10 e hashes dos registros históricos.

### Conclusão dos critérios

| Critério | Resultado e evidência |
| --- | --- |
| AC-01 | Atendido: artigos 1, 3, 4, 6 e 7 apresentados e aceitos pelo autor nas rodadas desta revisão; contexto e alternativas preservados nos ADRs 0005 a 0009. |
| AC-02 | Atendido: cada decisão tem ADR e versão próprios, de 0.6 a 0.10, com cópias arquivadas e fontes atualizadas; verificações de integridade passaram. |
| AC-03 | Atendido: decisões e estados consolidados nesta Feature, no Épico EP-001 e no índice de specs. |
| AC-04 | Atendido: redações aceitas preservadas na constituição, cópias e ADRs; evidências nesta spec; sem contexto pendente desta revisão antes de encerrar o documento temporário. |

Os comandos de verificação usaram `git diff --check` e conferências locais via
Python de vínculos, conteúdo, sequência e hashes SHA-256. Esta Feature altera
documentação do processo; não altera regras executáveis do produto e não demanda
exceção à política de testes.

## Próxima ação

Feature concluída. Retomar as próximas definições do Jarvis pelo Épico EP-001.
Uma revisão futura pode reusar esta Feature com outro documento de trabalho e
novos ADRs para as decisões adotadas.
