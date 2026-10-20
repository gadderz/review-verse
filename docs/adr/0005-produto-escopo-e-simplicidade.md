# ADR-0005 — Produto, escopo e simplicidade orientam a solução

Estado: Aceito
Versão da constituição: 0.6
Origem da autorização: o autor confirmou a redação proposta para o artigo 1
na revisão conjunta da constituição.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

O artigo 1 da proposta inicial tratava de foco na entrega e simplicidade, mas
repetia valores de orçamento e capacidade presentes na documentação do produto.
A adoção de Épicos e Features também precisava aparecer no vínculo entre uma
necessidade e a mudança que a atende.

## Decisão

Vincular cada mudança a uma necessidade identificável do ReviewVerse, a um
Épico e a uma Feature, com resultado verificável e respeito ao escopo autorizado.
Manter a visão futura identificada como evolução prevista.

Preferir a solução mais simples que atenda às regras e critérios acordados.
Justificar novas abstrações, componentes ou integrações por requisitos atuais,
restrições confirmadas ou evidências observadas, mantendo limites claros para
a evolução do projeto.

Consultar orçamento e metas de capacidade na visão e arquitetura atuais.
Considerar o custo completo nas propostas de infraestrutura e sustentar
afirmações de capacidade com medições.

## Alternativas consideradas

- Manter a redação inicial, com orçamento e capacidade repetidos na constituição
  e o princípio de simplicidade sem a justificativa explícita de complexidade.
- Adotar a redação revisada com vínculo à hierarquia e referência às fontes atuais.

O autor escolheu a redação revisada.

## Consequências

Planos e decisões técnicas devem explicar quais necessidades justificam a
complexidade adicionada. A constituição preserva o princípio e consulta os
valores nas fontes do projeto, evitando mais uma cópia para manter atualizada.

Esta decisão não altera os limites de orçamento nem o alvo de validação já
confirmados, não escolhe infraestrutura e não comprova capacidade da aplicação.

## Fontes afetadas

- Artigo 1 e histórico da constituição, na versão 0.6.
- FEAT-002, Épico EP-001 e índices de decisões, specs e versões.
