# ReviewVerse — histórico de decisões da descoberta

Registro das decisões de 18 e 19/10/2026. Este arquivo preserva a sequência da descoberta, inclusive hipóteses revistas e dúvidas que foram resolvidas depois. A [visão atual do projeto](../drafts/visao-do-projeto.md) é a referência para o comportamento vigente.

## Decisões da primeira rodada

- Objetivo: portfólio e produto para usuários finais, sólido e utilizável, com base inicial pequena e facilidade de crescimento.
- Problema principal: histórico e backlog de mídias espalhados entre diferentes plataformas.
- Valor central: reunir histórico e intenção de consumo em um lugar, com notas e reviews. A intenção inicial de comentários foi revista na segunda rodada; vale a definição atual de votos de utilidade.
- Ordem de expansão: games; animes e mangás; filmes e séries; funcionalidades especializadas em uma etapa avançada.

## Decisões da segunda rodada

- Vocabulário adotado: Realm, Backlog e coleção.
- Estados de consumo predefinidos, incluindo “Em espera” (on hold).
- Coleções predefinidas e criadas pelo usuário, classificando obras do Backlog.
- Avaliações por obra, com notas de 1 a 10 e zero/ausência significando “sem nota”.
- Avaliações de jogos por plataforma, com possibilidade de média simples geral do jogo.
- Backlog e avaliações públicos no escopo inicial.
- Interação por votos de utilidade; comentários em reviews fora do escopo atual.

## Decisões da terceira rodada

- Página única por jogo no catálogo, agregando as plataformas disponíveis.
- Estado de consumo independente por jogo/plataforma no Backlog do usuário.
- Review composta por nota obrigatória e texto opcional; texto sem nota não é uma Review válida.
- Possibilidade de texto livre, uso opcional do template Default ou criação de template próprio.
- Templates com subnotas por critério, na escala de 1 a 10, determinando a Nota Geral por média simples.
- Gameplay, Trilha Sonora e Direção de Arte como exemplos de critérios do Realm de Jogos, ainda sem fechar o template Default.
- Um voto de utilidade por usuário/avaliação, com possibilidade de troca ou retirada e proibição de votar na própria avaliação.

## Decisões da quarta rodada

- Subnotas opcionais, com possibilidade de marcar critérios como “não se aplica”.
- Possibilidade de atribuir nota diretamente, sem preencher subnotas.
- Notas e subnotas informadas pelo usuário apenas inteiras, na escala de 1 a 10.
- Notas individuais calculadas com subnotas em passos de 0,5, com exemplos confirmados de 8,3 → 8,5 e 9,7 → 10. A aplicação dessa regra também à comunidade, inicialmente aceita, foi substituída na décima quinta rodada.
- Reviews publicadas preservam os critérios e as subnotas originais quando um template é alterado; mudanças no template afetam as próximas Reviews.

## Decisões da quinta rodada

- Arredondamento para cima em passos de 0,5 na Nota Geral calculada com subnotas. A extensão dessa regra às médias da comunidade foi revogada na décima quinta rodada; vale a média sem essa quantização e com apresentação de duas casas decimais.
- Quando houver subnotas preenchidas, a Nota Geral vem obrigatoriamente da média delas; sem substituição manual.
- Uma única Review por usuário/jogo/plataforma, com possibilidade de edição e exclusão.

## Decisões da sexta rodada

- Coleções pertencem a um único Realm; uma obra pode participar de várias coleções dentro desse Realm.
- IGDB confirmada como fonte principal atual do catálogo de Jogos.
- Alimentação do catálogo restrita a administradores e jobs do Worker.
- Início com uma POC web; outras plataformas fora dos planos iniciais.

## Decisões da sétima rodada

- A POC web deve cobrir navegação no catálogo, criação de conta, inclusão e organização do Backlog e publicação de Review.
- C#/.NET, Next.js e Keycloak confirmados como bases técnicas atuais.
- A divisão em serviços do desenho pode ser revista na discussão de arquitetura.

## Decisões da oitava rodada

- Reviews da POC com nota obrigatória e texto opcional; templates e votos de utilidade para evolução posterior.
- Login com provedores externos na POC, ainda sem definir quais provedores.
- Sem preferência de hospedagem.
- Teto de custo inicial informado de 200 por mês; moeda e abrangência do custo ainda a confirmar.

## Decisões da nona rodada

- Google e Steam como provedores iniciais de login.
- Orçamento confirmado de R$ 200/mês para hospedagem, banco e backups.
- Prioridade para a opção de menor custo financeiro, sem preferência entre VPS e serviços gerenciados.

