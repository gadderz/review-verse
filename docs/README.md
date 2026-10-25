# Documentação do ReviewVerse

A descoberta inicial consolidou a proposta do produto, o escopo da POC, suas principais regras e a base de arquitetura. Os documentos distinguem decisões confirmadas de detalhes ainda propostos e validações técnicas futuras.

## Documentos atuais

| Documento | Conteúdo |
| --- | --- |
| [Visão do projeto](drafts/visao-do-projeto.md) | Problema, público, Realms, Backlog, coleções, Reviews, catálogo, idiomas e escopo da primeira entrega. |
| [Arquitetura inicial](drafts/arquitetura-inicial.md) | Base aprovada, responsabilidades dos componentes, diagrama, identidade, precisão das notas e detalhes de implementação pendentes. |
| [Roteiro da POC](drafts/plano-da-poc.md) | Sequência de implementação e critérios de conclusão e validação. As etapas estão planejadas, não executadas. |
| [Hospedagem inicial](drafts/hospedagem-inicial.md) | Restrições de orçamento, referências de preços consultadas em 19/10/2026 e proposta de dimensionamento a validar. |
| [ADRs](adr/README.md) | Decisões de produto, arquitetura e processo, com contexto, consequências e versão correspondente da constituição. |
| [Specs de Épicos e Features](specs/README.md) | Hierarquia de trabalho, estados, resultados entregues e pendências de conclusão. |
| [Catálogo local](desenvolvimento/catalogo-local.md) | Docker/OrbStack, migrações, massa controlada, contrato da consulta e testes. |

Os arquivos permanecem em `drafts/` porque o detalhamento técnico continuará durante a implementação. As decisões indicadas como confirmadas formam a base atual do projeto.

## Desenvolvimento com Jarvis

O [Jarvis](../.jarvis/README.md) reúne a constituição revisada, o fluxo de
desenvolvimento orientado por especificações e os templates deste repositório.
A revisão inicial da constituição foi concluída na versão 0.10. A
[integração das ferramentas](../.jarvis/integrations/README.md) registra skills
e perfis locais do Codex; os [contratos dos agentes](specs/features/FEAT-004-contratos-dos-agentes.md)
foram revisados, com decisões até a versão 0.19 e cinco skills descobertas no
Codex. A execução independente dos perfis ainda não foi realizada. Testes no
OpenCode e Claude Code aguardam disponibilidade. Sua base é
compartilhada entre Codex, Claude Code e OpenCode e preserva as decisões de
produto e arquitetura dos documentos acima. Toda mudança tem spec na hierarquia Épico e Feature,
com documentos duradouros em `docs/specs/`. O plano e as specs das tarefas
ficam no documento temporário de trabalho da branch; resultados e evidências
são consolidados na Feature antes de encerrar esse documento.

Decisões estruturais ou relevantes geram ADR e versão da constituição; detalhes
de Feature ficam nas specs e planos. Preservamos as cópias anteriores.
As skills `jarvis-cleanup`, `jarvis-run` e `jarvis-stop` apoiam compactação de
Features encerradas e uso manual do ambiente local, conforme a FEAT-008.
Decisões já existentes na descoberta continuam nas fontes
atuais e no histórico; sua migração integral para ADRs ainda não foi realizada.

## Referências históricas

- [Export do Miro](../ReviewVerse.pdf).
- [Histórico das decisões de descoberta](referencias/historico-de-decisoes.md).
- [README original](referencias/readme-original.md).

O histórico preserva hipóteses e regras posteriormente revistas. Para o comportamento vigente, consulte a visão do projeto e a arquitetura atual.

## Próximo detalhamento

As principais validações são a integração Steam com Keycloak, a correspondência dos tipos de conteúdo na IGDB, o fluxo de e-mail e o ambiente capaz de atender ao alvo de 10 usuários simultâneos dentro do teto de R$ 200/mês. Modelo de dados, contratos dos módulos e critérios operacionais serão detalhados seguindo o roteiro da POC.
