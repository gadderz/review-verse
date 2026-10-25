# Fluxo de trabalho do Jarvis

A hierarquia de specs foi confirmada no
[ADR-0004](../docs/adr/0004-especificacoes-hierarquicas-e-documento-de-trabalho.md).
Consulte a [constituição](constitution.md) e o [índice de specs](../docs/specs/README.md)
para os princípios e estados aplicáveis.

## 1. Situar a mudança

Ler a constituição, verificar a árvore de trabalho e consultar os documentos
relacionados. Identificar o pedido atual: explorar uma ideia, especificar,
implementar ou revisar. Não iniciar implementação em um pedido só de desenho.

Consultar os [ADRs](../docs/adr/README.md) pertinentes, respeitando seus estados
e substituições. Localizar o Épico, a Feature e o documento de trabalho da branch
atual quando existirem. Reusar as specs que já contemplam a mudança.

## 2. Especificar Épico e Feature

O [Especificador](agents/specifier.md) mantém a spec do Épico com objetivo,
limites, condições de conclusão e relação
das Features. Manter a spec da Feature com vínculo ao Épico, comportamento,
critérios observáveis, dependências, estado, entregas realizadas e pendências.
Usar os [templates de Épico](templates/epic.md) e [Feature](templates/feature.md).

Tudo tem spec. Ajustes pequenos podem reusar Épico e Feature e ser descritos
como tarefa do documento de trabalho; seu tamanho reduz o detalhamento, sem
dispensar objetivo, resultado esperado e verificação.

Separar dúvidas de comportamento de escolhas técnicas. Perguntar ao autor
quando a resposta mudar uma regra, o escopo ou uma decisão confirmada. Resolver
escolhas rotineiras dentro da autorização existente. Decisões estruturais ou
relevantes exigem ADR e versão, conforme o [procedimento de ADRs](../docs/adr/README.md).
Detalhes de Feature ficam na spec/plano antes da execução afetada; hipóteses
ainda abertas não viram requisitos.

Uma Feature pode ser Planejada quando escopo e critérios estiverem definidos e
as dúvidas restantes não impedirem sua execução. Esse estado não substitui a
autorização para implementar.

## 3. Abrir o documento de trabalho da branch

O [Arquiteto](agents/architect.md) conecta o desenho ao planejamento técnico,
conforme o [ADR-0013](../docs/adr/0013-arquitetura-e-planejamento-tecnico.md).
Recebe a Feature especificada, confere a arquitetura e o código e estrutura o
plano com contribuições dos especialistas Backend e Frontend. O Especificador
mantém a necessidade, o comportamento e os critérios nas specs duradouras.

Usar o [template de trabalho](templates/work.md) em
`.jarvis/work/<feature-id>/<identificador-da-branch>.md`. Registrar o nome real
da branch e os vínculos à Feature e ao Épico. Usar um identificador de arquivo
único para a branch dentro da Feature. Reusar o documento se essa execução já
estiver em andamento; outra branch tem seu próprio documento.

Detalhar plano técnico, componentes, contratos, dados e integrações conforme a
necessidade. Especificar as tarefas menores no próprio documento, cada uma com
objetivo, resultado esperado, verificação e progresso, vinculada aos critérios
da Feature. Não é necessário um arquivo por tarefa.

Planejar os testes exigidos pelo artigo 5 da constituição e a infraestrutura
necessária, com responsável por cenário de integração entre áreas. Identificar
responsáveis e dependências das tarefas. Registrar investigações técnicas e seus
resultados sem apresentar
uma hipótese de integração como funcionalidade pronta.

O documento é temporário no ciclo de execução e acompanha a branch enquanto
ativo. Deve poder ser versionado junto ao trabalho; não ocultá-lo por padrão
no `.gitignore`. Não depender apenas da memória da conversa.

Ao terminar o planejamento autorizado, fazer commit do documento de trabalho
antes de iniciar a implementação dependente. Atualizá-lo nos commits dos marcos
de execução e antes de transferir o trabalho entre sessões. Um pedido apenas de
planejamento permite registrar esse plano, sem autorizar implementar o produto.

## 4. Executar e acompanhar

[Backend](agents/backend.md) e [Frontend](agents/frontend.md) detalham e atualizam
tarefas, testes e evidências de suas
áreas. Escolhas rotineiras dentro dos contratos dispensam novo parecer do
Arquiteto; mudanças de contratos ou premissas técnicas exigem alinhamento entre
os envolvidos e atualização do plano. O [Coordenador](agents/coordinator.md) acompanha andamento,
dependências e impedimentos e consolida estados e resultados. Em uma sessão,
esses papéis podem ser exercidos em momentos distintos, sem delegação automática.

Executar o recorte autorizado e atualizar as tarefas no documento de trabalho.
Manter a Feature com estado, resultados consolidados e pendências atuais; atualizar
também sua linha no Épico e no índice de specs. O progresso das tarefas vive no
documento de trabalho; o resultado da Feature permanece na spec duradoura.

Se evidências exigirem ajustar a abordagem dentro do escopo, atualizar o plano.
Mudanças de decisões relevantes seguem o fluxo de ADRs. Não ampliar a entrega
silenciosamente. Diante de impedimento, registrar sua causa, o que falta resolver
e a próxima ação, mantendo o trabalho independente em andamento quando possível.

