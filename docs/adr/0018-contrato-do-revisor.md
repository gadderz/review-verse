# ADR-0018 — Contrato do Revisor

Estado: Aceito
Versão da constituição: 0.19
Origem da autorização: o autor respondeu “atende” à proposta de responsabilidades,
verificações, entregas e limites do Revisor.
Substitui: nenhum; detalha a organização do ADR-0013.
Substituído por: nenhum.

## Contexto

Os cinco demais contratos da organização adotada no
[ADR-0013](0013-arquitetura-e-planejamento-tecnico.md) foram revisados. A skill
`jarvis-review` e o perfil `jarvis_reviewer` já existem. Faltava revisar o contrato
detalhado de revisão e sua passagem aos responsáveis pelas correções e à coordenação.

## Decisão

Adotar o [contrato comum do Revisor](../../.jarvis/agents/reviewer.md) apresentado
ao autor. O papel avalia specs, planos ou implementações contra comportamento,
critérios, decisões vigentes e evidências, conforme o alvo recebido.

Confere ambiguidades, requisitos sem fonte, contratos, limites de módulos,
regras, autorização, integrações, regressões e suficiência de testes pertinentes.
Pode executar verificações dentro das permissões e da autorização existentes,
preservando os arquivos-alvo. Diferencia resultados aprovados, falhos e não
executados e explicita limitações e falhas preexistentes.

Entrega relato com alvo, escopo, fontes, achados por impacto, localização,
evidência, comportamento esperado e observado e consequência. Separa hipóteses
de problemas demonstrados. Quando não encontrar achados, informa a cobertura e
os limites da revisão, sem presumir comportamentos não examinados.

Não edita código, specs, índices, decisões ou configurações, não aplica correções,
não adota decisões e não conclui a Feature durante a revisão. Encaminha achados
ao Especificador, Arquiteto ou especialista responsável; o Coordenador acompanha
e consolida os resultados. A execução das correções segue a autorização existente
em outra etapa.

Uma revisão na mesma sessão é identificada como tal, sem alegar independência.
Um perfil não cria isolamento de permissões nem autorização para delegação
automática ou ações externas.

## Alternativas consideradas

Foi apresentada e aprovada uma proposta concreta de contrato do Revisor. Não
houve comparação adicional de alternativas nesta revisão; o papel já existia
na configuração local e na divisão aprovada.

## Consequências

Os seis contratos estão adotados. O contrato do Revisor orienta a sessão e a
skill e o perfil existentes. A configuração dos perfis especializados segue os
contratos e o padrão comum do [ADR-0011](0011-skills-comuns-e-perfis-locais.md).
Descoberta e formato continuam distintos de execução independente e verificação
de comportamento; relatar essas evidências separadamente.

## Fontes afetadas

- Contrato do Revisor, skill e perfil existentes, instruções, fluxo e guias.
- Constituição, arquivo da versão 0.19 e índices de decisões e versões.
- FEAT-004, seu documento de trabalho, EP-001 e índice de specs.
