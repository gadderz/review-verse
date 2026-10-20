# ADR-0010 — Validação inicial no Codex

Estado: Aceito
Versão da constituição: 0.11
Origem da autorização: o autor definiu testes somente no Codex nesta etapa;
OpenCode aguarda configuração e Claude Code aguarda instalação.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

O Jarvis deve funcionar nas três ferramentas, mas somente o Codex está disponível
para teste nesta etapa.

## Decisão

Validar inicialmente no Codex. Manter os testes dos demais clientes pendentes no
Épico EP-001, sem bloquear a conclusão da Feature específica do Codex.
Preservar a meta de portabilidade e distinguir preparação, validação de formato,
descoberta pelo cliente e exercício do procedimento.

## Alternativas consideradas

O alvo original abrange as três ferramentas. O autor definiu a sequência inicial
conforme a disponibilidade, mantendo as outras verificações para depois.

## Consequências

A FEAT-003 pode concluir com evidências do Codex. O Épico permanece em andamento.
Esta decisão não autoriza instalar ou configurar os outros clientes agora nem
declará-los testados.

## Fontes afetadas

- Histórico da constituição, versão 0.11.
- FEAT-003, Épico EP-001 e matriz de ferramentas.
