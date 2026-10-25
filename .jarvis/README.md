# Jarvis

Base local de desenvolvimento orientado por especificações (SDD, de
*Specification-Driven Development*) para o ReviewVerse.

Status: constituição revisada e decisões registradas até a versão 0.33.
Seis contratos adotados, com desenho e planejamento técnico sob o Arquiteto.
Oito skills descobertas no Codex e cinco perfis locais configurados e conferidos
estruturalmente. Execução independente dos perfis e testes no OpenCode e Claude
Code continuam pendentes.

A [revisão integrada](../docs/specs/features/FEAT-005-revisao-integrada-do-jarvis.md)
consolidou a consistência da base inicial, os ajustes realizados e os limites
da verificação antes do primeiro commit e do piloto de produto.

## Estrutura inicial

| Arquivo | Responsabilidade |
| --- | --- |
| [Constituição](constitution.md) | Princípios de desenvolvimento e manutenção das decisões. |
| [Fluxo](workflow.md) | Como especificar, planejar, implementar e verificar uma mudança. |
| [Contrato do Arquiteto](agents/architect.md) | Desenho, planejamento técnico e passagem aos especialistas. |
| [Specs de Épicos e Features](../docs/specs/README.md) | Hierarquia duradoura, estados, resultados e pendências. |
| [Template de Épico](templates/epic.md) | Objetivo, escopo, condições de conclusão e Features. |
| [Template de Feature](templates/feature.md) | Comportamento, critérios, dependências e evidências. |
| [Template de trabalho](templates/work.md) | Plano técnico e specs de tarefas no ciclo de execução da branch. |
| [ADRs](../docs/adr/README.md) | Contexto, decisões adotadas, consequências e vínculos de substituição. |
| [Template de ADR](templates/adr.md) | Estrutura para propor e registrar uma decisão. |
| [Versões da constituição](versions/README.md) | Cópias históricas preservadas a cada nova versão. |
| [Integração e uso](integrations/README.md) | Skills, perfis e evidências por ferramenta. |
| [AGENTS.md](../AGENTS.md) | Entrada compartilhada do Codex e OpenCode. |
| [CLAUDE.md](../CLAUDE.md) | Entrada do Claude Code, importando as instruções compartilhadas. |

Toda mudança é especificada na hierarquia Épico → Feature → tarefas do documento
de trabalho. As specs duradouras ficam em `docs/specs/epics/` e
`docs/specs/features/`, com estado, o que foi feito e o que falta para concluir.
O detalhamento da execução fica em `.jarvis/work/<feature-id>/<branch>.md`, com
um documento por branch que executa a Feature. Ajustes pequenos podem reusar
as specs existentes e acrescentar tarefas ao documento de trabalho.

Antes de remover o documento temporário, consolidar resultados e evidências na
Feature, atualizar o Épico e preservar decisões em ADRs. Enquanto houver execução
pendente, preservar o plano ou transferir seu contexto para a branch que dará
continuidade. Essa organização foi aceita no ADR-0004, versão 0.5.

O Jarvis permanece dentro deste repositório. A documentação existente continua
responsável pelo produto e pela arquitetura; a constituição define como trabalhar
com essas fontes. Novas specs fazem referência às regras existentes em vez de
reescrevê-las.

ADRs registram decisões estruturais ou relevantes de produto, arquitetura e
processo, com uma versão por decisão dessa natureza. Detalhes locais de Feature
ficam nas specs e planos. Registros anteriores permanecem preservados.
Features encerradas podem ser compactadas em histórico por Épico conforme o
artigo 2; regras vigentes e evidências mínimas continuam acessíveis.

## Uso nas ferramentas

O fechamento padrão inclui integração no GitHub após aprovação final explícita
conforme [ADR-0030](../docs/adr/0030-integracao-no-github-apos-aprovacao-final.md)
e etapa 7 do fluxo. O Coordenador faz push, cria/reutiliza PR, resolve conflitos
com revalidação e realiza merge, sem nova confirmação para ações já aprovadas.
Mudanças materiais retornam ao autor; impedimentos e resultado remoto ficam na
Feature. Concluído e aprovação da spec não comprovam aprovação final ou merge.

Abra uma sessão na raiz do repositório e peça, por exemplo:

> Use o Jarvis para especificar a primeira entrega do catálogo. Consulte as
> decisões existentes e apresente as dúvidas que mudariam o comportamento.

Para retomar, informe a Feature, a branch e a ação desejada: detalhar, implementar
ou revisar. Leia a spec da Feature, seu Épico e o documento de trabalho da branch.
O estado versionado deve bastar para continuar em outra ferramenta, sem depender
da memória da conversa anterior.

