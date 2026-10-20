# Constituição do Jarvis — ReviewVerse

Versão: 0.19, revisão inicial concluída com o autor.
Os princípios dos artigos 1 a 9 estão confirmados pelas decisões registradas
neste documento. A evolução da constituição continua pelo procedimento de ADRs.

## 1. Produto e escopo orientam a solução

Cada mudança deve atender a uma necessidade identificável do ReviewVerse,
estar vinculada a um Épico e uma Feature e ter resultado verificável. Respeitar
o escopo autorizado para a entrega atual e manter a visão futura identificada
como evolução prevista.

Preferir a solução mais simples que atenda às regras e aos critérios acordados.
Justificar novas abstrações, componentes ou integrações por requisitos atuais,
restrições confirmadas ou evidências observadas, mantendo limites claros para
a evolução do projeto.

Consultar as restrições de orçamento e as metas de capacidade na visão e na
arquitetura atuais. Propostas de infraestrutura devem considerar o custo completo;
afirmações de capacidade devem ser sustentadas por medições.

## 2. Toda mudança tem spec na hierarquia Épico e Feature

Toda mudança, inclusive correções e ajustes editoriais, deve estar especificada
na hierarquia Épico → Feature → tarefas do documento de trabalho. Reusar specs
existentes quando o escopo já estiver contemplado; uma tarefa pequena não exige
criar outro Épico ou Feature, mas precisa ter seu resultado e verificação definidos.

Épicos e Features têm specs duradouras, com estado, o que já foi feito e o que
falta para concluir. Cada Épico relaciona suas Features; cada Feature referencia
seu Épico. O Épico define objetivo, escopo, limites e condições de conclusão;
a Feature define comportamento, critérios de aceitação e dependências.

O plano técnico e as specs das tarefas menores ficam em um documento de
trabalho por branch que executa a Feature. Ele identifica a branch e a Feature,
registra resultados esperados, progresso, impedimentos, verificações e próxima
ação. É temporário no ciclo de execução, mas versionado enquanto ativo para
permitir continuidade entre sessões e ferramentas.

Antes de removê-lo, consolidar resultados, pendências e evidências na Feature,
atualizar o progresso do Épico e preservar decisões duradouras em ADRs. Não
remover um plano com execução pendente sem transferir o contexto para a retomada.
Correções posteriores podem reusar a Feature e abrir outro documento de trabalho.

Usar os estados Rascunho, Planejado, Em andamento, Bloqueado e Concluído. Uma
Feature só está concluída com seus critérios atendidos e evidências registradas.
Um Épico exige suas condições de conclusão e Features concluídas ou retiradas
do escopo por decisão registrada. Manter pendências explícitas enquanto existirem.

Separar comportamento esperado de solução técnica. Dúvidas materiais devem ser
explicitadas; uma hipótese não vira requisito por ter sido escrita pelo agente.
O [índice de specs](../docs/specs/README.md) descreve os arquivos e o acompanhamento.

## 3. Decisões, propostas e evidências têm estados distintos

Identificar explicitamente propostas, decisões adotadas, implementação observada
e resultados verificados. A constituição define os princípios do processo;
ADRs aceitos registram as decisões vigentes e seus motivos; visão e arquitetura
consolidam as regras do produto e o desenho técnico; specs de Épicos e Features
definem escopo, critérios e progresso; o documento de trabalho detalha a execução.
O código e as verificações demonstram o que está implementado e validado.

Decisões tomadas na conversa devem ser registradas em ADR e nas fontes afetadas
antes de orientar a execução, conforme a autorização existente. Uma spec não
altera silenciosamente uma decisão vigente. Preservar os registros históricos
e os vínculos de substituição para distinguir decisões atuais das superadas.

Quando houver contradição, identificar as fontes e consultar as decisões vigentes.
Se uma decisão já resolver o conflito, atualizar a fonte desatualizada. Se a
intenção continuar ambígua, apresentar o conflito ao autor antes de implementar
o comportamento afetado, mantendo o trabalho independente em andamento.

## 4. A arquitetura aprovada guia a evolução

Seguir a arquitetura vigente registrada na documentação técnica e nos ADRs
aceitos. Manter os limites e as responsabilidades dos módulos explícitos, com
regras de negócio e dados sob responsabilidade do módulo correspondente.

Operações entre módulos devem usar contratos explícitos, preservando seus
limites de dados. Um módulo não escreve diretamente nas tabelas de outro.
Mudanças que atravessem módulos devem explicitar a coordenação, a consistência
e o tratamento de falhas no plano de execução.

