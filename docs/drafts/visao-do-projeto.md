# ReviewVerse — visão inicial do projeto

Status: especificação em descoberta, atualizada em 19/10/2026. A visão, a sequência de entrega, o fluxo da POC, a base de arquitetura e as primeiras regras de domínio foram confirmados pelo autor. Outras regras de negócio e detalhes de implementação e operação continuam em definição. Os desenhos antigos são referências históricas; as decisões atuais registradas neste documento orientam o projeto.

## Fontes

- [Export do Miro](../../ReviewVerse.pdf), com sete páginas.
- [Board original](https://miro.com/app/board/uXjVJ8Q3Nj8=/).
- [README original](../referencias/readme-original.md) e código em `src/`.
- Conversa de documentação iniciada em 18/10/2026.

## Visão confirmada

O ReviewVerse é uma plataforma para centralizar o histórico e o backlog de consumo de cultura pop. Uma pessoa deve conseguir reunir, em uma mesma conta, jogos, animes, mangás, filmes e séries que já consumiu ou que deseja consumir, além de atribuir notas e publicar reviews. O Backlog e as avaliações são públicos no escopo inicial. Outros usuários podem indicar se uma avaliação foi útil ou não útil. Comentários em reviews ficam fora do escopo atual.

O problema que motiva o projeto é a fragmentação dessas informações entre serviços especializados. O autor usa MyAnimeList para animes e cita Letterboxd e IMDb como referências para filmes, além de outros sites para jogos. O valor central desejado é organizar essas mídias em um só lugar. Isso não define, por enquanto, uma funcionalidade de importação ou sincronização de contas desses serviços.

O projeto tem dois objetivos: compor um portfólio e tornar-se um produto para usuários finais. Deve ser sólido e utilizável, atendendo inicialmente uma base pequena de usuários e permitindo crescimento com facilidade. O alvo inicial de validação é de 10 usuários simultâneos; a capacidade efetiva será medida na implementação. Metas de latência, disponibilidade e recuperação ainda serão detalhadas.

O público descrito no PDF inclui gamers, fãs de anime e de cinema. O início por games define a primeira categoria atendida. A interface terá português e inglês desde a POC; região e perfil de usuário prioritário ainda estão em aberto.

## Sequência de entrega confirmada

| Fase | Entrega prevista |
| --- | --- |
| 1. Realm de Jogos | Construir primeiro o catálogo de jogos, depois o Backlog do usuário e, em seguida, notas e reviews. |
| 2. Realm de Animes/Mangás | Repetir a sequência: catálogo, Backlog, notas e reviews. |
| 3. Realm de Filmes/Séries | Repetir a sequência: catálogo, Backlog, notas e reviews. |
| 4. Funcionalidades especializadas | Com o produto mais avançado, evoluir recursos por categoria, como recomendações e alertas de promoção de jogos. |

A primeira etapa de construção é o catálogo de games. O momento de abrir o produto aos primeiros usuários e os critérios para concluir cada fase ainda precisam ser definidos.

A primeira interface será uma POC web com o ciclo de catálogo, conta, Backlog e publicação de Review. Aplicativos Android/iOS e outras plataformas ficam fora dos planos iniciais.

A leitura pública de avaliações, os votos de utilidade e os templates de review fazem parte da visão confirmada do produto. A POC terá Reviews apenas com nota e texto opcional; templates, votos e a página Top 100 por nota serão entregues em uma evolução posterior. Comentários em reviews estão fora do escopo atual. A abrangência das recomendações será detalhada posteriormente.

Música aparece no README antigo, mas não foi incluída na sequência de entrega confirmada nesta conversa.

## Critério de conclusão da POC web

Todos os passos da interface devem estar disponíveis em português e inglês desde a primeira entrega.

A POC deve permitir que uma pessoa percorra o fluxo completo no Realm de Jogos:

1. Navegar pelo catálogo, buscar por nome, filtrar por gênero e plataforma e consultar um jogo e suas plataformas disponíveis.
2. Criar uma conta e autenticar-se por e-mail/senha, Google ou Steam, com apelido público único e e-mail obrigatório e confirmado antes de adicionar jogos ao Backlog ou publicar Reviews.
3. Adicionar um jogo, associado a uma plataforma, ao seu Backlog.
4. Organizar o Backlog usando estados e coleções.
5. Publicar uma Review para esse jogo/plataforma, com nota obrigatória e texto opcional, podendo marcar spoilers para ocultar o texto até o leitor escolher abri-lo.

Esse é o fluxo funcional confirmado para concluir a POC, com cadastro aberto a qualquer pessoa. A Review inicial terá nota obrigatória, texto opcional e marcação de spoilers. Templates, votos de utilidade, página Top 100 e moderação administrativa de Reviews e contas ficam fora dessa entrega. O acesso inclui e-mail/senha e os provedores Google e Steam, sempre com e-mail confirmado antes das operações pessoais. O ambiente de hospedagem e os critérios de desempenho e operação permanecem em aberto.

O [roteiro de implementação da POC](plano-da-poc.md) organiza essas entregas e os critérios de conclusão por etapa. A administração do catálogo continua no escopo confirmado.

## Idiomas e localização

A aplicação deve ser multilíngue desde o início, com suporte a português e inglês na POC. A estrutura deve permitir acrescentar idiomas depois, sem transformar os textos exibidos em identificadores de domínio.

O requisito abrange a interface dos fluxos de catálogo, conta, Backlog e Review. O idioma será detectado a partir do navegador; quando não for português nem inglês, será usado inglês. O usuário poderá trocar o idioma manualmente e salvar sua preferência no perfil. A escolha explícita deve prevalecer sobre a detecção automática nas próximas visitas.

Títulos e sinopses do catálogo devem usar as traduções disponíveis na IGDB para o idioma escolhido. Quando não houver tradução, devem manter o conteúdo original. Essa regra não exige produzir traduções ausentes na fonte.

Reviews são apresentadas no idioma escrito pelo autor, sem tradução automática na POC. A mudança de idioma da interface não altera o texto publicado pelo usuário.

## Cadastro e perfil

O cadastro será aberto a qualquer pessoa. O cadastro e o login da POC devem permitir e-mail e senha, além de Google e Steam. A autenticação fica sob responsabilidade do Keycloak. As três formas de acesso devem resultar em um perfil do produto, sem alterar as regras de Backlog e Reviews conforme o método usado.

O perfil deve conter e-mail, inclusive quando a pessoa entrar via Steam. Se a autenticação externa não fornecer o endereço, o cadastro deverá solicitá-lo. O e-mail precisa estar confirmado antes de o usuário adicionar jogos ao Backlog ou publicar Reviews. O mecanismo de confirmação e o aproveitamento de uma confirmação feita pelo provedor ainda serão detalhados.

O apelido público é obrigatório e único entre usuários. Regras de formato, normalização e edição serão detalhadas na implementação. Origem e edição do avatar ainda precisam ser definidas. A associação de Google e Steam a um mesmo perfil também será detalhada no fluxo de identidade.

## Condições iniciais de hospedagem

Não há preferência por provedor de hospedagem. O teto inicial confirmado é de R$ 200 por mês para hospedagem, banco de dados e backups.

Entre administrar uma VPS e usar serviços gerenciados, a prioridade declarada é a opção mais barata. A [comparação inicial de hospedagem](hospedagem-inicial.md) propõe avaliar uma VPS única e registra referências de preços. A proposta ainda precisa de dimensionamento; nenhum fornecedor ou plano foi escolhido ou contratado.

## Diretrizes de construção confirmadas

- Construir um produto funcional para pessoas reais, que também demonstre capacidade técnica no portfólio.
- Começar com uma base pequena de usuários e permitir expansão conforme o uso crescer.
- Entregar por Realm, seguindo a sequência de catálogo, Backlog e avaliações.
- Reservar funcionalidades especializadas para uma etapa avançada do projeto.

A base de arquitetura aprovada para a POC é uma API .NET modular, Worker separado e PostgreSQL, mantendo Next.js e Keycloak. A infraestrutura e os detalhes de implementação serão avaliados a partir dos fluxos do produto e das necessidades de operação.

## Vocabulário do domínio

| Termo | Definição confirmada |
| --- | --- |
| Realm (reino) | Agrupamento de mídias com características próprias. Existem inicialmente três Realms: Jogos, Animes/Mangás e Filmes/Séries. |
| Catálogo | Conjunto de obras disponíveis para consulta e inclusão no Backlog. |
| Backlog | Nome adotado para a lista pessoal de obras do usuário, incluindo o que deseja consumir e o que já consumiu. |
| Estado | Situação de consumo de uma obra no Backlog, escolhida entre opções predefinidas. |
| Coleção | Classificação de obras do Backlog, restrita a um Realm. Pode ser predefinida, como “Favoritos”, ou criada pelo próprio usuário. Uma obra pode participar de várias coleções desse Realm. |
| Nota (rating) | Componente numérico obrigatório de uma Review, na escala de 1 a 10. Em jogos, refere-se ao jogo em uma plataforma específica. |
| Review | Avaliação de uma obra pelo usuário, composta por nota obrigatória e texto opcional. Em jogos, refere-se à versão para a plataforma avaliada. |
| Média da comunidade | Média das Notas Gerais das Reviews de um jogo, com o mesmo peso para cada avaliação, incluindo todas as plataformas. É distinta da Nota Geral de uma Review individual. |
| Template de review | Estrutura reutilizável para padronizar avaliações. Oferece critérios com subnotas opcionais, que podem determinar a Nota Geral por média simples. |
| Voto de utilidade | Indicação de que uma avaliação foi “Útil” ou “Não útil”, representada por like ou dislike. |
| Worker | Processo que executa jobs responsáveis por popular a base do catálogo a partir da fonte externa. |

## Catálogo agregado e plataformas

O catálogo apresenta uma única página por jogo, reunindo suas plataformas disponíveis. “GTA V”, por exemplo, tem uma página única; PlayStation 4 é uma das plataformas que o usuário pode selecionar ao incluí-lo no Backlog.

O registro pessoal identifica o jogo e a plataforma. O mesmo usuário pode ter estados independentes para o mesmo jogo em plataformas diferentes, assim como notas e reviews específicas de cada plataforma. Por exemplo: “GTA V — PlayStation 4 — Jogando”.

Uma avaliação de uma plataforma deve ser associada à página agregada do jogo sem perder a identificação da plataforma avaliada. A navegação deve incluir busca por nome e filtros por gênero e plataforma desde a POC. Resultados continuam agregados por jogo, mesmo quando o filtro envolve uma plataforma. Ordenação, paginação e apresentação de notas por plataforma ainda serão detalhadas.

Remakes e remasters terão páginas próprias no catálogo. DLCs e expansões também estão incluídos na POC. O autor considera que a IGDB provavelmente já distingue remakes e remasters; essa correspondência e os relacionamentos entre os tipos de conteúdo permanecem para validação posterior, sem confirmação técnica nesta etapa. O tratamento de edições ainda será detalhado.

Os metadados confirmados para a página de jogo da POC são: título, capa, sinopse, gêneros, desenvolvedora/publicadora, plataformas e datas de lançamento. Esses campos definem o escopo inicial de apresentação; o comportamento quando algum dado não estiver disponível na fonte será detalhado na implementação.

## Alimentação do catálogo

A IGDB foi confirmada como fonte principal atual do catálogo de Jogos. A base do ReviewVerse será populada por jobs executados pelo Worker ou por ações de administradores. A administração do catálogo na POC será feita somente por API, sem tela web própria. Usuários comuns não poderão alimentar diretamente o catálogo.

A carga inicial da POC abrangerá 100 jogos distintos já lançados, priorizados por popularidade. Um jogo é elegível quando há lançamento já ocorrido em alguma plataforma a partir de 2025, incluindo 2025. O lançamento original pode ser anterior: um jogo lançado em 2020 que chegou a outra plataforma em 2025 é elegível. Títulos com lançamento apenas futuro ficam fora da importação da POC. Um lançamento futuro em outra plataforma, por si só, também não torna elegível um jogo antigo.

A contagem considera o jogo agregado: um jogo disponível em cinco plataformas conta como um jogo, e não cinco. O indicador técnico de popularidade será detalhado na integração com IGDB; ele não é a nota dada pelos usuários do ReviewVerse.

O Worker admite acionamento manual por um administrador e execução automática uma vez por dia. O autor delegou a escolha do horário; fica definido o padrão de 04h no fuso `America/Sao_Paulo`, ajustável por configuração. A expressão cron de cinco campos é `0 4 * * *`, com o fuso configurado explicitamente no agendador.

Depois da primeira carga, o Worker atualizará jogos existentes e adicionará novos jogos elegíveis. Os limites padrão são independentes e configuráveis: 100 jogos atualizados e 100 jogos adicionados. O catálogo pode crescer além dos 100 jogos iniciais. A contagem continua sendo por jogo agregado, independentemente de quantas plataformas sejam processadas.

Os limites são por execução, tanto manual quanto agendada. Cada nova execução recebe seus próprios limites de até 100 atualizações e até 100 adições; não há teto diário compartilhado confirmado. A seleção inicial por popularidade está confirmada; propõe-se manter essa prioridade nas novas adições e atualizar primeiro os registros há mais tempo sem sincronização.

Correções administrativas devem ser preservadas pelo Worker. A sincronização não deve substituir um campo corrigido manualmente pelos dados recebidos da IGDB. Campos sem correção administrativa podem continuar sendo atualizados pela fonte. A representação dessas correções e uma eventual opção de voltar a acompanhar o valor da fonte serão detalhadas na implementação.

Ainda precisam ser definidos o indicador de popularidade usado e a prioridade definitiva das atualizações. A eventual possibilidade de enviar sugestões de correção, sem editar o catálogo diretamente, também não foi definida.

## Primeira Feature do catálogo pela API

O recorte inicial confirmado é a [FEAT-006](../specs/features/FEAT-006-consulta-de-jogos-por-nome-pela-api.md).
Usará massa controlada de desenvolvimento/testes persistida em PostgreSQL;
a importação real IGDB entra em outra Feature do Catálogo ([ADR-0019](../adr/0019-massa-controlada-na-primeira-consulta.md)).
Essa separação não altera as condições de carga e sincronização da POC.

A consulta será pública e buscará trecho literal do título original,
ignorando caixa e acentos, removendo espaços somente nas pontas. O termo deve
ter de 1 a 200 caracteres; pontuação e curingas são literais, sem busca
aproximada ([ADR-0020](../adr/0020-comparacao-de-nomes-na-consulta.md) e
[ADR-0021](../adr/0021-consulta-publica-do-catalogo.md)).

O retorno inicial contém identificador estável, título original e plataformas,
agregados por jogo. Capa, títulos traduzidos, nomes alternativos e detalhes
ficam para evolução dessa API; a apresentação localizada completa continua
obrigatória para a POC ([ADR-0022](../adr/0022-retorno-minimo-da-consulta.md)).
A resposta informa página, tamanho e total de jogos; usa página 1/tamanho 20
por padrão, máximo 100, e ordenação por título sem distinção de caixa/acentos
e identificador para desempate ([ADR-0023](../adr/0023-paginacao-da-consulta-de-jogos.md)).

Essa primeira entrega está implementada e verificada na FEAT-006 com massa
controlada. A consulta local não comprova importação IGDB ou conclusão da POC.

## Regras de Backlog e coleções

No Realm de Jogos, os estados confirmados são:

- Quero jogar.
- Jogando.
- Concluído.
- Abandonei.
- Em espera (on hold).

Os estados são predefinidos. A adaptação dos estados e as demais particularidades dos Realms de Animes/Mangás e Filmes/Séries serão definidas posteriormente.

Coleções classificam obras do Backlog. O produto pode oferecer classificações básicas predefinidas, como “Favoritos”, e o usuário pode criar suas próprias coleções. Uma obra em uma coleção continua fazendo parte do Backlog.

Cada Realm tem suas próprias coleções, sem misturar obras de outros Realms. Uma obra pode participar de várias coleções dentro de seu Realm: por exemplo, o mesmo jogo pode estar em “Favoritos” e “Metroidvanias”.

A apresentação pessoal é agregada quando o usuário possui uma única plataforma do jogo no Backlog. Quando possui o mesmo jogo em plataformas diferentes, a apresentação distingue as versões, mantendo os estados e avaliações independentes. Essa regra de apresentação não altera a página única do jogo no catálogo.

Ao adicionar outra plataforma de um jogo já presente no Backlog, a nova entrada é incluída automaticamente nas coleções já associadas ao jogo. Exemplo: se “GTA V — PC” está em Favoritos, adicionar “GTA V — PS4” também o inclui em Favoritos. O comportamento de alterações posteriores nas coleções entre versões ainda será detalhado.

Remover uma entrada de jogo/plataforma do Backlog também remove a Review dessa entrada. As entradas e Reviews do mesmo jogo em outras plataformas permanecem independentes. Os efeitos de excluir somente uma coleção ainda precisam ser definidos.

## Regras de notas e reviews

- A Review pertence a uma obra e reúne nota obrigatória e texto opcional. Avaliar uma coleção ou o Backlog como um todo não faz parte do requisito confirmado.
- É permitido publicar somente a nota ou a nota acompanhada de texto. Não é permitido publicar uma Review sem nota.
- A escala de notas vai de 1 a 10 nos três Realms. Notas e subnotas informadas pelo usuário são inteiras. A Nota Geral de uma Review calculada com subnotas usa passos de 0,5; a média da comunidade segue a regra própria de precisão descrita abaixo.
- Uma obra pode estar no Backlog sem avaliação. Zero ou ausência de valor representam “sem nota”, e não uma Review válida. Esses casos não entram nas médias. A representação dessa ausência no armazenamento será definida na modelagem, preservando a exigência de nota nas Reviews publicadas.
- No Realm de Jogos, a nota e a review identificam o jogo e a plataforma. Uma avaliação da versão de PS5 deve ser distinguível de uma avaliação da versão de PC do mesmo jogo.
- Cada usuário pode manter uma única Review por jogo/plataforma. Pode editar ou excluir essa Review. Avaliar o mesmo jogo em outra plataforma gera uma avaliação independente.
- É permitido publicar uma Review nos estados Jogando, Concluído, Em espera ou Abandonei. Não é permitido avaliar uma entrada em Quero jogar/To do, que representa intenção de consumo. O e-mail confirmado continua sendo obrigatório.
- A Review está vinculada à entrada de jogo/plataforma no Backlog. Ao remover essa entrada, sua Review também é removida e deixa de participar das médias do jogo.
- Mudar o estado de uma entrada para Quero jogar/To do também remove sua Review. A entrada continua no Backlog com o novo estado; a avaliação removida deixa de participar das médias.
- A média geral do jogo é a média aritmética simples das Notas Gerais de todas as suas Reviews. Cada Review tem o mesmo peso, inclusive quando o mesmo usuário avalia o jogo em plataformas diferentes. A apresentação de médias por plataforma ainda será detalhada.
- Os detalhes de avaliação específicos dos demais Realms serão definidos nas fases correspondentes.

O tratamento dos votos após alterações na Review será definido em etapa posterior à POC. A cardinalidade e os estados de avaliação dos demais Realms serão detalhados com suas características específicas.

## Templates de review

Estas regras descrevem uma evolução posterior à POC. A primeira entrega usará apenas nota e texto opcional.

O usuário poderá padronizar suas avaliações usando um template. O produto oferecerá um template “Default”, de uso opcional, e permitirá que cada usuário crie seu próprio template. Também será possível escrever texto livre, sem usar um template, mantendo a nota obrigatória.

Os templates terão critérios com subnotas inteiras de 1 a 10, de preenchimento opcional. O usuário pode marcar um critério como “não se aplica”; esse critério fica fora da média. Também pode avaliar sem preencher subnotas, atribuindo diretamente uma nota inteira de 1 a 10. A nota geral continua obrigatória para publicar a Review.

Quando houver ao menos uma subnota preenchida, a Nota Geral é obrigatoriamente calculada pela média aritmética simples das subnotas preenchidas, com o mesmo peso para cada critério considerado, seguida do arredondamento definido abaixo. O usuário não pode substituir essa média por uma nota manual enquanto houver subnotas preenchidas. Critérios sem subnota ou marcados como “não se aplica” ficam fora do cálculo. Sem subnotas preenchidas, o usuário deve informar uma nota geral inteira de 1 a 10.

Esse cálculo é distinto da média das avaliações da comunidade exibida na página de um jogo.

Os critérios serão elaborados conforme o Realm. Para Jogos, o autor sugeriu Gameplay, Trilha Sonora e Direção de Arte como exemplos. A composição definitiva do template Default ainda não foi definida.

Exemplo ilustrativo de uma Review com três subnotas preenchidas:

| Critério | Subnota |
| --- | --- |
| Gameplay | 9 |
| Trilha Sonora | 8 |
| Direção de Arte | 7 |
| **Nota Geral (média simples)** | **8** |

Alterações em um template não modificam automaticamente as Reviews já publicadas. Cada Review mantém os critérios e as subnotas usados na publicação; mudanças no template afetam as próximas Reviews. A política de adoção de uma nova versão do template ao editar uma Review antiga ainda não foi definida.

Ainda precisam ser definidos: estrutura dos campos de texto nos templates, liberdade para criar critérios, eventual compartilhamento de templates e versão utilizada ao editar Reviews antigas.

## Notas individuais, média da comunidade e classificação

As notas e subnotas digitadas pelo usuário são inteiras. Quando houver subnotas, a Nota Geral da Review é calculada pela média delas e arredondada para cima até o menor múltiplo de 0,5 maior ou igual ao resultado. Valores já inteiros ou terminados em 0,5 permanecem iguais.

A expressão matemática dessa regra individual é `ceil(média das subnotas × 2) / 2`. Ela pertence aos templates, previstos para depois da POC.

Exemplos confirmados para a Nota Geral de uma Review com subnotas:

| Média calculada | Nota exibida |
| --- | --- |
| 8,1 | 8,5 |
| 8,3 | 8,5 |
| 8,5 | 8,5 |
| 8,6 | 9 |
| 9,7 | 10 |

A média da comunidade não usa arredondamento em passos de 0,5. Ela é calculada como `soma das Notas Gerais das Reviews / quantidade de Reviews`, com o mesmo peso por avaliação. As notas individuais consideradas são as Notas Gerais efetivas de cada Review: inteiras quando informadas manualmente ou calculadas em passos de 0,5 quando houver subnotas.

O resultado da comunidade deve manter a precisão para ordenar jogos e ser apresentado com duas casas decimais, como 8,67. O autor destacou essa distinção para possibilitar classificações como um Top 100 por nota. A página Top 100 fica fora da POC e será tratada em uma evolução posterior.

A exibição deve truncar as casas extras sem arredondamento: 8,678 aparece como 8,67. A classificação deve usar o resultado anterior à formatação, preservando diferenças que possam não aparecer nas duas casas exibidas. Quantidade mínima de Reviews para entrar em classificações e critérios de desempate serão detalhados na fase posterior à POC. Jogos sem Reviews ficam sem média, sem tratar ausência como nota zero.

## Visibilidade e interação

- O Backlog e as avaliações serão públicos no escopo inicial.
- Votos de utilidade serão entregues após a POC. As regras abaixo registram seu comportamento previsto no produto.
- Usuários poderão marcar uma avaliação como “Útil” ou “Não útil”. O voto indica utilidade da avaliação; ele é distinto da nota atribuída à obra.
- Comentários em reviews ficam fora do escopo atual, substituindo a intenção mencionada na primeira rodada.
- Cada usuário pode ter um único voto de utilidade por avaliação. Pode trocar entre “Útil” e “Não útil” ou retirar o voto.
- Não é permitido votar na própria avaliação.
- O autor poderá marcar uma Review como contendo spoilers na POC. Nesse caso, o texto fica oculto até o leitor escolher abri-lo; a nota permanece visível.
- Remoção de Reviews de terceiros e bloqueio de contas por administradores ficam para uma evolução posterior à POC. O autor continua podendo editar ou excluir suas próprias Reviews conforme as regras confirmadas.

## Capacidades desenhadas

| Capacidade | Intenção registrada no PDF |
| --- | --- |
| Identidade | Autenticação e autorização. |
| Perfil | Gerenciar informações do usuário. |
| Catálogo | Consultar games, animes, mangás, filmes e séries. |
| Listas | Organizar as obras de cada usuário. |
| Reviews | Publicar avaliações e notas. |
| Recomendações | Sugerir obras a partir das avaliações e notas dos usuários. |
| Notificações | Enviar notificações; gatilhos e canais ainda sem definição. |
| Analytics | Analisar reviews e notas; finalidade e destinatários ainda sem definição. |
| Alertas de preços | Avisar sobre preços de games; aparece no mapa da página 1. |

Essa relação registra o desenho histórico; o módulo chamado “Listas” no desenho passa a ser descrito como Backlog na documentação atual. A sequência de entrega confirmada acima orienta a prioridade. Identidade e perfil fazem parte da POC; notificações gerais e analytics ainda não têm etapa de entrega definida. As regras atuais de visibilidade e interação estão registradas acima.

## Arquitetura esboçada

A página 5 propõe aplicações web e mobile acessando APIs por um gateway. Há serviços separados para identidade, perfil, reviews, catálogo, listas e recomendações, além de processamento em segundo plano, notificações e mensageria.

Para a direção atual, somente a interface web faz parte dos planos iniciais. Foram confirmados C#/.NET para o backend, Next.js para a web e Keycloak para identidade. A IGDB como fonte principal de Jogos e o Worker para popular o catálogo também foram confirmados.

A divisão histórica em vários serviços foi revista: a base aprovada para a POC é uma API modular com Worker separado e PostgreSQL como banco do produto. Mensageria, cache e demais componentes do desenho ainda precisam ser avaliados conforme as necessidades da implementação.

A [arquitetura inicial](arquitetura-inicial.md) registra a base aprovada, o diagrama e os detalhes ainda propostos. A aprovação dessas bases não significa que já foram implementadas no código existente.

As tecnologias indicadas no desenho têm o seguinte estado:

| Área | Tecnologias indicadas | Estado atual |
| --- | --- | --- |
| Web | TypeScript e Next.js. | Next.js confirmado; detalhes de implementação a definir. |
| Mobile | Kotlin e Swift. | Fora dos planos iniciais. |
| Gateway | YARP. | Proposta histórica a avaliar. |
| Backend e identidade | ASP.NET Core; Keycloak. | C#/.NET e Keycloak confirmados como base. |
| Processamento em segundo plano | Hangfire. | Worker confirmado; Hangfire ainda é proposta do desenho e referência no código. |
| Recomendações | ML.NET. | Recurso de fase avançada; tecnologia a avaliar. |
| Notificações | SignalR. | Proposta histórica a avaliar. |
| Persistência | PostgreSQL e MongoDB. | PostgreSQL confirmado para o produto; MongoDB permanece apenas no desenho histórico, sem requisito confirmado na POC. |
| Cache/sessão | Redis. | Proposta histórica a avaliar. |
| Mensageria | RabbitMQ. | Proposta histórica a avaliar. |
| Analytics | Elasticsearch. | Proposta histórica a avaliar. |

O diagrama de contexto cita IGDB, TMDB e MyAnimeList como fontes externas para sincronizar o catálogo. A IGDB foi confirmada como fonte principal atual de Jogos; TMDB e MyAnimeList permanecem propostas para fases futuras. O código contém o início de uma integração com IGDB. Estratégias de sincronização e condições de uso ainda precisam ser avaliadas antes da implementação.

O PDF contém exemplos do template de Internet Banking: a página 3 explica o template, e as páginas 6 e 7 apresentam exemplos bancários. A página 5 também mantém descrições bancárias genéricas. Esses trechos não estabelecem requisitos do ReviewVerse. Na página 4, a descrição de IGDB como base de animes parece uma inconsistência de edição.

## Estado observado no repositório

- A solução contém projetos de API e worker para catálogo de games, API e domínio de reviews, e uma biblioteca compartilhada.
- Os projetos declaram `net10.0`.
- A API do Catálogo expõe consulta pública por nome com PostgreSQL; a API de
  Reviews ainda contém o endpoint de exemplo `WeatherForecast`.
- A entidade `Review` contém nota, identificação de mídia, identificação de usuário e texto. A atualização da nota valida valores entre 1 e 10, faixa agora confirmada para o produto. A entidade ainda não explicita a plataforma, os templates ou as subnotas. A separação entre obra no Backlog sem avaliação e Review com nota obrigatória ainda precisa ser modelada.
- O worker referencia Hangfire e Refit. O job e a interface de IGDB estão vazios.
- O Docker Compose descreve Keycloak com PostgreSQL. Isso não comprova que a autenticação das APIs esteja integrada: o README original marcava a integração como concluída, mas os arquivos `Program.cs` consultados não configuram autenticação.
- Não foram encontrados projetos de interface web ou mobile na árvore inspecionada.

A compilação da solução e os testes do Catálogo foram verificados na FEAT-006,
com resultados e limites consolidados na respectiva spec. Os demais componentes
continuam com o estado observado na leitura dos arquivos.

## Histórico da descoberta

As decisões das rodadas iniciais foram consolidadas nas seções acima. O [histórico de decisões](../referencias/historico-de-decisoes.md) preserva a sequência e as revisões sem misturá-las às regras atuais.

## Pendências de detalhamento

- Validar posteriormente a correspondência de remakes, remasters, DLCs e expansões nos registros da IGDB.
- Escolher e validar a integração Steam com Keycloak e o fluxo de envio/confirmação de e-mail.
- Detalhar o modelo de dados, os contratos dos módulos e os comportamentos secundários de edição de perfil e coleções.
- Validar o indicador de popularidade e os detalhes de busca, paginação e sincronização.
- Dimensionar o ambiente e medir o fluxo com alvo de 10 usuários simultâneos dentro do teto de R$ 200/mês.

## Base para implementação

A descoberta inicial definiu o problema, o escopo da POC, as principais regras e a base de arquitetura. O [roteiro da POC](plano-da-poc.md) organiza a implementação e a validação. As pendências técnicas acima devem ser resolvidas no detalhamento, mantendo este documento atualizado quando houver novas decisões.
