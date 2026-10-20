# ADR-0009 — Autonomia, portabilidade e continuidade

Estado: Aceito
Versão da constituição: 0.10
Origem da autorização: o autor confirmou que a proposta do artigo 7 atende ao
nível esperado de autonomia e continuidade do Jarvis.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

O projeto precisa compartilhar o processo entre ferramentas e permitir a retomada
sem depender da memória da conversa. A hierarquia já prevê specs duradouras e
documentos temporários por execução, com consolidação no encerramento.
A revisão precisava explicitar autonomia, limites de autorização e retomada.

## Decisão

Manter princípios, specs, decisões e evidências em arquivos versionados, com
uma fonte comum para as regras e adaptações nos pontos de entrada de cada
ambiente. Carregar o contexto pertinente conforme a necessidade.

Executar o trabalho autorizado com autonomia para escolhas rotineiras, dentro
do escopo e das permissões do ambiente. Preservar a autorização existente sem
reconfirmar cada etapa. Discutir mudanças de escopo ou decisões confirmadas
com o autor; registrar decisões duradouras em ADRs. Respeitar pedidos limitados
a especificação ou revisão.

Na retomada, consultar Épico, Feature, ADRs e documento de trabalho da branch,
conferindo o código real. Ao interromper, registrar resultados, pendências,
impedimentos e próxima ação. Antes de remover o plano, consolidar ou transferir
o contexto que permitirá continuar.

## Alternativas consideradas

- Manter a redação inicial mais geral sobre portabilidade e proporcionalidade.
- Explicitar fonte comum, limites da autonomia e procedimento de continuidade.

O autor confirmou a redação revisada.

## Consequências

Trocas de sessão ou ferramenta usam os mesmos registros do projeto. Escolhas
rotineiras não exigem uma aprovação por etapa; mudanças de escopo e decisões
confirmadas continuam sujeitas à discussão com o autor.

Essa decisão não amplia permissões do ambiente, instala agentes ou skills,
nem comprova o carregamento da base nas três ferramentas. A revisão inicial
dos princípios é concluída; a configuração e a validação prática continuam
no Épico EP-001.

## Fontes afetadas

- Artigo 7, estado e histórico da constituição, na versão 0.10.
- Guia, instruções e índice de documentação do Jarvis.
- FEAT-002, Épico EP-001 e índices de ADRs, specs e versões.
