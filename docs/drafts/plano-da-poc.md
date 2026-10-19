# ReviewVerse — roteiro de implementação da POC

Status: roteiro proposto em 19/10/2026 a partir do escopo e da arquitetura confirmados. As etapas abaixo estão planejadas; este documento não registra funcionalidades já implementadas.

Referências: [visão e regras do produto](visao-do-projeto.md), [arquitetura](arquitetura-inicial.md) e [hospedagem](hospedagem-inicial.md).

## Resultado esperado

Uma pessoa deve poder navegar pelo catálogo de Jogos, criar uma conta, confirmar o e-mail, organizar o Backlog e publicar uma Review com nota e texto opcional. A interface oferece português e inglês desde o início. O cadastro é aberto.

O catálogo inclui DLCs e expansões; remakes e remasters têm páginas próprias. O alvo inicial de validação é de 10 usuários simultâneos, dentro do teto de R$ 200/mês. A capacidade efetiva depende das medições na implementação.

## Etapas propostas

| Etapa | Entregas | Evidência de conclusão |
| --- | --- | --- |
| 1. Base da aplicação | Estrutura da API .NET modular, Worker separado, PostgreSQL e web Next.js; configuração dos ambientes e base de internacionalização. | Web, API e dependências funcionam no ambiente de desenvolvimento; persistência tem migrações controladas; interface permite alternar português e inglês. |
| 2. Catálogo e Worker | Carga inicial da IGDB, persistência de jogos e plataformas, sincronização, correções administrativas, busca por nome e filtros de gênero/plataforma. | Há 100 jogos distintos elegíveis selecionados por popularidade; detalhes e filtros funcionam sem duplicar jogos por plataforma; reexecução não duplica registros e preserva correções administrativas. |
| 3. Conta e perfil | Keycloak com e-mail/senha, Google e Steam; e-mail obrigatório e confirmado; apelido público único; preferência de idioma. | Os três fluxos de acesso resultam em perfil utilizável; usuário sem e-mail confirmado não adiciona jogos ao Backlog nem publica Reviews; apelido duplicado é recusado. |
| 4. Backlog e coleções | Entrada por jogo/plataforma, estados de consumo e coleções por Realm, com inclusão automática da nova plataforma nas coleções já associadas ao jogo. | O mesmo jogo mantém estados independentes em duas plataformas; coleções ficam no Realm correspondente; a apresentação distingue versões quando necessário. |
| 5. Reviews e médias | Uma Review por usuário/jogo/plataforma, edição e exclusão, estados permitidos, spoilers e média da comunidade. | Nota inteira de 1 a 10 e texto opcional; Quero jogar bloqueia publicação e remove Review existente ao retornar a esse estado; exclusão do Backlog remove sua Review; média tem peso igual por avaliação e exibição truncada em duas casas. |
| 6. Validação da POC e operação | Verificação do fluxo completo, autorização administrativa do catálogo, logs, consumo de recursos, backups e restauração. | O fluxo funciona nos dois idiomas e nos três métodos de login; comportamento medido para o alvo de 10 usuários simultâneos; limites do Worker e preservação de dados verificados; ambiente cabe no orçamento validado de até R$ 200/mês. |

O login Steam depende de validar a extensão ou o adaptador descrito na arquitetura. Essa validação técnica deve acontecer cedo, durante a preparação da base, para orientar o fluxo de identidade e o dimensionamento; a ordem funcional de entrega continua catálogo, Backlog e Reviews.

A administração do catálogo será feita apenas por API na POC, incluindo autorização de operações administrativas e do acionamento manual do Worker. Sua implementação deve acompanhar as etapas de Catálogo e Identidade. A moderação de Reviews e contas permanece adiada.

## Regras operacionais do Worker

- Execução manual por administrador e agendada diariamente às 04h no fuso `America/Sao_Paulo`, com cron `0 4 * * *` e horário configurável.
- Por execução, até 100 jogos atualizados e até 100 jogos adicionados, com limites independentes e configuráveis.
- Elegibilidade por lançamento já ocorrido em alguma plataforma a partir de 2025, mesmo com lançamento original anterior. Uma obra com várias plataformas conta como um jogo. Títulos com apenas lançamento futuro ficam fora da importação.
- Remakes e remasters têm páginas próprias; validar posteriormente sua correspondência na IGDB.
- Novos jogos podem ampliar o catálogo além dos 100 iniciais.
- Correções administrativas devem permanecer preservadas durante a sincronização.

## Validações que orientam a implementação

As verificações devem cobrir os comportamentos de domínio que podem quebrar o fluxo principal:

- Duplicidade de jogo/plataforma na importação e de apelido no cadastro, inclusive em operações concorrentes.
- Independência de estado e Review entre plataformas do mesmo jogo.
- Remoção da Review ao excluir a entrada ou retornar a Quero jogar, com reflexo nas médias.
- Média calculada por Review, com mesmo peso para avaliações de plataformas diferentes, sem quantização de 0,5 na média da comunidade.
- Exibição de spoilers somente após ação do leitor, mantendo a nota disponível.
- Regras de e-mail confirmado e de autorização também aplicadas pela API.
- Fallback de idioma e de conteúdo original quando não houver tradução na fonte.
- Limites do Worker, repetição de carga e preservação de correções manuais.

Esses itens são critérios de validação para o trabalho futuro, não resultados de testes já executados. As ferramentas e a divisão dos testes serão definidas com a implementação.

## Escopo posterior

- Templates e subnotas, votos de utilidade e página Top 100 por nota.
- Moderação administrativa de Reviews e contas.
- Realms de Animes/Mangás e Filmes/Séries.
- Recomendações e alertas de promoção.
- Aplicativos para outras plataformas.

Comentários em Reviews permanecem fora do escopo atual, sem entrega planejada confirmada.

## Decisões pendentes antes de fechar os detalhes

- Correspondência de remakes, remasters, DLCs e expansões na IGDB e seus relacionamentos.
- Implementação Steam e envio/confirmação de e-mail.
- Detalhes de busca, paginação e organização dos projetos.
- Provedor de hospedagem, consumo medido com 10 usuários simultâneos e metas de latência e recuperação.

Nenhuma data de entrega foi definida. O roteiro organiza a implementação sem alterar o estado atual do código.
