# Registros de decisão — ADRs

O ReviewVerse usa ADRs para registrar decisões de produto, arquitetura e processo,
conforme o artigo 9 da [constituição](../../.jarvis/constitution.md). Cada decisão
adotada tem seu próprio ADR e uma nova versão da constituição.

## Índice

| ADR | Decisão | Estado | Versão da constituição |
| --- | --- | --- | --- |
| [ADR-0001](0001-testes-automatizados-por-comportamento.md) | Testes automatizados por comportamento | Aceito | 0.2 |
| [ADR-0002](0002-commits-em-ingles-e-conventional-commits.md) | Commits em inglês e Conventional Commits | Aceito | 0.3 |
| [ADR-0003](0003-adrs-e-versionamento-por-decisao.md) | ADRs e uma nova versão por decisão | Aceito | 0.4 |
| [ADR-0004](0004-especificacoes-hierarquicas-e-documento-de-trabalho.md) | Specs hierárquicas e documento de trabalho | Aceito | 0.5 |
| [ADR-0005](0005-produto-escopo-e-simplicidade.md) | Produto, escopo e simplicidade | Aceito | 0.6 |
| [ADR-0006](0006-fontes-decisoes-e-tratamento-de-conflitos.md) | Fontes, decisões e tratamento de conflitos | Aceito | 0.7 |
| [ADR-0007](0007-limites-de-modulos-e-evolucao-da-arquitetura.md) | Limites de módulos e evolução da arquitetura | Aceito | 0.8 |
| [ADR-0008](0008-conclusao-baseada-em-criterios-e-evidencias.md) | Conclusão baseada em critérios e evidências | Aceito | 0.9 |
| [ADR-0009](0009-autonomia-portabilidade-e-continuidade.md) | Autonomia, portabilidade e continuidade | Aceito | 0.10 |
| [ADR-0010](0010-validacao-inicial-no-codex.md) | Validação inicial no Codex | Aceito | 0.11 |
| [ADR-0011](0011-skills-comuns-e-perfis-locais.md) | Skills comuns e perfis locais | Aceito | 0.12 |
| [ADR-0012](0012-especialistas-backend-frontend-e-arquitetura.md) | Especialistas em Backend, Frontend e Arquitetura | Aceito | 0.13 |
| [ADR-0013](0013-arquitetura-e-planejamento-tecnico.md) | Arquitetura e planejamento técnico no mesmo agente | Aceito | 0.14 |
| [ADR-0014](0014-contrato-do-especialista-backend.md) | Contrato do Especialista Backend | Aceito | 0.15 |
| [ADR-0015](0015-contrato-do-especialista-frontend.md) | Contrato do Especialista Frontend | Aceito | 0.16 |
| [ADR-0016](0016-contrato-do-coordenador.md) | Contrato do Coordenador | Aceito | 0.17 |
| [ADR-0017](0017-contrato-do-especificador.md) | Contrato do Especificador | Aceito | 0.18 |
| [ADR-0018](0018-contrato-do-revisor.md) | Contrato do Revisor | Aceito | 0.19 |
| [ADR-0019](0019-massa-controlada-na-primeira-consulta.md) | Massa controlada na primeira consulta do catálogo | Aceito | 0.20 |
| [ADR-0020](0020-comparacao-de-nomes-na-consulta.md) | Comparação de nomes na consulta de jogos | Aceito | 0.21 |
| [ADR-0021](0021-consulta-publica-do-catalogo.md) | Consulta pública do catálogo de jogos | Aceito | 0.22 |
| [ADR-0022](0022-retorno-minimo-da-consulta.md) | Retorno mínimo da primeira consulta de jogos | Aceito | 0.23 |
| [ADR-0023](0023-paginacao-da-consulta-de-jogos.md) | Paginação e ordenação da consulta de jogos | Aceito | 0.24 |
| [ADR-0024](0024-postgresql-local-em-docker.md) | PostgreSQL local em contêiner Docker | Aceito | 0.25 |
| [ADR-0025](0025-modulo-inicial-do-catalogo.md) | Módulo inicial do Catálogo na API modular | Aceito | 0.26 |
| [ADR-0026](0026-persistencia-do-catalogo-com-ef-core.md) | Persistência e migrações do Catálogo com EF Core | Aceito | 0.27 |
| [ADR-0027](0027-busca-literal-com-unaccent.md) | Busca literal e agregação no PostgreSQL | Aceito | 0.28 |
| [ADR-0028](0028-contrato-http-da-consulta-de-jogos.md) | Contrato HTTP da consulta de jogos | Aceito | 0.29 |
| [ADR-0029](0029-verificacao-do-catalogo-com-postgresql-isolado.md) | Verificação do Catálogo com PostgreSQL isolado | Aceito | 0.30 |
| [ADR-0030](0030-integracao-no-github-apos-aprovacao-final.md) | Integração no GitHub após aprovação final | Aceito | 0.31 |

