# ADR-0007 — Limites de módulos e evolução da arquitetura

Estado: Aceito
Versão da constituição: 0.8
Origem da autorização: o autor confirmou a proposta do artigo 4 e pediu a próxima revisão.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

A base técnica já aprovada é uma API .NET modular com Worker separado,
PostgreSQL, Next.js e Keycloak. O artigo 4 inicial repetia essa stack, e a fonte
de arquitetura apresentava os limites de dados entre módulos como proposta.
A revisão apresentou esses limites como princípios explícitos para adoção.

## Decisão

Seguir a arquitetura vigente nas fontes técnicas e nos ADRs aceitos. Cada módulo
é responsável por suas regras de negócio e dados, com limites explícitos.
Operações entre módulos usam contratos; um módulo não escreve diretamente nas
tabelas de outro. O plano de execução de operações que atravessam módulos precisa
explicitar coordenação, consistência e tratamento de falhas.

Registrar decisões estruturais em ADRs e atualizar a arquitetura. Detalhar projetos,
contratos e ferramentas no plano de execução da Feature, conforme as decisões
vigentes. Um pacote já referenciado ou o desenho histórico não tornam uma
dependência obrigatória.

## Alternativas consideradas

- Manter a stack repetida no artigo e os limites entre módulos descritos apenas
  de forma geral na constituição.
- Adotar princípios explícitos e consultar as fontes técnicas para a stack e
  as decisões de implementação.

O autor confirmou a redação revisada.

## Consequências

A fonte de arquitetura passa a tratar os limites de módulos como confirmados.
Planos que atravessem módulos precisam tratar a consistência da operação e suas
falhas sem depender de escrita direta em tabelas de outro módulo.

A decisão não escolhe ORM, estrutura de projetos, mensageria ou estratégia
transacional, e não comprova a reorganização do código. A stack já aprovada é
mantida na documentação técnica.

## Fontes afetadas

- Artigo 4 e histórico da constituição, na versão 0.8.
- Seção de limites entre módulos da arquitetura atual.
- FEAT-002, Épico EP-001 e índices de ADRs, specs e versões.
