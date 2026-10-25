# FEAT-008 — Manutenção e execução local do Jarvis

Épico: [EP-001 — Jarvis](../epics/EP-001-jarvis.md)
Estado: Concluído

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

- Plano inicial recuperável no commit `c1403d0`, antes da implementação das skills.
- [ADR-0031](../../adr/0031-adrs-proporcionais-ao-impacto.md), versão 0.32:
  decisões relevantes em ADR; escolhas de Feature em specs/planos.
- [ADR-0032](../../adr/0032-compactacao-de-features-encerradas.md), versão 0.33:
  histórico por Épico, com contratos vigentes acessíveis e recuperação no Git.
- Recomendação de limpeza: consolidação por Épico de Features concluídas,
  aprovadas, integradas e sem pendências; sem prazo arbitrário para apagar arquivos.
- Execução cobre o Catálogo funcional. Worker e Frontend não são entregas prontas.
- Não inclui executar limpeza do acervo, iniciar serviços para uso permanente,
  alterar código de produto nem publicar/mesclar esta Feature sem aprovação final.

## Evidências e pendências

| Critério | Resultado |
| --- | --- |
| AC-01 | Passou: regra no fluxo, AGENTS, Arquiteto e template; plano no commit c1403d0 antes dos scripts/skills. |
| AC-02 | Passou na revisão das instruções: exige aprovação/merge e ausência de pendências, preserva contratos, evidências, registros imutáveis e referências. Não houve limpeza real do acervo. |
| AC-03 | Passou no macOS/OrbStack: start com migração, seed, HTTP 200 com resultado para acao, start repetido reutilizando os mesmos recursos e URLs da API/Scalar. Também exercitado --no-seed. |
| AC-04 | Passou: parada real removeu o registro e parou o contêiner iniciado, preservando volume. Oito testes de propriedade/recuperação passaram, incluindo PID divergente, processo alheio, porta ocupada, contêiner reutilizado, labels divergentes e falha parcial. |
| AC-05 | Passou: fontes atuais alinhadas, snapshot 0.33 idêntico, histórico anterior preservado; ADR-0003 alterado somente em estado e vínculo ao substituto. |
| AC-06 | Passou: oito skills no validador oficial e descobertas como enabled/repo em skills/list; 488 links locais em 79 documentos sem referência quebrada e git diff --check. |

Verificações em 25/10/2026. Testes do auxiliar:
`python3 -m unittest discover -s .jarvis/scripts -p 'test_*.py' -v`.
Validador oficial do skill-creator com PyYAML instalado apenas em diretório
temporário. Consulta de descoberta usou initialize/skills/list, sem turnos de
modelo nem agentes independentes. Testes de sockets/processos exigiram execução
fora do sandbox após permissão; a primeira tentativa foi bloqueada pelo ambiente.

Docker estava indisponível na primeira consulta e depois respondeu; o fluxo
real de preparação e parada foi executado com sucesso. Não ficaram processos
gerenciados ativos. A opção de identidade está documentada, mas seu startup e
readiness funcional não foram exercitados; Worker/Frontend não foram iniciados.
Código de produto, testes .NET e Compose não foram alterados.

Nenhuma pendência nos critérios deste recorte. Aprovação final e integração
continuam pendentes abaixo. O documento de trabalho é mantido para essa retomada.

## Aprovação e integração

Implementação autorizada pelo pedido acima. Aprovação final, push, PR e merge
desta entrega ainda não realizados.