Codex e OpenCode reconhecem `AGENTS.md`; Claude Code importa esse arquivo por
`CLAUDE.md`. As instruções compartilhadas pedem a leitura explícita dos arquivos
do Jarvis. Isso oferece uma base comum sem configurações globais ou plugins.
As skills foram descobertas pelo CLI local do Codex. Execução dos perfis como
subagentes e testes no OpenCode e Claude Code não foram realizados. Consulte a
matriz de integração para os limites de cada verificação.

## Papéis e skills

| Papel | Responsabilidade | Disponibilidade |
| --- | --- | --- |
| Coordenador — Jarvis | Acompanhar execução, dependências e impedimentos e consolidar resultados. | Sessão principal; [contrato comum adotado](agents/coordinator.md). |
| Especificador | Definir necessidade, escopo e critérios de Épicos e Features. | [Contrato comum adotado](agents/specifier.md); skill `jarvis-spec`; perfil `jarvis_spec`. |
| Arquiteto | Desenhar a solução e estruturar o plano técnico com contribuições dos especialistas. | [Contrato](agents/architect.md); skill `jarvis-architect`; perfil `jarvis_architect`. |
| Especialista Backend | Implementar e testar domínio, API, persistência, Worker e integrações de servidor. | [Contrato](agents/backend.md); skill `jarvis-backend`; perfil `jarvis_backend`. |
| Especialista Frontend | Implementar e testar interface e integração com a API. | [Contrato](agents/frontend.md); skill `jarvis-frontend`; perfil `jarvis_frontend`. |
| Revisor | Revisar specs, planos e código contra critérios e evidências sem editar o alvo. | [Contrato comum adotado](agents/reviewer.md); skill `jarvis-review`; perfil `jarvis_reviewer`. |

Skills de apoio, sem novos agentes: [jarvis-cleanup](skills/jarvis-cleanup/SKILL.md)
compacta Features encerradas; [jarvis-run](skills/jarvis-run/SKILL.md) inicia o
ambiente local; [jarvis-stop](skills/jarvis-stop/SKILL.md) encerra somente recursos
que essa execução iniciou. Ver o guia de integração para exemplos e limites.

O agente principal organiza a tarefa e mantém a continuidade. Perfis são usados
quando houver delegação autorizada; não são iniciados automaticamente.
O processo também funciona em uma única sessão.

A especialização foi adotada no [ADR-0012](../docs/adr/0012-especialistas-backend-frontend-e-arquitetura.md)
e a união de Arquitetura e Planejamento técnico no
[ADR-0013](../docs/adr/0013-arquitetura-e-planejamento-tecnico.md).
O contrato Backend foi detalhado e adotado no
[ADR-0014](../docs/adr/0014-contrato-do-especialista-backend.md).
O contrato Frontend foi detalhado e adotado no
[ADR-0015](../docs/adr/0015-contrato-do-especialista-frontend.md).
O contrato do Coordenador foi detalhado e adotado no
[ADR-0016](../docs/adr/0016-contrato-do-coordenador.md).
O contrato do Especificador foi detalhado e adotado no
[ADR-0017](../docs/adr/0017-contrato-do-especificador.md).
O contrato do Revisor foi detalhado e adotado no
[ADR-0018](../docs/adr/0018-contrato-do-revisor.md), concluindo a revisão dos seis contratos.
Os especialistas detalham e ajustam suas tarefas dentro dos contratos sem exigir
novo parecer para escolhas rotineiras. Cada um escreve e executa os testes da
sua área; o Arquiteto estrutura a estratégia, incluindo integração, e o Revisor
avalia a suficiência das evidências. A
[FEAT-004](../docs/specs/features/FEAT-004-contratos-dos-agentes.md) consolida os
contratos, a configuração local e os limites da validação.

As skills comuns ficam em `.jarvis/skills/`, com links em `.agents/skills/`.
Perfis TOML ficam em `.jarvis/integrations/codex/agents/`, com links em
`.codex/agents/`. Consulte o guia de integração para exemplos de uso.

## Pontos para construir juntos

- Exercitar perfis em delegações autorizadas e avaliar seleção automática das skills.
- Configurar e testar OpenCode e Claude Code quando disponíveis.
- Avaliar as próximas Features a partir do piloto FEAT-006 já integrado.
- Detalhar convenções de implementação conforme a organização dos projetos.

## Referências de integração

Documentação oficial consultada em 19/10/2026:

- [Codex: instruções com AGENTS.md](https://developers.openai.com/codex/guides/agents-md).
- [Codex: skills](https://developers.openai.com/codex/skills).
- [Claude Code: memória e imports de CLAUDE.md](https://code.claude.com/docs/en/memory).
- [Claude Code: skills](https://code.claude.com/docs/en/skills).
- [OpenCode: regras](https://opencode.ai/docs/rules/).
- [OpenCode: skills](https://opencode.ai/docs/skills/).
