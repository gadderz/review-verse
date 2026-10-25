# ADR-0030 — Integração no GitHub após aprovação final

Estado: Aceito
Versão da constituição: 0.31
Origem da autorização: pedido explícito do autor em 25/10/2026 para tornar push,
merge no GitHub e resolução de conflitos um passo padrão após a aprovação final
da Feature.
Substitui: nenhum; complementa o encerramento e a responsabilidade do Coordenador.
Substituído por: nenhum.

## Contexto

O fluxo consolida evidências e commits locais, mas não define a integração
remota como etapa padrão. A FEAT-006 foi entregue em uma branch local; isso não
comprova publicação ou merge. O autor quer que o Jarvis execute essas ações
depois de aprovar a entrega final.

## Decisão

Após a aprovação final explícita do autor, o Coordenador envia a branch por
push, cria ou reutiliza o pull request e realiza o merge no GitHub para a
branch de destino acordada. Na ausência de destino indicado, conferir a branch
padrão do repositório remoto antes de usá-la como base. A autorização concedida
permanece válida; não solicitar nova confirmação para cada comando ou para
resolver conflitos rotineiros.

Atualizar a visão da base remota. Se houver conflitos, integrar a base na
branch da Feature, resolver preservando as contribuições, repetir verificações
pertinentes às áreas alteradas e atualizar a revisão conforme o impacto antes
de enviar a resolução e realizar o merge. Não descartar silenciosamente mudanças
remotas. Mudanças materiais de comportamento ou escopo retornam ao autor.

Respeitar verificações e regras de merge do repositório. Se houver impedimento
de acesso, verificação, revisão ou conflito material, registrar estado real,
causa e próxima ação. Confirmar o resultado remoto antes de declarar integração
concluída. Registrar na Feature aprovação, branches, commits, URL do PR,
resultado do merge e eventuais conflitos/validações.

Concluído, commit local e revisão favorável não substituem aprovação final nem
comprovam integração remota. Esta decisão registra a regra; não concede por si
só aprovação final à FEAT-006 ou a outra entrega. Reaproveitar a aprovação
explícita já existente na sessão.

## Alternativas consideradas

O fluxo anterior terminava na consolidação local. O autor pediu acrescentar
push e merge após sua aprovação final. Não houve comparação de métodos de
merge; seguir as opções e convenções do repositório sem fixar squash, rebase
ou merge commit como regra universal.

## Consequências

O Coordenador acompanha também a integração no GitHub. Templates e specs
distinguem verificação técnica, aprovação e resultado remoto e preservam
retomada da integração pendente. A regra não comprova autenticação, push, PR
ou merge já executados.

## Fontes afetadas

- Artigo 6 da constituição 0.31, fluxo e guia do Jarvis.
- Contrato do Coordenador, templates de Feature/trabalho e AGENTS.md.
- [FEAT-007](../specs/features/FEAT-007-integracao-no-github-apos-aprovacao-final.md),
  [EP-001](../specs/epics/EP-001-jarvis.md) e índices de specs, ADRs e versões.