## Decisões da décima rodada

- Base de arquitetura aprovada: API .NET modular, Worker separado e PostgreSQL, mantendo Next.js e Keycloak.
- Carga inicial da IGDB restrita a uma seleção de jogos, com critérios e tamanho ainda a definir.
- E-mail obrigatório no perfil, inclusive para usuários que entrarem pela Steam.

## Decisões da décima primeira rodada

- Carga inicial de 100 jogos distintos com lançamento a partir de 2025, contando uma única vez cada jogo, independentemente do número de plataformas.
- Worker com acionamento manual por administrador e agendamento automático diário.
- Horário padrão delegado pelo autor e definido em 04h no fuso `America/Sao_Paulo`, com cron `0 4 * * *`.
- Confirmação de e-mail obrigatória antes de adicionar jogos ao Backlog ou publicar Reviews.

## Decisões da décima segunda rodada

- Seleção dos 100 jogos iniciais por popularidade.
- Elegibilidade por lançamento em alguma plataforma a partir de 2025, mesmo com lançamento original anterior.
- Worker atualiza jogos existentes e adiciona novos; o catálogo pode crescer além dos 100 iniciais.
- Limites separados e configuráveis, com padrão de 100 atualizações e 100 adições. A abrangência por execução ou dia ainda será confirmada.

## Decisões da décima terceira rodada

- Limites de 100 atualizações e 100 adições por execução, incluindo as execuções manuais.
- Metadados suficientes para a página de jogo na POC: título, capa, sinopse, gêneros, desenvolvedora/publicadora, plataformas e datas de lançamento.
- Correções feitas por administradores preservadas nas sincronizações do Worker.

## Decisões da décima quarta rodada

- Apresentação pessoal agregada quando há uma única plataforma do jogo no Backlog, distinguindo as versões quando o usuário tem mais de uma plataforma.
- Remover a entrada de jogo/plataforma do Backlog também remove sua Review.
- Reviews permitidas nos estados de consumo Jogando, Concluído, Em espera e Abandonei; publicação bloqueada em Quero jogar/To do.

## Decisões da décima quinta rodada

- Uma nova plataforma de jogo já presente no Backlog entra automaticamente nas coleções já associadas ao jogo.
- Retornar uma entrada a Quero jogar/To do remove sua Review.
- Cada Review tem o mesmo peso na média geral do jogo, mesmo quando um usuário avalia várias plataformas.
- Revisão da regra de arredondamento: passos de 0,5 apenas na Nota Geral de uma Review calculada por subnotas. A média da comunidade mantém precisão para classificação e admite apresentação com duas casas decimais.

## Decisões da décima sexta rodada

- Média da comunidade exibida com truncamento para duas casas decimais: 8,678 → 8,67, mantendo a precisão original para ordenação.
- Página Top 100 por nota fora da POC.
- Interface multilíngue desde o início, com português e inglês como os dois idiomas iniciais.

## Decisões da décima sétima rodada

- Usar traduções de títulos e sinopses disponíveis na IGDB, com fallback para o conteúdo original quando não houver tradução.
- Detectar o idioma pelo navegador, permitir troca manual e salvar a preferência no perfil; inglês como fallback para idioma incompatível.
- Reviews mantidas no idioma escrito pelo autor, sem tradução automática na POC.

## Decisões da décima oitava rodada

- Cadastro e login por e-mail/senha incluídos na POC, além de Google e Steam.
- Apelido público único entre todos os usuários.
- Busca por nome e filtros de gênero e plataforma incluídos na navegação do catálogo da POC.

## Decisões da décima nona rodada

- Cadastro aberto a qualquer pessoa.
- Marcação de spoilers nas Reviews incluída na POC, com texto oculto até o leitor escolher abri-lo.
- Moderação administrativa de Reviews e contas fica para uma evolução posterior à POC.

## Decisões da vigésima rodada

- Importar somente jogos já lançados, dentro do recorte de lançamento por plataforma a partir de 2025.
- Remakes e remasters com páginas próprias. Correspondência com registros da IGDB a confirmar posteriormente, conforme indicado pelo autor.
- Administração do catálogo somente por API na POC.
- A resposta sobre remakes/remasters não resolveu explicitamente a inclusão de DLCs e expansões; a questão permanece aberta.

## Decisões da vigésima primeira rodada

- DLCs e expansões incluídos na POC.
- Alvo inicial de validação de 10 usuários simultâneos. Capacidade efetiva e consumo de recursos a medir na implementação.