Registrar decisões estruturais e suas justificativas em ADRs e atualizar a
documentação de arquitetura. Detalhar a organização de projetos, os contratos
e as ferramentas no plano de execução da Feature, conforme as decisões vigentes.
O desenho histórico e os pacotes já presentes não tornam uma dependência obrigatória.

## 5. Regras devem ser verificadas onde são aplicadas

Regras de domínio, autorização e condições de publicação precisam ser aplicadas
pela API, além da interface. Verificar comportamentos relevantes para a mudança,
incluindo persistência e concorrência quando afetarem invariantes como unicidade
e sincronização. Os exemplos de domínio estão nas especificações do produto.

Toda regra de negócio nova ou alterada e toda correção de bug devem ter testes
automatizados pertinentes. Os testes devem verificar o comportamento esperado;
nas correções, devem cobrir o cenário que causava a falha para prevenir regressão.

Exceções precisam de justificativa registrada junto às evidências da mudança,
indicando o motivo, o risco remanescente e a verificação alternativa realizada.
A ausência de infraestrutura de testes, por si só, não dispensa essa obrigação.

TDD é opcional: a ordem entre escrever testes e implementar pode variar conforme
a tarefa. Não há exigência geral de framework ou percentual de cobertura.
Verificações manuais complementam os testes quando necessárias; ajustes apenas
editoriais seguem a verificação proporcional prevista no fluxo.

## 6. Uma entrega exige evidência e documentação coerente

Uma Feature só está concluída quando seus critérios de aceitação estiverem
atendidos, com evidências registradas, política de testes cumprida e documentação
afetada atualizada. O estado da Feature, do Épico e dos índices deve refletir
o que foi entregue e o que ainda falta.

Vincular cada critério às verificações realizadas e registrar seus resultados,
distinguindo passou, falhou e não executado. Explicitar limitações, falhas
preexistentes e exceções à política de testes conforme o artigo 5. Se ainda faltar
evidência para um critério, manter a pendência até resolvê-la ou revisar o escopo
por decisão registrada em ADR.

Antes de encerrar o documento de trabalho, consolidar resultados, evidências,
decisões e contexto de retomada nas fontes duradouras. Ao relatar a entrega,
informar o que mudou, como foi verificado e as pendências reais. Compilação
bem-sucedida, tarefas marcadas e encerramento de branch não substituem os
critérios de aceitação.

## 7. O processo deve ser portátil e proporcional

Manter princípios, especificações, decisões e evidências em arquivos versionados
no repositório, compartilhados entre as ferramentas. Adaptar os pontos de entrada
e recursos específicos de cada ambiente, preservando uma fonte comum para as
regras do projeto. Carregar o contexto pertinente à tarefa conforme a necessidade.

O agente deve executar o trabalho autorizado com autonomia para escolhas
rotineiras de implementação, respeitando o escopo e as permissões do ambiente.
A autorização existente continua válida durante a tarefa, sem reconfirmação a
cada etapa. Alterações de escopo ou de decisões confirmadas devem ser discutidas
com o autor; decisões duradouras seguem o procedimento de ADRs. Pedidos apenas
de especificação ou revisão devem permanecer nesse limite.

Ao retomar ou trocar de sessão ou ferramenta, consultar as specs do Épico e da
Feature, os ADRs pertinentes e o documento de trabalho da branch, conferindo o
estado real do código. Ao interromper, registrar o que foi feito, o que falta,
impedimentos e próxima ação. Antes de remover o plano temporário, consolidar o
contexto nas fontes duradouras ou transferi-lo para a execução que continuará.

## 8. Commits em inglês e no padrão Conventional Commits

