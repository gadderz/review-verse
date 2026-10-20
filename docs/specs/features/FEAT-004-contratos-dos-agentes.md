# FEAT-004 — Contratos dos agentes do Jarvis

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Concluído

## Necessidade e comportamento esperado

Definir com o autor os agentes da primeira versão do Jarvis, incluindo
responsabilidades, entradas, entregas, limites e passagem de trabalho. Alinhar
os contratos às skills e aos perfis locais, com fontes comuns entre ferramentas.

## Fontes e decisões

- [Constituição](../../../.jarvis/constitution.md) e [fluxo](../../../.jarvis/workflow.md).
- [Integração e uso](../../../.jarvis/integrations/README.md).
- [ADR-0011 — Skills comuns e perfis locais](../../adr/0011-skills-comuns-e-perfis-locais.md).
- [ADR-0012 — Especializações](../../adr/0012-especialistas-backend-frontend-e-arquitetura.md).
- [ADR-0013 — Arquitetura e planejamento](../../adr/0013-arquitetura-e-planejamento-tecnico.md).
- [ADR-0014 — Backend](../../adr/0014-contrato-do-especialista-backend.md).
- [ADR-0015 — Frontend](../../adr/0015-contrato-do-especialista-frontend.md).
- [ADR-0016 — Coordenador](../../adr/0016-contrato-do-coordenador.md).
- [ADR-0017 — Especificador](../../adr/0017-contrato-do-especificador.md).
- [ADR-0018 — Revisor](../../adr/0018-contrato-do-revisor.md).

## Escopo e dependências

Inclui a discussão e adoção dos seis contratos, registro de decisões e versões,
alinhamento das instruções compartilhadas e configuração e verificação estrutural
das skills e perfis locais do Codex. Depende da base da FEAT-003 e segue seu
padrão de fontes comuns, links locais e herança de configuração.

Configuração e testes no OpenCode e Claude Code continuam adiados conforme a
orientação do autor. Esta Feature não implementa o Catálogo de Jogos nem inclui
a execução independente dos perfis ou a avaliação da seleção automática das
skills. Esses limites foram preservados nas evidências e no Épico.

## Critérios de aceitação

| ID | Resultado observável |
| --- | --- |
| AC-01 | Cada papel adotado tem propósito, entradas, entregas, responsabilidade de atualização dos artefatos e limites definidos. |
| AC-02 | O fluxo indica a passagem entre especificação, planejamento, implementação, revisão e consolidação, sem transferir ao agente a decisão de escopo do autor. |
| AC-03 | A responsabilidade por escrever e executar testes e por verificar sua suficiência fica explícita. |
| AC-04 | Skills, perfis e instruções refletem o contrato adotado; uso de papéis em uma sessão é distinguido de execução de subagentes. |
| AC-05 | Decisões adotadas têm ADR e versão; verificações e limites estão consolidados antes da conclusão. |

## O que já foi feito

- Adotados os seis contratos após revisão com o autor: Coordenador, Especificador,
  Arquiteto, Backend, Frontend e Revisor. Decisões nas versões 0.13 a 0.19.
- Arquiteto responsável por desenho e planejamento técnico, com contribuições
  e autonomia dos especialistas; Coordenador responsável por acompanhamento
  e consolidação na sessão principal.
- Backend e Frontend responsáveis pelos testes das suas áreas; Arquiteto
  estrutura estratégia e responsáveis por integração; Revisor verifica suficiência
  e evidências, preservando o trabalho revisado.
- Mantidas e alinhadas `jarvis-spec` e `jarvis-review`. Criadas `jarvis-architect`,
  `jarvis-backend` e `jarvis-frontend`, com metadados gerados pelo helper oficial.
- Configurados cinco perfis TOML sem fixar modelo, raciocínio ou permissões;
  instalados os seis novos links de descoberta, preservando os quatro existentes.
- Atualizados instruções, fluxo, guias, Épico e índices. Resultados e contexto
  consolidados antes do encerramento do documento temporário.

## Contratos e responsabilidades pelos documentos

