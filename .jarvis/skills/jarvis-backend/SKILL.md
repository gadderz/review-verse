---
name: jarvis-backend
description: "Implementar e verificar tarefas Backend do ReviewVerse com o Jarvis: domínio, API .NET, PostgreSQL, Worker e integrações."
---

# Implementação Backend com Jarvis

Leia [AGENTS.md](../../../AGENTS.md) e o [contrato Backend](../../agents/backend.md).
Use as fontes pertinentes indicadas pelo contrato. Identifique o recorte e a
autorização existentes; pedidos só de discussão, especificação ou revisão
permanecem nesses limites.

## Preparar e implementar

Leia a Feature, seus critérios, o plano da branch, os contratos e o código real.
Detalhe as tarefas Backend no documento de trabalho. Se faltar detalhamento
técnico necessário, estruture-o conforme o contrato do Arquiteto antes do trecho
dependente, sem ampliar o escopo ou iniciar outros agentes automaticamente.

Implemente o recorte autorizado respeitando domínio, autorização da API e
limites de dados. Inclua persistência, migrações, Worker e integrações conforme
a mudança. Resolva escolhas locais dentro dos contratos; alinhe mudanças de
contrato ou premissas com os envolvidos e registre decisões adotadas conforme
a constituição.

## Verificar e entregar

Escreva e execute testes pertinentes à política do projeto, incluindo os
cenários de integração atribuídos ao Backend. Confira ferramentas e comandos
reais antes de compilar, testar ou formatar. Registre passou, falhou e não
executado, limites e exceções justificadas.

Atualize tarefas e evidências e entregue código, testes, configurações e
contratos afetados ao Revisor e ao Coordenador. Preserve pendências e próxima
ação; concluir o recorte Backend não conclui automaticamente a Feature.
