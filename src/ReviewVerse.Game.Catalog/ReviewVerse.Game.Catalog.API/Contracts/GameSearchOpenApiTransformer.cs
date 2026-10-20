using System.Text.Json.Nodes;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace ReviewVerse.Game.Catalog.API.Contracts;

internal sealed class GameSearchOpenApiTransformer : IOpenApiOperationTransformer
{
    public Task TransformAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken
    )
    {
        if (context.Description.RelativePath != "api/games")
            return Task.CompletedTask;
        operation.Parameters =
        [
            new OpenApiParameter
            {
                Name = "name",
                In = ParameterLocation.Query,
                Required = true,
                Description =
                    "Trecho literal do título, sem distinguir caixa e acentos; 1 a 200 unidades UTF-16 após Trim.",
                Schema = new OpenApiSchema
                {
                    Type = JsonSchemaType.String,
                    MinLength = 1,
                    MaxLength = 200
                },
            },
            new OpenApiParameter
            {
                Name = "page",
                In = ParameterLocation.Query,
                Description = "Página positiva; valores repetidos são inválidos.",
                Schema = new OpenApiSchema
                {
                    Type = JsonSchemaType.Integer,
                    Format = "int32",
                    Minimum = "1",
                    Maximum = "2147483647",
                    Default = JsonValue.Create(1),
                },
            },
            new OpenApiParameter
            {
                Name = "pageSize",
                In = ParameterLocation.Query,
                Description = "De 1 a 100 jogos por página; valores repetidos são inválidos.",
                Schema = new OpenApiSchema
                {
                    Type = JsonSchemaType.Integer,
                    Format = "int32",
                    Minimum = "1",
                    Maximum = "100",
                    Default = JsonValue.Create(20),
                },
            },
        ];
        return Task.CompletedTask;
    }
}
