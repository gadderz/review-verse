# Documentação do ReviewVerse

A descoberta inicial consolidou a proposta do produto, o escopo da POC, suas principais regras e a base de arquitetura. Os documentos distinguem decisões confirmadas de detalhes ainda propostos e validações técnicas futuras.

## Documentos atuais

| Documento | Conteúdo |
| --- | --- |
| [Visão do projeto](drafts/visao-do-projeto.md) | Problema, público, Realms, Backlog, coleções, Reviews, catálogo, idiomas e escopo da primeira entrega. |
| [Arquitetura inicial](drafts/arquitetura-inicial.md) | Base aprovada, responsabilidades dos componentes, diagrama, identidade, precisão das notas e detalhes de implementação pendentes. |
| [Roteiro da POC](drafts/plano-da-poc.md) | Sequência de implementação e critérios de conclusão e validação. As etapas estão planejadas, não executadas. |
| [Hospedagem inicial](drafts/hospedagem-inicial.md) | Restrições de orçamento, referências de preços consultadas em 19/10/2026 e proposta de dimensionamento a validar. |

Os arquivos permanecem em `drafts/` porque o detalhamento técnico continuará durante a implementação. As decisões indicadas como confirmadas formam a base atual do projeto.

## Referências históricas

- [Export do Miro](../ReviewVerse.pdf).
- [Histórico das decisões de descoberta](referencias/historico-de-decisoes.md).
- [README original](referencias/readme-original.md).

O histórico preserva hipóteses e regras posteriormente revistas. Para o comportamento vigente, consulte a visão do projeto e a arquitetura atual.

## Próximo detalhamento

As principais validações são a integração Steam com Keycloak, a correspondência dos tipos de conteúdo na IGDB, o fluxo de e-mail e o ambiente capaz de atender ao alvo de 10 usuários simultâneos dentro do teto de R$ 200/mês. Modelo de dados, contratos dos módulos e critérios operacionais serão detalhados seguindo o roteiro da POC.
