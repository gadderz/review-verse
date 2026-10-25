# ADR-0003 — ADRs e uma nova versão por decisão

Estado: Substituído
Versão da constituição: 0.4
Origem da autorização: instrução explícita do autor para usar ADRs e adicionar
uma nova versão a cada decisão tomada.
Substitui: nenhum.
Substituído por: [ADR-0031](0031-adrs-proporcionais-ao-impacto.md).

## Contexto

As decisões sobre testes e commits haviam sido registradas em notas na
constituição, nas versões 0.2 e 0.3. Era necessário preservar contexto e
consequências de cada decisão e consultar as versões anteriores sem depender
da memória da conversa. Os arquivos iniciais do Jarvis ainda não estavam
registrados em commits.

## Decisão

Usar ADRs numerados em `docs/adr/` para decisões de produto, arquitetura e
processo. Cada decisão adotada gera um ADR próprio e a próxima versão da
constituição, mesmo quando somente seu histórico precisa mudar.

Manter `.jarvis/constitution.md` como versão atual e arquivar cada nova versão
em `.jarvis/versions/<versao>.txt`. Preservar as versões arquivadas e registrar
mudanças de decisão em novos ADRs que apontem quais decisões substituem.

Propostas ainda não adotadas e ajustes editoriais não geram novas versões.
Atualizar o índice de ADRs e as fontes afetadas a cada decisão.

## Alternativas consideradas

O registro somente em notas na constituição era o mecanismo anterior. O autor
determinou sua evolução para ADRs e versionamento por decisão; outras opções
de ferramenta não foram avaliadas nesta rodada.

## Consequências

Cada decisão passa a exigir um registro e uma versão próprios. Isso permite
acompanhar a evolução e retomar o trabalho em qualquer ferramenta, ao custo de
manter o índice, os vínculos e as cópias da constituição coerentes.

As decisões de testes e commits são migradas retrospectivamente sem renumerar
suas versões. A cópia 0.3 é preservada antes desta alteração e a 0.4 inicia o
arquivamento sistemático. Não foram reconstruídas cópias 0.1 ou 0.2, nem migrado
integralmente o histórico anterior de descoberta do produto.

## Fontes afetadas

- Artigo 9 e histórico da constituição, na versão 0.4.
- Fluxo de trabalho, templates e índices do Jarvis e da documentação.
- Arquivo de versões da constituição e instruções compartilhadas.
