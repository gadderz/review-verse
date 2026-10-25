using Microsoft.AspNetCore.Mvc;
using ReviewVerse.Game.Catalog.API.Contracts;
using ReviewVerse.Game.Catalog.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context
                .ModelState.Where(entry => entry.Value?.Errors.Count > 0)
                .ToDictionary(entry => entry.Key, _ => new[] { "Invalid value." });
            var result = new ObjectResult(CatalogProblems.Validation(context.HttpContext, errors)) { StatusCode = 400 };
            result.ContentTypes.Add("application/problem+json");
            return result;
        };
    });
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<CatalogExceptionHandler>();
builder.Services.AddOpenApi(options => options.AddOperationTransformer<GameSearchOpenApiTransformer>());
builder.Services.AddCatalog(
    builder.Configuration.GetConnectionString("Catalog")
        ?? throw new InvalidOperationException("Configure ConnectionStrings__Catalog before starting the API.")
);

var app = builder.Build();

if (args.Contains("--catalog-seed", StringComparer.Ordinal))
{
    if (!app.Environment.IsDevelopment() && !app.Environment.IsEnvironment("Testing"))
        throw new InvalidOperationException("Catalog seed is only available in Development or Testing.");
    await using var scope = app.Services.CreateAsyncScope();
    await CatalogDevelopmentData.SeedAsync(scope.ServiceProvider.GetRequiredService<CatalogDbContext>());
    return;
}

app.UseExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program;
