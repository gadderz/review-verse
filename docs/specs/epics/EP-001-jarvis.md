# EP-001 — Jarvis para o ReviewVerse

Estado: Em andamento

## Objetivo e escopo

Construir com o autor um processo local de desenvolvimento por especificações,
com constituição, decisões rastreáveis e continuidade entre sessões e ferramentas.
Esta spec organiza o trabalho do próprio Jarvis. O produto ReviewVerse continua
definido na documentação de visão e arquitetura.

## Fontes e decisões

- [Guia do Jarvis](../../../.jarvis/README.md).
- [Índice de ADRs](../../adr/README.md).
- [ADR-0004 — Hierarquia e documento de trabalho](../../adr/0004-especificacoes-hierarquicas-e-documento-de-trabalho.md).

## Condições de conclusão

- Princípios da constituição revisados com o autor e decisões registradas.
- Modelo de especificação e acompanhamento definido e documentado.
- Uso da base compartilhada verificado em sessões de Codex, Claude Code e
  OpenCode, com limitações registradas.

## Features

| Feature | Estado | Resultado e pendências |
| --- | --- | --- |
| [FEAT-001 — Especificações hierárquicas](../features/FEAT-001-especificacoes-hierarquicas.md) | Concluído | Modelo aplicado, templates separados e evidências consolidadas na spec da Feature. |
| [FEAT-002 — Revisão da constituição](../features/FEAT-002-revisao-da-constituicao.md) | Concluído | Revisão inicial concluída na versão 0.10; decisões e evidências consolidadas. |
| [FEAT-003 — Skills e perfis no Codex](../features/FEAT-003-skills-e-perfis-no-codex.md) | Concluído | Skills descobertas no CLI; perfis verificados estruturalmente; evidências e limites consolidados. |
| [FEAT-004 — Contratos dos agentes](../features/FEAT-004-contratos-dos-agentes.md) | Concluído | Seis contratos adotados; cinco skills descobertas no Codex e cinco perfis conferidos estruturalmente. Evidências e limites consolidados. |
| [FEAT-005 — Revisão integrada](../features/FEAT-005-revisao-integrada-do-jarvis.md) | Concluído | Três desalinhamentos corrigidos; integridade, formatos, descoberta e cópia isolada conferidos. Base inicial pronta para commit e piloto no Codex, com limites registrados. |
| [FEAT-007 — Integração no GitHub após aprovação final](../features/FEAT-007-integracao-no-github-apos-aprovacao-final.md) | Concluído | Padrão verificado, aprovado e branch publicada; PR/merge aguardam corrigir o acesso e integrar FEAT-006. |

O inventário de Features deste Épico ainda está em detalhamento. As condições
restantes não são entregas concluídas nem Features implicitamente aprovadas.

## O que já foi feito

- Criada a base de constituição, fluxo e entradas compartilhadas.
- Registradas as decisões de testes, commits e ADRs nas versões 0.2 a 0.4.
- Aceita a organização hierárquica no ADR-0004, versão 0.5.
- Concluída a FEAT-001 com documentação verificada e resultados consolidados.
- Revisado o artigo 1 na FEAT-002 e registrada a decisão no ADR-0005, versão 0.6.
- Revisado o artigo 3 e registrada a decisão no ADR-0006, versão 0.7.
- Revisado o artigo 4 e registrada a decisão no ADR-0007, versão 0.8.
- Revisado o artigo 6 e registrada a decisão no ADR-0008, versão 0.9.
- Revisado o artigo 7 e registrada a decisão no ADR-0009, versão 0.10.
- Concluída a FEAT-002 com nove artigos confirmados, histórico e evidências preservados.
- Concluída a FEAT-003: skills e perfis locais do Codex com decisões nos ADRs
  0010 e 0011, até a versão 0.12, e evidências consolidadas.
- Adotada a especialização Backend, Frontend e Arquitetura no ADR-0012, versão
  0.13; contratos e configuração permanecem em definição na FEAT-004.
- Adotada a união de Arquitetura e Planejamento técnico no ADR-0013, versão
  0.14; contrato comum e passagem do Especificador alinhados.
- Adotado o contrato Backend no ADR-0014, versão 0.15, e preparada a proposta
  Frontend para revisão com o autor.
- Adotado o contrato Frontend no ADR-0015, versão 0.16, e preparada a proposta
  do Coordenador para revisão com o autor.
- Adotado o contrato do Coordenador no ADR-0016, versão 0.17, e preparada a
  proposta do Especificador para revisão com o autor.
- Adotado o contrato do Especificador no ADR-0017, versão 0.18, e preparada a
  proposta do Revisor para concluir a revisão dos seis contratos.
- Adotado o contrato do Revisor no ADR-0018, versão 0.19; seis contratos
  revisados e fontes dos novos perfis e skills preparadas para instalação.
- Concluída a FEAT-004: seis contratos revisados, cinco skills descobertas como
  habilitadas no Codex e cinco perfis conferidos estruturalmente. Sem execução
  independente dos perfis; evidências e limites consolidados na Feature.
- Concluída a FEAT-005: revisão integrada do SDD, três desalinhamentos corrigidos
  e base inicial conferida para commit e piloto no Codex, incluindo cópia isolada.

- Exercitado o processo na FEAT-006, com consulta de produto e evidências
  consolidadas. O uso independente de perfis não foi comprovado por esse piloto.
- Registrado o fechamento no GitHub após aprovação final no ADR-0030/FEAT-007,
  sem antecipar resultado de publicação ou merge.

## O que falta

- Detalhar as próximas Features do Jarvis com o autor.
- Concluir o acompanhamento do fechamento remoto após aprovação final e
  continuar avaliando o processo com as próximas Features.
- Verificar a base em sessões reais das três ferramentas.
- OpenCode aguarda configuração e Claude Code aguarda instalação; seus testes
  não foram executados. Exercício independente dos perfis e seleção automática
  no Codex também não foram realizados nesta etapa.

## Próxima ação

Resolver o acesso do conector GitHub aos PRs (HTTP 403) e concluir a integração
das duas entregas já aprovadas e publicadas, conforme a retomada nas Features.
O exercício independente dos perfis, a avaliação da seleção automática e a
validação nos outros clientes permanecem pendentes e serão tratados conforme
as próximas autorizações e a disponibilidade das ferramentas.
