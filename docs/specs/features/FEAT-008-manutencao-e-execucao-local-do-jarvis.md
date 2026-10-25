# FEAT-008 — Manutenção e execução local do Jarvis

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Em andamento

## Necessidade e escopo

Reduzir a documentação de Features encerradas, reservar ADRs para decisões
relevantes e permitir iniciar/parar o ambiente local para uso manual do autor.
Pedido de 25/10/2026 autoriza criar as skills e ajustar a política. A explicitação
do commit do plano foi autorizada diretamente, dispensando rito próprio.

## Critérios

| ID | Resultado observável |
| --- | --- |
| AC-01 | Plano deve ter commit antes da implementação e histórico conferido antes de sua remoção. |
| AC-02 | jarvis-cleanup define elegibilidade, histórico mínimo, preservação de contratos/ADRs e atualização de referências; não limpa Features existentes sem pedido. |
| AC-03 | jarvis-run permite iniciar o recorte funcional atual e dependências, preparar dados locais e informar URLs, logs e limites reais. |
| AC-04 | jarvis-stop encerra somente recursos iniciados pela execução gerenciada; preserva processos alheios e volumes. |
| AC-05 | ADRs ficam restritos a decisões estruturais/relevantes; escolhas locais ficam nas specs/planos, com política coerente nas fontes e histórico anterior preservado. |
| AC-06 | Skills, links, scripts e comportamentos de ciclo de vida são verificados; limites do teste real ficam explícitos. |

## Progresso e decisões

- Plano em `.jarvis/work/FEAT-008/feat-008-jarvis-maintenance.md`, versionado
  antes da implementação das skills.
- Recomendação de limpeza: consolidação por Épico de Features concluídas,
  aprovadas, integradas e sem pendências; sem prazo arbitrário para apagar arquivos.
- Execução cobre o Catálogo funcional. Worker e Frontend não são entregas prontas.
- Não inclui executar limpeza do acervo, iniciar serviços para uso permanente,
  alterar código de produto nem publicar/mesclar esta Feature sem aprovação final.

## Evidências e pendências

Implementação e verificações pendentes. ADRs de evolução serão vinculados aqui.

## Aprovação e integração

Implementação autorizada pelo pedido acima. Aprovação final, push, PR e merge
desta entrega ainda não realizados.