| Papel | Fonte comum | Responsabilidade e passagem |
| --- | --- | --- |
| Coordenador | [coordinator.md](../../../.jarvis/agents/coordinator.md) | Acompanha tarefas, dependências e impedimentos e consolida resultados, estados e evidências na Feature, Épico e índices. |
| Especificador | [specifier.md](../../../.jarvis/agents/specifier.md) | Mantém necessidade, comportamento, critérios, limites e dependências nas specs e os entrega ao Arquiteto. |
| Arquiteto | [architect.md](../../../.jarvis/agents/architect.md) | Mantém desenho, contratos e plano técnico no documento de trabalho; decisões adotadas seguem ADRs e fontes técnicas. |
| Backend | [backend.md](../../../.jarvis/agents/backend.md) | Detalha e executa tarefas de servidor e mantém testes, progresso e evidências da sua área. |
| Frontend | [frontend.md](../../../.jarvis/agents/frontend.md) | Detalha e executa tarefas web e mantém testes, progresso e evidências da sua área. |
| Revisor | [reviewer.md](../../../.jarvis/agents/reviewer.md) | Produz achados e limites para os responsáveis e o Coordenador, sem editar fontes ou estados durante a revisão. |

Fluxo: autor/coordenador → especificador → arquiteto → Backend e/ou Frontend
→ revisor → coordenador. Revisão pode ocorrer antes da implementação.
Achados retornam ao responsável. Mudanças de regra, escopo ou decisões
confirmadas seguem a constituição e a autoridade do autor.

## Evidências

| Critério | Verificação e resultado |
| --- | --- |
| AC-01 | Passou: seis contratos conferidos e aprovados pelo autor, com entradas, entregas, documentos, colaboração e limites explícitos. |
| AC-02 | Passou: fluxo e contratos relacionam as passagens e distinguem decisões do autor, planejamento técnico, execução, revisão e consolidação. |
| AC-03 | Passou: contratos e procedimentos atribuem testes por área, planejamento da integração e avaliação das evidências. Não houve alteração de código do produto neste recorte. |
| AC-04 | Passou no recorte estrutural: cinco skills passaram no validador oficial; cinco TOMLs e referências conferidos; CLI local descobriu as cinco skills habilitadas com escopo `repo`. Contratos e perfis não iniciam delegação automaticamente. |
| AC-05 | Passou: ADRs e arquivos das versões correspondentes preservados; guias e acompanhamento atualizados e limitações consolidadas nesta spec e no Épico. |

Verificações locais da configuração final:

- Validador oficial `quick_validate.py`: passou para as cinco skills.
- Metadados YAML gerados e conferidos; TOML dos cinco perfis e referências
  conferidos. Nenhum perfil fixa modelo, raciocínio ou permissões.
- Codex CLI `0.163.0`: `skills/list` com recarga forçada retornou
  `jarvis-spec`, `jarvis-architect`, `jarvis-backend`, `jarvis-frontend` e
  `jarvis-review`, todas com `enabled: true`, escopo `repo` e fontes em `.jarvis/skills/`.
- A consulta usou `initialize`, `skills/list` e `config/read`, sem iniciar
  threads ou turnos de modelo. `config/read` não listou os perfis nativos;
  a evidência desses perfis é de formato, conteúdo e vínculos locais.
- `git diff --check`, links locais e espaços finais passaram nas verificações
  documentais. A constituição ficou idêntica ao arquivo da versão 0.19.
- Os 33 registros anteriores de ADRs e versões tiveram SHA-256 preservado.
  O conteúdo revisado do Revisor foi mantido, com atualização de estado e referências.
  As verificações intermediárias das adoções anteriores também preservaram o
  histórico e os conteúdos aprovados; nenhuma dessas conferências foi revisão independente.

A conferência final confirmou os dez vínculos locais das cinco skills e dos
cinco perfis, os formatos YAML/TOML e os links documentais. O documento de
trabalho da branch `main` foi encerrado após consolidar tarefas, decisões,
evidências, limitações e próxima ação nesta Feature e no Épico.

## O que falta e limites

Nenhuma pendência para os critérios desta Feature no recorte de contratos e
configuração local. Permanecem acompanhados no Épico:

- Exercício dos perfis em execução independente e avaliação da seleção automática
  das skills; não foram realizados nesta etapa.
- Configuração e testes no OpenCode e Claude Code; aguardam disponibilidade.
- Aplicação do processo a uma Feature real do produto para avaliar seu uso.

A configuração não comprova que o comportamento dos agentes foi exercitado.
O documento de trabalho temporário pode ser encerrado após a consolidação;
uma mudança futura pode reusar esta Feature e abrir outro documento por branch.

## Próxima ação

Escolher com o autor uma Feature de produto para exercitar o Jarvis no Codex.
O Épico continua Em andamento pelas validações pendentes acima.
