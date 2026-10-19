# ReviewVerse

Plataforma para reunir, em um só lugar, o histórico e o backlog de jogos, animes, mangás, filmes e séries. O usuário organiza o que deseja consumir e o que já consumiu, atribui notas e publica reviews.

O projeto tem objetivos de portfólio e de produto para usuários finais. Deve atender inicialmente uma base pequena de usuários, com uma base técnica sólida e possibilidade de crescimento.

## Estado atual

O repositório contém uma implementação inicial em .NET, com projetos de catálogo de jogos, reviews e componentes compartilhados. A POC ainda será construída; o escopo abaixo descreve o comportamento esperado. Sua base de arquitetura foi definida, com detalhes de implementação e operação ainda em discussão.

O [índice da documentação](docs/README.md) reúne a visão do produto, arquitetura, roteiro de implementação e referências. As regras atuais estão consolidadas; validações técnicas e detalhes de implementação permanecem identificados nos documentos.

## Conceitos principais

- **Realm:** reino de mídias com características próprias. Os três Realms previstos são Jogos, Animes/Mangás e Filmes/Séries.
- **Backlog:** lista pessoal de obras do usuário, com estados de consumo predefinidos.
- **Coleção:** classificação dentro de um Realm. Uma obra pode estar em várias coleções, como “Favoritos” e “Metroidvanias”.
- **Review:** avaliação com nota obrigatória e texto opcional. Em Jogos, cada usuário pode manter uma Review por jogo/plataforma.

O catálogo terá uma página única por jogo, agregando suas plataformas. No Backlog, o estado e a avaliação serão independentes por plataforma. A apresentação pessoal será agregada enquanto houver uma única plataforma do jogo no Backlog, distinguindo as versões quando houver mais de uma. Backlogs e avaliações serão públicos; a interação prevista nas avaliações é por votos “Útil” ou “Não útil”.

Ao adicionar outra plataforma de um jogo já presente no Backlog, ela entra automaticamente nas coleções já associadas ao jogo.

Reviews podem ser publicadas nos estados Jogando, Concluído, Em espera ou Abandonei, com e-mail confirmado. O estado Quero jogar/To do não permite avaliação. Remover uma entrada do Backlog ou retorná-la a Quero jogar também remove a Review daquela plataforma.

A média da comunidade considera todas as Reviews com o mesmo peso, inclusive avaliações do mesmo usuário em plataformas diferentes. Ela mantém a precisão para classificação e é exibida truncada em duas casas decimais: `8,678 → 8,67`. O arredondamento para cima em passos de 0,5 fica restrito à nota individual calculada por subnotas, recurso posterior à POC.

## Primeira entrega: POC web

Toda a interface deverá oferecer português e inglês desde a primeira entrega.

O idioma será detectado pelo navegador, com troca manual e preferência salva no perfil. Inglês será usado quando o idioma detectado não for compatível. Títulos e sinopses usarão as traduções disponíveis na IGDB, mantendo o conteúdo original quando não houver tradução. Reviews permanecerão no idioma escrito pelo autor, sem tradução automática na POC.

A POC deve permitir o fluxo completo:

1. Navegar pelo catálogo de Jogos, buscar por nome, filtrar por gênero e plataforma e consultar os detalhes de um jogo.
2. Criar uma conta e autenticar-se por e-mail/senha, Google ou Steam, com apelido público único e e-mail obrigatório e confirmado antes de adicionar jogos ao Backlog ou publicar Reviews.
3. Adicionar um jogo de uma plataforma ao Backlog.
4. Organizar o Backlog por estados e coleções.
5. Publicar uma Review com nota e texto opcional, com possibilidade de sinalizar spoilers e ocultar o texto até o leitor escolher abri-lo.

O cadastro será aberto a qualquer pessoa.

A IGDB é a fonte principal atual do catálogo de Jogos. A carga inicial terá **100 jogos distintos já lançados, selecionados por popularidade**, elegíveis quando houver lançamento já ocorrido em alguma plataforma a partir de 2025. Um jogo com várias plataformas conta uma vez, mesmo que seu lançamento original seja anterior a 2025. Remakes e remasters terão páginas próprias; DLCs e expansões também fazem parte da POC. A correspondência desses tipos e relacionamentos com os registros da IGDB será validada posteriormente.

A alimentação será restrita a administradores e jobs do Worker, com acionamento manual e execução diária às **04h, no fuso `America/Sao_Paulo`**. A administração do catálogo será feita somente por API na POC. Cada execução, manual ou agendada, terá limites independentes e configuráveis de **100 atualizações e 100 adições**. Correções administrativas serão preservadas nas sincronizações.

A página de jogo da POC terá título, capa, sinopse, gêneros, desenvolvedora/publicadora, plataformas e datas de lançamento.

A Review da POC terá apenas nota e texto opcional, com marcação de spoilers. Templates de review, votos de utilidade, página Top 100 por nota e moderação administrativa de Reviews e contas ficam para uma evolução posterior. A administração do catálogo faz parte da POC. Aplicativos mobile, comentários em reviews, recomendações e alertas de promoção ficam fora do escopo inicial.

## Bases técnicas confirmadas

| Área | Escolha atual |
| --- | --- |
| Backend | C#/.NET |
| Organização do backend | API modular com Worker separado |
| Web | Next.js |
| Idiomas da interface | Português e inglês desde a POC |
| Identidade | Keycloak |
| Provedores de login | Google e Steam; integração Steam a validar |
| Cadastro local | E-mail e senha, com autenticação no Keycloak |
| Banco do produto | PostgreSQL |
| Fonte principal de Jogos | IGDB |
| População do catálogo | Worker e ações administrativas |

A base aprovada é uma API .NET modular, com Worker separado e PostgreSQL para os dados do produto. Organização definitiva dos projetos, acesso a dados e infraestrutura ainda serão detalhados. As escolhas confirmadas não significam que as integrações já estejam implementadas.

O teto inicial é de **R$ 200/mês**, incluindo hospedagem, banco e backups. A prioridade é o menor custo financeiro, sem preferência por provedor. A [comparação inicial de hospedagem](docs/drafts/hospedagem-inicial.md) propõe avaliar uma VPS única; nenhuma oferta foi contratada.

O alvo inicial de validação é de **10 usuários simultâneos**. A capacidade efetiva será medida com a implementação e o ambiente escolhidos.

## Evolução prevista

1. Jogos: catálogo, Backlog e reviews.
2. Animes/Mangás: catálogo, Backlog e reviews.
3. Filmes/Séries: catálogo, Backlog e reviews.
4. Funcionalidades especializadas por Realm, como recomendações e alertas de promoção de jogos.

## Licença

[MIT](LICENSE).