Os dois primeiros ADRs registram retrospectivamente decisões já confirmadas
pelo autor nesta conversa. Mantêm as versões que essas decisões já receberam;
a migração para ADRs não as transforma em novas decisões. A versão 0.1 foi o
ponto de partida; a revisão inicial foi concluída na versão 0.10, com as decisões
registradas neste índice.

As decisões anteriores de descoberta do produto permanecem no
[histórico existente](../referencias/historico-de-decisoes.md). Sua migração
integral para ADRs não foi feita nesta etapa.

Contexto e consequências de um ADR preservam o estado da sua época. A menção a
dispensa de nova spec no ADR-0001 é anterior ao ADR-0004: a regra vigente exige
spec para toda mudança, permitindo reusar Épico e Feature existentes. Consultar
o conjunto das decisões atuais sem reescrever o registro histórico aceito.

## Criar e adotar uma decisão

1. Consultar este índice, os ADRs pertinentes e a documentação atual.
2. Criar `NNNN-descricao.md` com o próximo número livre, usando o
   [template de ADR](../../.jarvis/templates/adr.md). Nunca reutilizar números.
3. Registrar contexto, decisão, consequências, alternativas efetivamente
   consideradas e origem da autorização. Se a decisão ainda não foi tomada,
   manter o ADR como `Proposto`, com a versão da constituição pendente.
4. Quando adotada, marcar como `Aceito` e atribuir a próxima versão da
   constituição: uma versão por decisão, inclusive se os princípios não mudarem.
   Atualizar a fonte afetada e o histórico de `.jarvis/constitution.md`.
5. Salvar uma cópia textual da constituição em `.jarvis/versions/<versao>.txt`,
   idêntica ao arquivo atual, sem sobrescrever cópias existentes. Atualizar
   também o índice do arquivo de versões.
6. Atualizar este índice e referenciar o ADR na spec relacionada, quando houver.
   Conferir os vínculos, a sequência das versões e a coerência das fontes.

Para decisões independentes tomadas juntas, registrar cada ADR e cada versão
intermediária em sequência. Escrever ou revisar uma proposta não gera uma nova
versão; a adoção da decisão é o evento que a gera. A aceitação documenta uma
decisão e sua autorização; não comprova que a implementação foi concluída.

## Estados e substituição

- `Proposto`: ainda em discussão; não altera a orientação vigente.
- `Aceito`: decisão adotada pelo autor ou escolha técnica dentro da autorização
  já concedida, com essa origem registrada.
- `Rejeitado`: proposta não adotada, preservada como referência.
- `Substituído`: decisão antes aceita, substituída por outro ADR aceito.

Para mudar uma decisão aceita, criar outro ADR e indicar qual registro ele
substitui. Após sua adoção, atualizar o estado e o vínculo do ADR anterior e do
índice. Preservar contexto, decisão e consequências originais do registro antigo.
Novos contextos e justificativas pertencem ao novo ADR.

Correções de redação nas fontes atuais que não alterem a decisão não criam ADR
nem versão. Em registros aceitos, preservar o texto histórico e limitar mudanças
ao estado e aos vínculos de substituição. Se um esclarecimento mudar a orientação
vigente, registrar uma nova decisão. Versões arquivadas permanecem inalteradas.
