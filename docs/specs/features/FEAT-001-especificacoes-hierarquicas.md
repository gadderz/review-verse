# FEAT-001 — Especificações hierárquicas e documento de trabalho

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Concluído

## Necessidade e comportamento esperado

Organizar todas as mudanças com specs duradouras de Épico e Feature e um
documento de trabalho temporário por branch que executa a Feature. Deve ser
possível consultar o progresso permanente e retomar a execução em outra sessão.

## Fontes e decisões

- [ADR-0004](../../adr/0004-especificacoes-hierarquicas-e-documento-de-trabalho.md),
  versão 0.5 da constituição.
- [Política de testes](../../adr/0001-testes-automatizados-por-comportamento.md).

## Escopo e dependências

Inclui a constituição, o fluxo, os templates, os índices e a especificação do
trabalho de adoção deste modelo. Depende da base existente de ADRs e versões.
Não inclui implementar o Catálogo de Jogos nem configurar agentes ou skills.

## Critérios de aceitação

| ID | Resultado observável |
| --- | --- |
| AC-01 | Constituição e fluxo exigem specs de Épico e Feature com vínculos, estados, entregas realizadas e pendências. |
| AC-02 | Existe template do documento de trabalho vinculado à Feature e à branch, com plano, especificação das tarefas, progresso, evidências e retomada. |
| AC-03 | O encerramento exige consolidar resultados e evidências na Feature, decisões nos ADRs e progresso no Épico antes de remover o documento temporário. |
| AC-04 | O fluxo exige especificação também para ajustes pequenos, permite reusar Épico e Feature e define os estados acordados e as condições de conclusão. |
| AC-05 | ADR-0004, índices e versão 0.5 estão vinculados; a cópia arquivada preserva o texto da constituição 0.5 adotada nesta entrega e os registros anteriores permanecem preservados. |

## O que já foi feito

- Registrado o modelo no ADR-0004 e no artigo 2 da constituição 0.5.
- Criados templates separados de Épico, Feature e documento de trabalho.
- Atualizados fluxo, instruções e índices para a hierarquia e os estados aceitos.
- Substituído o template único de mudança pelo detalhamento próximo da execução.
- Usadas as specs EP-001 e FEAT-001 para acompanhar esta alteração. O documento
  de trabalho da preparação na branch `main` teve seus resultados e contexto
  consolidados nesta Feature antes de ser removido.
- Arquivada a constituição 0.5 e conferida a preservação dos registros anteriores.

## O que falta

Nenhuma pendência nos critérios desta Feature. A revisão dos demais princípios
e a validação em sessões reais das três ferramentas pertencem à continuidade
do Épico EP-001 e não são resultados desta entrega.

## Evidências

| Critério | Verificação | Resultado |
| --- | --- | --- |
| AC-01 | Leitura cruzada do artigo 2, fluxo, índice e templates de Épico e Feature. | Passou: responsabilidades, vínculos, estados, entregas e pendências explícitos. |
| AC-02 | Revisão do template de trabalho e aplicação nesta execução. | Passou: Feature, branch, tarefas especificadas, progresso, verificações e retomada registrados. |
| AC-03 | Revisão do encerramento e consolidação dos resultados desta execução. | Passou: evidências e pendências nesta spec, decisão no ADR-0004 e progresso no Épico e índice; nenhum vínculo permanente depende do documento temporário. |
| AC-04 | Busca por caminhos e regras do fluxo anterior nos documentos atuais. | Passou: removidos o caminho de spec única e a dispensa de especificação; ajustes pequenos reutilizam a hierarquia. |
| AC-05 | Checagem de links locais, sequência de ADRs, cópia textual e hashes SHA-256 anteriores via Python; `git diff --check`. | Passou: versões 0.2 a 0.5 vinculadas a ADRs únicos; cópia 0.5 idêntica byte a byte; ADRs 0001 a 0003 e cópias 0.3 e 0.4 preservados; formatação e vínculos válidos. |

Esta Feature altera documentação do processo. A verificação é documental e não
constitui exceção à política de testes de regras de negócio e correções de bugs.

## Próxima ação

Feature concluída. Retomar a revisão da constituição no Épico EP-001. Uma
alteração futura deste modelo pode reusar esta Feature com novo documento de
trabalho, registrando outro ADR caso mude a decisão vigente.
