using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReviewVerse.Game.Catalog.Application;

namespace ReviewVerse.Game.Catalog.API.Contracts;

internal sealed class CatalogExceptionHandler(ILogger<CatalogExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is OperationCanceledException && context.RequestAborted.IsCancellationRequested)
            return false;

        var unavailable = exception is CatalogUnavailableException;
        logger.LogError(exception, "Catalog request failed; trace {TraceId}", context.TraceIdentifier);
        var problem = new ProblemDetails
        {
            Type = "about:blank",
            Status = unavailable ? 503 : 500,
            Title = unavailable ? "Catalog unavailable" : "Internal server error",
        };
        CatalogProblems.Enrich(problem, context, unavailable ? "catalog_unavailable" : "internal_error");
        context.Response.StatusCode = problem.Status.Value;
        await context.Response.WriteAsJsonAsync(
            problem,
            options: null,
            contentType: "application/problem+json",
            cancellationToken: cancellationToken
        );
        return true;
    }
}
