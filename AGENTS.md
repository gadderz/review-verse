# Jarvis — instruções do ReviewVerse

Jarvis é o processo local de desenvolvimento orientado por especificações deste
repositório. A revisão inicial da constituição foi concluída com o autor;
as skills locais estão descritas em `.jarvis/integrations/README.md`.

## Leitura inicial

Leia [a constituição](.jarvis/constitution.md) e [o fluxo](.jarvis/workflow.md)
antes de trabalhar. Leia os arquivos de fato; links neste documento não garantem
que a ferramenta carregue o conteúdo automaticamente.

Consulte [o índice do projeto](docs/README.md) e carregue apenas os documentos
pertinentes à tarefa. Para o funcionamento do Jarvis e suas propostas de evolução,
consulte [.jarvis/README.md](.jarvis/README.md).

O Arquiteto reúne desenho e planejamento técnico, conforme o ADR-0013. Ao assumir
esse papel, ler [.jarvis/agents/architect.md](.jarvis/agents/architect.md).
Ao assumir Backend, ler o [contrato da especialidade](.jarvis/agents/backend.md),
adotado no ADR-0014.
Ao assumir Frontend, ler o [contrato da especialidade](.jarvis/agents/frontend.md),
adotado no ADR-0015.
Ao coordenar a execução na sessão principal, ler o
[contrato do Coordenador](.jarvis/agents/coordinator.md), adotado no ADR-0016.
Ao especificar Épicos e Features, ler o
[contrato do Especificador](.jarvis/agents/specifier.md), adotado no ADR-0017.
Ao revisar specs, planos ou implementação, ler o
[contrato do Revisor](.jarvis/agents/reviewer.md), adotado no ADR-0018.
Backend e Frontend detalham e ajustam suas tarefas dentro dos contratos; o
Coordenador acompanha execução e consolida resultados. As cinco skills e os
cinco perfis locais do Codex estão descritos no guia de integração; descoberta
e formato não comprovam execução independente dos perfis.

Consulte os [ADRs](docs/adr/README.md) pertinentes antes de decidir. Cada decisão
adotada deve gerar um novo ADR e uma nova versão da constituição, conforme o
artigo 9; preserve os registros e as versões anteriores.

Toda mudança deve ter spec na hierarquia Épico → Feature → tarefas do documento
de trabalho da branch, conforme o artigo 2. Consulte `docs/specs/README.md` para
os vínculos e estados. Consolide resultados e evidências na Feature e decisões
nos ADRs antes de remover o documento temporário.

## Contexto essencial

- A POC ainda será construída. A arquitetura aprovada é API .NET modular, Worker
  separado, PostgreSQL, Next.js e Keycloak. A organização definitiva dos módulos
  permanece em detalhamento.
- O Catálogo tem consulta pública por nome, biblioteca do módulo, persistência
  PostgreSQL e testes, conforme FEAT-006. A API de Reviews e o Worker permanecem
  iniciais; os projetos usam `net10.0` e a organização completa continua pendente.
- Visão e arquitetura em `docs/drafts/` contêm decisões confirmadas e propostas
  explicitamente identificadas. O nome da pasta não torna tudo provisório.
- Para comportamento de produto, consulte `docs/drafts/visao-do-projeto.md`;
  para desenho técnico, `docs/drafts/arquitetura-inicial.md`. O histórico em
  `docs/referencias/` preserva decisões superadas.
- Converse e escreva a documentação em português. Preserve as convenções dos
  identificadores e arquivos existentes ao alterar código.
- Para mensagens de commit, siga a convenção em inglês definida no artigo 8 da
  constituição.

## Verificação

Para mudanças .NET, o comando de compilação da solução é
`dotnet build ReviewVerse.slnx`. Verifique o SDK disponível antes de executá-lo.
O manifesto `.config/dotnet-tools.json` registra CSharpier; use a versão local
quando formatação de C# for necessária.

Há projetos de testes unitários e integrados do Catálogo em `tests/`; consulte
`docs/desenvolvimento/catalogo-local.md` para comandos e dependências. A integração
exige PostgreSQL real e conexão explícita de testes. Ainda não há aplicação
Next.js. Não invente comandos ou resultados. Para documentação, confira links
locais e execute `git diff --check`. Registre limitações de ambiente e falhas
preexistentes separadamente dos resultados da mudança.
