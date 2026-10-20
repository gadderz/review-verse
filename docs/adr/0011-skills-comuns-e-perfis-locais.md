# ADR-0011 — Skills comuns e perfis locais

Estado: Aceito
Versão da constituição: 0.12
Origem da autorização: escolha técnica dentro do escopo autorizado para configurar
skills e agentes do Jarvis, conforme o artigo 7.
Substitui: nenhum.
Substituído por: nenhum.

## Contexto

Os papéis de especificação e revisão precisam usar as mesmas regras do projeto.
O Codex documenta descoberta local de skills e perfis customizados.

## Decisão

Manter jarvis-spec e jarvis-review em .jarvis/skills, com links de descoberta em
.agents/skills. As skills consultam constituição, fluxo, specs e templates comuns.

Manter perfis TOML em .jarvis/integrations/codex/agents, com pontos de entrada
em .codex/agents. Cada perfil direciona à skill correspondente sem fixar modelo,
raciocínio ou permissões. Implementação continua na sessão principal.
Não há delegação automática.

O papel de revisão instrui o agente a não editar o trabalho revisado; não cria
sandbox independente, pois as permissões são herdadas. Outros clientes terão
configuração e validação posteriores, preservando a fonte comum.

## Alternativas consideradas

- Duplicar todo o procedimento nas configurações de cada ferramenta.
- Manter skills comuns e adaptadores locais pequenos.

A segunda opção reduz duplicação e atende ao escopo local do projeto.

## Consequências

A instalação deve preservar os vínculos com arquivos do próprio repositório.
Validar descoberta e formato é diferente de executar um agente independente;
essas evidências devem ser relatadas separadamente.

## Referências

- [Codex — skills](https://developers.openai.com/codex/skills).
- [Codex — agentes](https://developers.openai.com/codex/subagents).

## Fontes afetadas

- Histórico da constituição, versão 0.12.
- Skills, perfis, FEAT-003 e guia de integração.
