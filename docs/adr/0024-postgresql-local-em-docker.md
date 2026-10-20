# ADR-0024 — PostgreSQL local em contêiner Docker

Estado: Aceito
Versão da constituição: 0.25
Origem da autorização: O autor pediu explicitamente banco de dados em contêiner Docker e informou uso de OrbStack no ambiente.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

PostgreSQL já é o banco aprovado do produto. Ao confirmar a massa controlada, o autor informou que utiliza OrbStack e pediu considerar o banco em contêiner Docker.

## Decisão

Preparar no futuro plano da FEAT-006 um PostgreSQL de desenvolvimento e testes em contêiner Docker, considerando OrbStack como ambiente local do autor. Documentar a preparação reproduzível dos dados e das verificações. Preservar a separação lógica entre dados do produto e identidade, conforme a arquitetura vigente.

## Alternativas consideradas

Não houve comparação de ferramentas ou provedores. A instrução define o ambiente local a considerar; não exige adoção global do OrbStack pelo projeto.

## Consequências

Versão/imagem do PostgreSQL, portas, volumes, credenciais, migrações, composição dos serviços e estratégia de isolamento dos testes serão detalhados pelo Arquiteto. Nenhum contêiner foi criado ou iniciado nesta etapa. A escolha não define hospedagem de produção nem comprova compatibilidade já verificada.

## Fontes afetadas

- [FEAT-006 — Consulta de jogos por nome pela API](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md).
- [EP-002 — Catálogo de Jogos](../specs/epics/EP-002-catalogo-de-jogos.md).
- [Visão do projeto](../drafts/visao-do-projeto.md) e [arquitetura inicial](../drafts/arquitetura-inicial.md).
- Constituição, cópia da versão 0.25, índices de decisões, versões e specs.
