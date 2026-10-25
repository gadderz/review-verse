# Trabalho — FEAT-<NNN> — <recorte desta execução>

Feature: <ID e link da spec da Feature>
Épico: <ID e link da spec do Épico>
Branch: <nome real da branch>
Estado: Rascunho

Use em `.jarvis/work/<feature-id>/<identificador-da-branch>.md` e remova estas
instruções. Reuse o documento da mesma execução; outra branch tem seu próprio
documento. Este arquivo acompanha a execução e pode ser removido somente após
consolidar seu contexto, conforme `.jarvis/workflow.md`.

## Objetivo e resultado esperado

<Recorte da Feature a executar nesta branch e critérios relacionados.>

## Plano técnico

<Abordagem, componentes, contratos, persistência, integrações e estratégia de
verificação conforme a tarefa. Planejar testes e sua infraestrutura conforme
o artigo 5 da constituição.>

## Tarefas especificadas

### T-01 — <título>

Estado: Planejado
Atende: <critérios da Feature>
Responsável: <papel ou responsável pela execução e verificação desta tarefa>
Dependências: <tarefas, contratos ou entregas necessárias, ou nenhuma>
Objetivo: <problema desta tarefa>
Resultado esperado: <comportamento ou artefato verificável>
Arquivos ou componentes: <áreas afetadas>
Verificação prevista: <como demonstrar o resultado>
O que foi feito: <resultado real ou “nenhum”>
O que falta: <pendências ou “nenhum”>

<Repetir esta seção conforme as tarefas necessárias, mantendo o detalhe
proporcional. Não é preciso criar um arquivo separado por tarefa.>

## Evidências da execução

| Tarefa ou critério | Teste, comando ou cenário | Resultado |
| --- | --- | --- |
| T-01 / AC-01 | <Verificação realizada> | <Passou, falhou ou não executado, com evidência> |

Exceções à política de testes: <nenhuma ou motivo, risco remanescente e
verificação alternativa realizada>.

## Decisões e impedimentos

<Referenciar ADRs adotados e suas versões. Registrar hipóteses, bloqueios e
dependências ainda abertos sem promovê-los a decisões confirmadas.>

## Retomada

- O que foi feito: <situação real>.
- O que falta: <pendências>.
- Próxima ação: <ação concreta>.

## Aprovação e integração no GitHub

- Aprovação final do autor e recorte: <pendente ou referência explícita>.
- Origem, remoto, destino e PR: <conferir antes de integrar>.
- Push e merge: <não executado ou resultado confirmado e commits>.
- Conflitos e verificações afetadas: <resultado real>.
- Próxima ação da integração: <ação, responsável e impedimento ou nenhuma>.

Após aprovação final, o Coordenador executa a etapa 7 do fluxo sem repetir
pedidos de confirmação já concedidos. Preservar contexto de integração pendente
e transferir resultados reais à Feature antes de remover este arquivo.

## Consolidação para encerrar

- [ ] Resultados, pendências e evidências transferidos para a Feature.
- [ ] Decisões duradouras preservadas nos ADRs e fontes afetadas atualizadas.
- [ ] Progresso do Épico e índice de specs atualizados.
- [ ] Trabalho restante tem contexto de retomada preservado ou não há pendências.
- [ ] Registros duradouros não dependem deste arquivo para consultar evidências.
- [ ] Aprovação, push, PR, merge e conflitos têm resultado real registrado; integração pendente tem retomada preservada.

Somente após essa conferência, encerrar e remover o documento temporário.
