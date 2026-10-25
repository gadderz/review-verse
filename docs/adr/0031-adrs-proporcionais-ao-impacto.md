# ADR-0031 — ADRs proporcionais ao impacto

Estado: Aceito
Versão da constituição: 0.32
Origem da autorização: pedido do autor em 25/10/2026 para restringir ADRs a
mudanças estruturais ou importantes e reduzir registros desnecessários.
Substitui: ADR-0003.
Substituído por: nenhum.

## Decisão e motivo

Exigir ADR por impacto: arquitetura, limites de módulos, tecnologia central,
contratos compartilhados/incompatíveis, segurança, integridade, custo
operacional significativo ou princípios do processo. Alternativas duradouras
com reversão onerosa também justificam o registro.

Detalhes restritos à Feature, parâmetros locais, implementação, tarefas,
verificações e redação ficam nas specs, planos e guias. Cada decisão que exige
ADR mantém uma versão própria da constituição; as demais não geram versões.
Mantemos o histórico anterior, sem reclassificar ou apagar suas decisões.

## Consequências

Evita usar ADR como ata de cada ajuste. O autor continua decidindo mudanças de
escopo e regras; a menor quantidade de documentos não amplia a autonomia.
Alternativa anterior: ADR e snapshot para toda decisão, que criou excesso de
arquivos durante o piloto. Fontes: artigo 9, índice de ADRs, templates e contratos.
Execução: [FEAT-008](../specs/features/FEAT-008-manutencao-e-execucao-local-do-jarvis.md).
