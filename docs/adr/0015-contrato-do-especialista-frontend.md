# ADR-0015 — Contrato do Especialista Frontend

Estado: Aceito
Versão da constituição: 0.16
Origem da autorização: o autor respondeu “atende” à proposta de responsabilidades,
autonomia, testes, entregas e passagem de trabalho do Especialista Frontend.
Substitui: nenhum; detalha o ADR-0012 conforme a organização do ADR-0013.
Substituído por: nenhum.

## Contexto

As especialidades e sua relação com o Arquiteto já estavam definidas nos
[ADRs 0012](0012-especialistas-backend-frontend-e-arquitetura.md) e
[0013](0013-arquitetura-e-planejamento-tecnico.md). O Backend teve seu contrato
adotado no [ADR-0014](0014-contrato-do-especialista-backend.md). Faltava detalhar
a atuação Frontend e sua responsabilidade pela experiência e verificação web.

## Decisão

Adotar o [contrato comum Frontend](../../.jarvis/agents/frontend.md) apresentado
ao autor. O especialista implementa e verifica a aplicação Next.js do recorte
autorizado: páginas, componentes, navegação, composição entre cliente e servidor,
experiência, acessibilidade, consumo da API, conta e sessão web e
internacionalização em português e inglês, conforme a Feature.

Recebe critérios, referências visuais existentes, contratos e plano técnico;
contribui com Arquiteto e Backend e detalha suas tarefas. Resolve escolhas locais
de componentes, interações, organização e refatorações pertinentes dentro do
escopo e dos contratos. Mudanças de contrato ou premissas técnicas exigem
alinhamento entre os envolvidos; mudanças materiais de fluxo, direção visual,
escopo ou decisões confirmadas seguem a discussão prevista no contrato e na
constituição.

Escreve e executa testes da sua área e os cenários de integração ou de ponta a
ponta atribuídos no plano. Entrega código, testes, textos localizados,
configurações pertinentes, progresso e evidências ao Revisor e ao Coordenador.
Evidências com dados simulados são distinguidas dos fluxos com a API real.

O papel abrange o servidor da aplicação web conforme a arquitetura. Domínio,
autorização da API e persistência do produto continuam com o Backend. O contrato
não escolhe bibliotecas nem amplia autorizações de execução ou delegação. A
conclusão do recorte Frontend não conclui automaticamente a Feature.

## Alternativas consideradas

Foi apresentada e aprovada uma proposta concreta de contrato Frontend. Não houve
comparação adicional de alternativas nesta revisão; a especialização e a divisão
com Arquitetura e Backend já estavam definidas nas decisões anteriores.

## Consequências

O contrato passa a orientar a atuação Frontend na sessão principal e os futuros
adaptadores. Skill e perfil nativo próprios ainda precisam ser configurados e
verificados na FEAT-004. A aprovação do contrato não comprova execução em outro
agente, integração pronta ou conclusão dos contratos dos demais papéis.

## Fontes afetadas

- Contrato Frontend, instruções compartilhadas, fluxo e guias do Jarvis.
- Constituição, arquivo da versão 0.16 e índices de decisões e versões.
- FEAT-004, seu documento de trabalho, EP-001 e índice de specs.
