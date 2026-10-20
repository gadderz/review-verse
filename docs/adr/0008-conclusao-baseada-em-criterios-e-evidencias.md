# ADR-0008 — Conclusão baseada em critérios e evidências

Estado: Aceito
Versão da constituição: 0.9
Origem da autorização: o autor confirmou que a redação proposta do artigo 6
atende à definição esperada de conclusão.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A hierarquia já exige critérios, estados e consolidação do documento temporário,
e a política de testes prevê exceções justificadas. A revisão precisava definir
quando esses elementos permitem concluir uma Feature e como tratar uma
verificação pendente sem apresentar o trabalho como validado.

## Decisão

Concluir uma Feature apenas com critérios de aceitação atendidos, evidências
registradas, política de testes cumprida e documentação afetada atualizada.
Manter estados e índices coerentes com entregas e pendências reais.

Vincular critérios às verificações e distinguir passou, falhou e não executado.
Explicitar limitações, falhas preexistentes e exceções conforme o artigo 5.
Se faltar evidência de um critério, preservar a pendência até resolvê-la ou
revisar o escopo por decisão registrada em ADR.

Consolidar resultados, evidências, decisões e contexto antes de encerrar o
documento de trabalho. Relatar o que mudou, como foi verificado e pendências
reais. Compilar, marcar tarefas ou encerrar uma branch não substitui os critérios.

## Alternativas consideradas

- Manter a redação inicial mais geral sobre evidência e documentação coerente.
- Explicitar condições de conclusão e tratamento da falta de evidência,
  preservando a política de testes e suas exceções.

O autor confirmou a redação revisada.

## Consequências

Uma execução pode terminar com a Feature ainda pendente. Limitações de ambiente
e verificações não executadas precisam ficar visíveis, e a conclusão exige
evidência suficiente para seus critérios ou uma revisão formal do escopo.

A política de testes existente é preservada; esta decisão não exige um framework,
TDD, publicação ou percentual de cobertura específicos.

## Fontes afetadas

- Artigo 6 e histórico da constituição, na versão 0.9.
- Fluxo de verificação e conclusão do Jarvis.
- FEAT-002, Épico EP-001 e índices de ADRs, specs e versões.