As mensagens de commit devem ser escritas em inglês, incluindo descrição,
corpo e explicações nos rodapés quando presentes, e seguir
[Conventional Commits 1.0.0](https://www.conventionalcommits.org/en/v1.0.0/).

Usar o formato `<type>[optional scope][!]: <description>`, com escopo opcional.
Usar `feat` para novas funcionalidades, `fix` para correções de bugs e outros
tipos conforme a natureza da mudança, como `docs`, `refactor`, `test` e `chore`.
Indicar mudanças incompatíveis com `!` antes de `:` ou com o rodapé
`BREAKING CHANGE:`, conforme a especificação.

Exemplos:

- `feat(catalog): add platform filter`
- `fix(reviews): prevent duplicate reviews per platform`
- `docs(jarvis): define commit message conventions`

## 9. Cada decisão deve ter ADR e uma nova versão

Registrar cada decisão adotada em um novo ADR numerado em `docs/adr/`, com
contexto, decisão, consequências, origem da autorização e versão correspondente
da constituição. A regra abrange decisões de produto, arquitetura e processo.
Uma proposta ou hipótese ainda não adotada deve continuar identificada como tal.

Cada decisão adotada gera sua própria versão da constituição, seguindo a
sequência atual: `0.19`, `0.20`, `0.21` e assim por diante. Não agrupar decisões
independentes em uma única versão. Registrar a versão mesmo quando a decisão
altera somente uma fonte de produto ou arquitetura; nesse caso, atualizar o
histórico da constituição e manter seus princípios.

Preservar uma cópia textual de cada nova versão em
`.jarvis/versions/<versao>.txt` e manter este arquivo como a versão atual.
Atualizar também o índice de ADRs e as fontes afetadas pela decisão. Ajustes
apenas editoriais não constituem uma nova decisão e não geram versão.

Uma mudança de decisão exige outro ADR, com referência ao registro substituído.
Preservar o conteúdo original dos ADRs aceitos e das versões arquivadas; nos
ADRs antigos, atualizar apenas o estado e os vínculos de substituição quando
necessário. O [índice de ADRs](../docs/adr/README.md) define o procedimento.

## Evolução da constituição

Propor mudanças com motivo e impacto sobre o trabalho existente. Mudanças de
princípios e decisões novas de produto ou arquitetura devem ser discutidas com o
autor. Escolhas técnicas dentro do escopo já autorizado seguem a autonomia
prevista no artigo 7. Registrar as decisões adotadas conforme o artigo 9, sem
exigir nova confirmação quando a autorização existente já for suficiente.

### Histórico de decisões e versões

| Versão | Decisão |
| --- | --- |
| 0.1 | Proposta inicial de constituição, ainda em revisão. |
| 0.2 | [ADR-0001 — Testes automatizados por comportamento](../docs/adr/0001-testes-automatizados-por-comportamento.md). |
| 0.3 | [ADR-0002 — Commits em inglês e Conventional Commits](../docs/adr/0002-commits-em-ingles-e-conventional-commits.md). |
| 0.4 | [ADR-0003 — ADRs e uma nova versão por decisão](../docs/adr/0003-adrs-e-versionamento-por-decisao.md). |
| 0.5 | [ADR-0004 — Especificações hierárquicas e documento de trabalho](../docs/adr/0004-especificacoes-hierarquicas-e-documento-de-trabalho.md). |
| 0.6 | [ADR-0005 — Produto, escopo e simplicidade](../docs/adr/0005-produto-escopo-e-simplicidade.md). |
| 0.7 | [ADR-0006 — Fontes, decisões e tratamento de conflitos](../docs/adr/0006-fontes-decisoes-e-tratamento-de-conflitos.md). |
| 0.8 | [ADR-0007 — Limites de módulos e evolução da arquitetura](../docs/adr/0007-limites-de-modulos-e-evolucao-da-arquitetura.md). |
| 0.9 | [ADR-0008 — Conclusão baseada em critérios e evidências](../docs/adr/0008-conclusao-baseada-em-criterios-e-evidencias.md). |
| 0.10 | [ADR-0009 — Autonomia, portabilidade e continuidade](../docs/adr/0009-autonomia-portabilidade-e-continuidade.md). |
| 0.11 | [ADR-0010 — Validação inicial no Codex](../docs/adr/0010-validacao-inicial-no-codex.md). |
| 0.12 | [ADR-0011 — Skills comuns e perfis locais](../docs/adr/0011-skills-comuns-e-perfis-locais.md). |
| 0.13 | [ADR-0012 — Especialistas em Backend, Frontend e Arquitetura](../docs/adr/0012-especialistas-backend-frontend-e-arquitetura.md). |
| 0.14 | [ADR-0013 — Arquitetura e planejamento técnico no mesmo agente](../docs/adr/0013-arquitetura-e-planejamento-tecnico.md). |
| 0.15 | [ADR-0014 — Contrato do Especialista Backend](../docs/adr/0014-contrato-do-especialista-backend.md). |
| 0.16 | [ADR-0015 — Contrato do Especialista Frontend](../docs/adr/0015-contrato-do-especialista-frontend.md). |
| 0.17 | [ADR-0016 — Contrato do Coordenador](../docs/adr/0016-contrato-do-coordenador.md). |
| 0.18 | [ADR-0017 — Contrato do Especificador](../docs/adr/0017-contrato-do-especificador.md). |
| 0.19 | [ADR-0018 — Contrato do Revisor](../docs/adr/0018-contrato-do-revisor.md). |

O [arquivo de versões](versions/README.md) preserva as cópias disponíveis.
O histórico de decisões anteriores do produto permanece em
`docs/referencias/historico-de-decisoes.md`; sua migração integral para ADRs
ainda não foi realizada. Uma entrada histórica preserva o estado de sua época;
a aceitação de cada princípio está identificada nos ADRs correspondentes.