## 5. Verificar e revisar

Comparar o resultado com os critérios da Feature e com as regras aplicáveis.
Registrar testes, comandos e cenários realmente executados, diferenciando passou,
falhou e não executado. Registrar exceções à política de testes com a justificativa
exigida pela constituição. Verificar regressões e coerência das fontes afetadas.
Se faltar evidência de um critério, manter a pendência até resolvê-la ou revisar
formalmente o escopo por decisão registrada em ADR. As condições de conclusão
estão no artigo 6; cumprir tarefas ou compilar não substitui os critérios.

Uma revisão solicitada relata achados com impacto, evidência e localização.
O [Revisor](agents/reviewer.md) recebe o alvo e preserva os arquivos revisados;
os responsáveis tratam os achados e o Coordenador consolida seus resultados.
Se não houver achados, informar os limites da verificação. Um pedido apenas de
revisão não autoriza alterar a implementação automaticamente.

## 6. Consolidar e encerrar

Antes de encerrar ou remover o documento de trabalho:

1. Transferir para a Feature os resultados, as evidências, os critérios atendidos
   e o que ainda falta. Manter referências que continuem acessíveis após a remoção.
2. Registrar decisões relevantes em ADRs, com suas versões arquivadas, e atualizar
   as fontes de produto, arquitetura ou processo afetadas.
3. Atualizar o Épico e o índice de specs. Concluir a Feature apenas com critérios
   atendidos; retirar critérios ou Features do escopo exige decisão do autor
   registrada na spec e ADR quando o impacto atender ao artigo 9.
4. Conferir se outra sessão consegue retomar pendências sem o documento temporário.
   Se houver trabalho pendente, preservá-lo ou transferir seu contexto para o
   documento de trabalho da branch que continuará a execução.
5. Remover o documento temporário somente após consolidar e transferir seu contexto.
   Preservar as specs duradouras e o histórico versionado do trabalho integrado.

Antes de remover o plano, conferir que `git log -- <caminho-do-plano>` permite
recuperar pelo menos sua versão inicial. Não criar e remover o plano sem um
commit intermediário que o preserve; registrar esse commit na Feature.

O Épico só é Concluído com suas condições atendidas e Features concluídas ou
formalmente retiradas do escopo. Encerrar uma branch não conclui automaticamente
uma Feature ou seu Épico. Uma correção posterior pode reusar a Feature e abrir
outro documento de trabalho; atualizar seu estado se houver critérios pendentes.

## 7. Integrar no GitHub após aprovação final

Etapa padrão adotada no
[ADR-0030](../docs/adr/0030-integracao-no-github-apos-aprovacao-final.md),
constituição 0.31, sob responsabilidade do Coordenador.

1. Conferir a aprovação final explícita do autor, a Feature e o conjunto
   revisado de mudanças/commits a que ela se aplica. Concluído, testes passando
   e aprovação de spec ou plano não equivalem a essa aprovação. Reutilizar a
   autorização existente na sessão, sem pedir confirmação novamente.
2. Conferir remoto, destino acordado e diferenças a integrar. Se não houver
   destino indicado, consultar a branch padrão no GitHub. Atualizar a referência
   da base remota antes de integrar.
3. Fazer push da branch e criar ou reutilizar seu PR, descrevendo problema,
   resultado, vínculo à Feature, verificações e limites reais. Seguir commits
   em inglês e conferir as verificações/revisões exigidas pelo repositório.
4. Havendo conflitos, integrar a base atualizada na branch da Feature e
   resolvê-los preservando contribuições e critérios aprovados. Reexecutar as
   verificações afetadas: testes pertinentes para código; links locais e
   `git diff --check` para documentação. Atualizar a revisão conforme o impacto,
   enviar a resolução e conferir o PR. Não escolher automaticamente todo um
   lado nem sobrescrever trabalho remoto.
5. Realizar o merge no GitHub conforme as opções e regras permitidas.
   A aprovação final já dada cobre push, resolução técnica e merge; dúvidas
   que mudem comportamento ou escopo retornam ao autor.
6. Confirmar o resultado remoto e informar URL do PR, branches, commit integrado
   e resultado das verificações. Consolidar a evidência na Feature e atualizar
   Épico/índices quando afetados. Se necessário, registrar o resultado em
   atualização documental posterior; nunca antecipar sucesso na spec.

Se acesso, checks, regras do repositório ou conflito material impedirem avançar,
registrar causa e próxima ação. Não contornar exigências remotas para concluir.
Enquanto houver integração pendente, manter o documento de trabalho ou transferir
seu contexto completo à Feature antes de removê-lo. Distinguir entrega técnica
local de integração no GitHub; não declarar push ou merge por estarem apenas
planejados, solicitados ou agendados.

## Retomada entre sessões

Ler a spec da Feature, seu Épico, os ADRs pertinentes e o documento de trabalho
da branch atual. Conferir o código antes de continuar. Ao interromper uma sessão,
deixar no documento o que foi feito, o que falta, impedimentos e próxima ação.
