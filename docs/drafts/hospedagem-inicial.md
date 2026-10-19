# ReviewVerse — comparação inicial de hospedagem

Status: pesquisa para discussão em 19/10/2026. Nenhuma contratação ou implantação foi realizada.

## Restrições confirmadas

- Teto de R$ 200/mês, incluindo hospedagem, banco e backups.
- Prioridade para o menor custo financeiro; sem preferência por fornecedor.
- Alvo inicial de validação de 10 usuários simultâneos, com capacidade efetiva a medir na implementação.
- POC web com Next.js, backend .NET, Worker e Keycloak, incluindo login com Google e Steam.
- Base aprovada: API .NET modular, Worker separado e PostgreSQL; carga inicial de 100 jogos distintos já lançados da IGDB, selecionados por popularidade e com lançamento em alguma plataforma a partir de 2025, mesmo com lançamento original anterior.
- Worker com acionamento manual e execução diária às 04h no fuso `America/Sao_Paulo`.
- Crescimento do catálogo após a carga inicial, com limites configuráveis separados de 100 adições e 100 atualizações por execução, tanto manual quanto agendada.
- E-mail confirmado obrigatório antes de adicionar jogos ao Backlog ou publicar Reviews; o envio de mensagens deve entrar na avaliação de custo da operação.

## Direção proposta

Avaliar uma VPS única com aplicações em contêineres e PostgreSQL compartilhando a mesma máquina, com bancos e credenciais separados para produto e identidade. A escolha favorece concentrar os recursos e o custo mensal em uma máquina. É uma recomendação para cotação e teste, não uma afirmação de que qualquer VPS será suficiente ou de que existe um vencedor absoluto de preço.

Como hipótese de dimensionamento, avaliar inicialmente 8 GB de RAM. A decisão final depende do consumo medido de todos os componentes e do recorte do catálogo. Jobs de carga podem ter execução programada, e builds podem ocorrer fora do servidor da POC.

## Referências consultadas

| Opção | Referência de preço consultada | Observações |
| --- | --- | --- |
| OVHcloud VPS-2 | A partir de US$ 8,50/mês; 4 vCores, 8 GB de RAM e 75 GB NVMe. | A página anuncia backup diário. Região, condições da oferta e preço aplicável à conta brasileira precisam ser conferidos no orçamento final. |
| Hetzner CX33 na Alemanha/Finlândia | € 8,49/mês, segundo a tabela de reajuste vigente consultada. | Valor sem IVA e sem IPv4. Backup e demais itens devem ser cotados; disponibilidade do modelo precisa ser confirmada. |
| Railway | RAM a US$ 0,00000386 por GB/segundo, além de CPU, armazenamento e tráfego. | Exemplo de plataforma com cobrança por uso; o consumo real do conjunto determina o custo. O mínimo do plano Hobby é US$ 5, com esse valor incluído em créditos de uso. |

Fontes: [OVHcloud](https://www.ovhcloud.com/en/vps/), [tabela oficial Hetzner](https://docs.hetzner.com/general/infrastructure-and-availability/price-adjustment/), [preços Railway](https://railway.com/pricing).

Para ilustrar a cobrança por uso da Railway, 4 GB médios de RAM durante 30 dias corresponderiam a aproximadamente US$ 40 apenas de memória. Esse é um cenário hipotético, não uma medição da POC nem uma equivalência de desempenho entre fornecedores. CPU, disco e tráfego seriam adicionais. Os preços e esse cenário apoiam priorizar a cotação de uma VPS; não provam que toda solução gerenciada custará mais para qualquer carga.

Os valores estrangeiros acima não foram convertidos para reais: o câmbio efetivo de pagamento e os tributos precisam entrar na cotação antes da escolha.

## Orçamento-alvo interno

Os limites abaixo são uma proposta de distribuição do teto, não preços obtidos de fornecedores:

| Item | Limite mensal proposto |
| --- | --- |
| Máquina, endereço de rede e custos de cobrança associados | R$ 120 |
| Backups adicionais e armazenamento externo | R$ 30 |
| Margem para câmbio, crescimento e outras despesas | R$ 50 |
| **Total** | **R$ 200** |

A cotação deve verificar o custo completo, inclusive eventual compromisso de contratação, preço de renovação e armazenamento de backups. O backup anunciado de uma VPS precisa ser complementado por uma estratégia de restauração consistente dos bancos.

## Efeitos da proposta

Uma máquina única concentra a falha do servidor em todos os componentes da POC. A operação proposta inclui atualizações, persistência em volumes, backups e restauração verificada. A recuperação e as metas iniciais de indisponibilidade precisam ser definidas antes da abertura aos usuários.

A configuração deve permitir transferir banco, Worker ou API para máquinas separadas conforme o uso justificar o custo. Essa evolução exige planejamento e pode ultrapassar o teto inicial.

## Próximas validações

1. Escolher e validar a integração Steam com Keycloak, seguindo a base de arquitetura aprovada.
2. Detalhar o armazenamento dos metadados e correções administrativas, o envio de e-mail e o cenário de carga com 10 usuários simultâneos. O dimensionamento deve considerar o catálogo em crescimento e o acionamento manual de novas cargas, além dos 100 jogos iniciais.
3. Medir memória, CPU, disco e duração dos jobs no conjunto de componentes.
4. Cotar a oferta disponível à conta, com custo total em reais e backups.
5. Comparar o resultado ao teto antes de escolher fornecedor e plano.
