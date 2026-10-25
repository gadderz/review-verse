# EP-002 — Catálogo de Jogos

Estado: Em andamento

## Objetivo e escopo

Permitir que uma pessoa encontre e conheça jogos no ReviewVerse antes de
organizá-los no Backlog e avaliá-los. O catálogo é a primeira entrega do Realm
de Jogos e reúne as plataformas de cada jogo em uma única identidade.

Esta proposta organiza o escopo de catálogo já confirmado para a POC:

- Consulta por nome, filtros de gênero e plataforma e detalhes do jogo.
- Apresentação de título, capa, sinopse, gêneros, desenvolvedora/publicadora,
  plataformas e datas de lançamento, com interface em português e inglês.
- Títulos e sinopses traduzidos quando disponíveis na IGDB, com fallback para
  o conteúdo original, conforme a visão vigente.
- Carga inicial de 100 jogos distintos da IGDB, selecionados por popularidade
  e pela elegibilidade temporal confirmada; sincronização pelo Worker.
- Alimentação e correções por administradores somente por API, com autorização
  e preservação das correções durante a sincronização.

A primeira Feature especificada entrega somente consulta por nome pela API. O
restante será decomposto em Features após definição dos respectivos recortes;
esta spec não autoriza implementar todas essas entregas de uma vez.

Backlog, coleções, Reviews, médias e fluxos de conta pertencem a outros recortes.
Outros Realms, importação da biblioteca Steam, recomendações, alertas e Top 100
por nota ficam fora deste Épico. A interface de administração do catálogo
continua excluída da POC.

## Fontes e decisões

- [Visão do projeto](../../drafts/visao-do-projeto.md), especialmente catálogo
  agregado, alimentação, idiomas e critérios da POC.
- [Arquitetura inicial](../../drafts/arquitetura-inicial.md): API .NET modular,
  PostgreSQL e Worker separado; organização dos projetos ainda a detalhar.
- [Roteiro da POC](../../drafts/plano-da-poc.md): catálogo antes de Backlog e Reviews.
- [ADR-0004](../../adr/0004-especificacoes-hierarquicas-e-documento-de-trabalho.md),
  constituição 0.5: hierarquia e progresso.
- [ADR-0007](../../adr/0007-limites-de-modulos-e-evolucao-da-arquitetura.md),
  constituição 0.8: limites de dados e módulos.
- [ADR-0008](../../adr/0008-conclusao-baseada-em-criterios-e-evidencias.md),
  constituição 0.9: conclusão com evidências.
- Pedido do autor nesta sessão: especificar Catálogo de Jogos e propor consulta
  por nome pela API como primeira Feature; revisar antes de planejar e implementar.

As condições abaixo consolidam as fontes vigentes. O recorte da primeira
Feature foi confirmado pelo autor: massa controlada (ADR-0019), busca
(ADR-0020), acesso público (ADR-0021), retorno mínimo (ADR-0022), paginação
(ADR-0023) e PostgreSQL local em Docker considerando OrbStack (ADR-0024).
Os registros estão no [índice de ADRs](../../adr/README.md), com versões 0.20
a 0.25. A importação real da IGDB fica em outra Feature; as condições de
conclusão do catálogo completo permanecem vigentes.

## Condições de conclusão

| ID | Condição observável |
| --- | --- |
| EC-01 | A navegação do catálogo da POC permite buscar por nome, filtrar por gênero/plataforma e consultar detalhes com os metadados confirmados, agregando plataformas sem duplicar jogos. Remakes e remasters preservam identidades próprias; DLCs e expansões estão contemplados. |
| EC-02 | A interface de catálogo funciona em português e inglês, respeitando traduções disponíveis e fallback para o original. A falta de metadados na fonte tem comportamento definido e verificado nas Features correspondentes. |
| EC-03 | A carga inicial contém 100 jogos distintos da IGDB selecionados por popularidade, cada um com lançamento já ocorrido em alguma plataforma desde 01/01/2025. Lançamento exclusivamente futuro não satisfaz a elegibilidade. Mapeamentos de tipos e indicador de popularidade estão definidos e verificados. |
| EC-04 | O Worker permite acionamento administrativo e execução diária às 04h em `America/Sao_Paulo`, com horário configurável e limites independentes/configuráveis de 100 adições e 100 atualizações por execução. Acionamentos manuais/agendados são coordenados para evitar importações concorrentes do mesmo recorte; reexecuções não duplicam jogos/plataformas e correções administrativas são preservadas. |
| EC-05 | Operações administrativas por API exigem a autorização correspondente; usuários comuns não alimentam nem corrigem o catálogo ou acionam o Worker. |
| EC-06 | Todas as condições têm evidências duradouras, testes pertinentes e documentação coerente; todas as Features do escopo estão concluídas ou formalmente retiradas por ADR. Capacidades ainda não medidas permanecem identificadas como pendentes no recorte de validação da POC. |

A conclusão da primeira consulta pela API não conclui este Épico nem a POC.
O orçamento de R$ 200/mês e o alvo de 10 usuários simultâneos continuam nas
fontes da POC; esta especificação não comprova custo, capacidade ou latência.

## Features

| Feature | Estado | Resultado e pendências |
| --- | --- | --- |
| [FEAT-006 — Consulta de jogos por nome pela API](../features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md) | Concluído | Consulta pública com PostgreSQL/massa controlada entregue; nove testes unitários e 37 integrados passaram. Revisão e evidências consolidadas na Feature. |

Ainda faltam recortes para carga/sincronização, administração, filtros, detalhes
e interface localizada. Esses são requisitos do catálogo da POC já documentados,
mas a decomposição em Features, a ordem e seus contratos ainda serão definidos.
Não foram atribuídos IDs a entregas sem especificação própria.

## O que já foi feito

- Reunidas regras confirmadas do catálogo e seus limites nesta proposta.
- Especificada a FEAT-006 como primeira entrega de produto, com recorte
  confirmado pelo autor e decisões registradas antes da implementação.
- Elaborado o plano técnico da FEAT-006; decisões de módulo, persistência,
  consulta, HTTP e testes nos ADRs 0025 a 0029, até a versão 0.30.
- Concluída FEAT-006: consulta por nome, agregação, paginação e validações
  verificadas em PostgreSQL no OrbStack, com migração e massa controlada.
  A integração IGDB continua vazia e pendente em outro recorte.

## O que falta

- Completar a decomposição das entregas restantes do Épico, que continua
  Em andamento. A FEAT-006 está concluída e não substitui a carga real da POC.
- Especificar as demais Features necessárias às condições EC-01 a EC-06.
- Definir e validar indicador de popularidade, mapeamentos IGDB, tratamento de
  metadados ausentes e detalhes das correções/sincronização nos recortes próprios.
- Implementar e verificar as entregas após especificação e planejamento autorizados.

## Próxima ação

Especificar a próxima Feature do catálogo, tratando a importação IGDB em
recorte próprio conforme a separação confirmada. Filtros, detalhes, administração,
sincronização e interface localizada permanecem por detalhar e entregar.
