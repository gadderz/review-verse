# ADR-0001 — Testes automatizados por comportamento

Estado: Aceito
Versão da constituição: 0.2
Origem da autorização: escolha explícita do autor pela política A na revisão.
Registro: retrospectivo, criado na adoção dos ADRs na versão 0.4.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A proposta inicial exigia verificações adequadas ao risco, deixando aberta a
obrigação de testes automatizados. Na revisão, foram apresentadas as opções de
testes por comportamento, TDD obrigatório e escolha conforme o risco.

## Decisão

Toda regra de negócio nova ou alterada e toda correção de bug devem ter testes
automatizados pertinentes. Correções devem cobrir o cenário da falha para
prevenir regressão. Exceções precisam de justificativa, risco remanescente e
verificação alternativa registrados nas evidências da mudança.

TDD é opcional. Não há exigência geral de framework ou percentual de cobertura.
A ausência de infraestrutura de testes, por si só, não dispensa a política.

## Alternativas consideradas

- TDD obrigatório, exigindo observar o teste falhar antes da implementação.
- Verificação conforme o risco, com a estratégia escolhida pelo agente.

O autor escolheu a política de testes por comportamento.

## Consequências

Planos de implementação precisam considerar testes e sua infraestrutura.
Correções pequenas continuam sujeitas à política mesmo quando dispensam nova
spec. Verificações manuais podem complementar a cobertura, e exceções precisam
ficar visíveis no relato da entrega.

## Fontes afetadas

- Artigo 5 da constituição, atualizado na versão 0.2.
- Fluxo de trabalho e template de mudança do Jarvis.
