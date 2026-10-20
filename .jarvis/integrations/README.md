# Integração e uso do Jarvis

A configuração local do Codex foi concluída na FEAT-004. OpenCode e Claude Code
aguardam disponibilidade, conforme o
[ADR-0010](../../docs/adr/0010-validacao-inicial-no-codex.md).

## Estado das ferramentas

| Recurso | Preparação e resultado |
| --- | --- |
| Codex — cinco skills | `jarvis-spec`, `jarvis-architect`, `jarvis-backend`, `jarvis-frontend` e `jarvis-review` passaram no validador oficial. O CLI 0.163.0 retornou as cinco habilitadas, com escopo `repo`, em `skills/list` com recarga forçada. |
| Codex — cinco perfis | `jarvis_spec`, `jarvis_architect`, `jarvis_backend`, `jarvis_frontend` e `jarvis_reviewer` configurados; TOML, fontes e vínculos conferidos. Execução como subagentes não realizada. |
| Coordenador | Atua na sessão principal conforme o [contrato comum](../agents/coordinator.md); sem exigir skill ou perfil separado. |
| OpenCode | Configuração pendente; teste não executado. |
| Claude Code | Instalação pendente; teste não executado. `CLAUDE.md` compartilha as instruções; adaptadores de skills ainda não instalados. |

Os seis contratos foram adotados nos ADRs 0013 a 0018. A matriz distingue os
contratos aprovados, a instalação local e os limites da verificação. Evidências
consolidadas na [FEAT-004](../../docs/specs/features/FEAT-004-contratos-dos-agentes.md);
a etapa inicial está na [FEAT-003](../../docs/specs/features/FEAT-003-skills-e-perfis-no-codex.md).

A consulta local iniciou o app-server, usou `initialize`, `skills/list` e
`config/read` e encerrou o processo, sem iniciar threads ou turnos de modelo.
`config/read` não expôs uma lista de perfis; não comprova que eles foram
executados. A validação dos perfis foi estrutural. Seleção automática das skills
e comportamento dos agentes ainda não foram avaliados independentemente.

## Papéis, fontes e descoberta

| Papel | Contrato comum | Skill | Perfil Codex |
| --- | --- | --- | --- |
| Coordenador | [coordinator.md](../agents/coordinator.md) | Sessão principal | Sessão principal |
| Especificador | [specifier.md](../agents/specifier.md) | [jarvis-spec](../skills/jarvis-spec/SKILL.md) | [jarvis_spec](codex/agents/jarvis_spec.toml) |
| Arquiteto | [architect.md](../agents/architect.md) | [jarvis-architect](../skills/jarvis-architect/SKILL.md) | [jarvis_architect](codex/agents/jarvis_architect.toml) |
| Especialista Backend | [backend.md](../agents/backend.md) | [jarvis-backend](../skills/jarvis-backend/SKILL.md) | [jarvis_backend](codex/agents/jarvis_backend.toml) |
| Especialista Frontend | [frontend.md](../agents/frontend.md) | [jarvis-frontend](../skills/jarvis-frontend/SKILL.md) | [jarvis_frontend](codex/agents/jarvis_frontend.toml) |
| Revisor | [reviewer.md](../agents/reviewer.md) | [jarvis-review](../skills/jarvis-review/SKILL.md) | [jarvis_reviewer](codex/agents/jarvis_reviewer.toml) |

Os contratos e procedimentos ficam em `.jarvis/`. As cinco skills têm links de
descoberta em `.agents/skills/`; os cinco perfis TOML têm links em `.codex/agents/`.
Os arquivos apontados pertencem ao próprio repositório. Não houve instalação global.
Os adaptadores de outros clientes deverão reutilizar as fontes comuns.

## Usar no Codex

Na raiz do repositório, indique a Feature e o recorte. Exemplos de pedidos:

```text
$jarvis-spec Especifique a Feature indicada com base nas decisões atuais.
Mantenha dúvidas como propostas e não implemente código do produto.
```

```text
$jarvis-architect Planeje a execução da Feature indicada.
Detalhe contratos, tarefas, dependências e verificações no documento de trabalho.
```

```text
$jarvis-backend Implemente as tarefas Backend autorizadas da Feature indicada.
Execute as verificações pertinentes e registre resultados e pendências.
```

```text
$jarvis-frontend Implemente as tarefas Frontend autorizadas da Feature indicada.
Verifique os fluxos e diferencie dados simulados de integração com a API real.
```

```text
$jarvis-review Revise a FEAT-004 contra seus critérios e evidências.
Relate achados e limitações sem alterar arquivos.
```

A seleção automática continua permitida pelo padrão das skills. Se uma skill
nova não aparecer no cliente, reabra a sessão na raiz do repositório. Carregar
uma skill na sessão principal não inicia outro agente.

Quando a tarefa autorizar delegação, os cinco perfis podem orientar agentes
separados. Não há execução automática. Modelo, raciocínio e permissões não foram
fixados nos perfis; o ambiente aplica a herança. Revisão sem edição é uma
instrução do papel e não cria um sandbox separado.

## Referências oficiais

Documentação consultada para esta configuração:

- [Skills e descoberta local](https://learn.chatgpt.com/docs/build-skills).
- [Perfis de agentes e herança](https://learn.chatgpt.com/docs/agent-configuration/subagents).

A consulta às fontes oficiais e a conferência de formato não substituem as
evidências locais nem o exercício independente ainda pendente.
