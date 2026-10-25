using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ReviewVerse.Game.Catalog.API.Contracts;

internal static class CatalogProblems
{
    public static ValidationProblemDetails Validation(HttpContext context, IDictionary<string, string[]> errors)
    {
        var problem = new ValidationProblemDetails(errors)
        {
            Type = "about:blank",
            Title = "Invalid request",
            Status = 400,
        };
        Enrich(problem, context, "validation_error");
        return problem;
    }

    public static void Enrich(ProblemDetails problem, HttpContext context, string code)
    {
        problem.Extensions["code"] = code;
        problem.Extensions["traceId"] = Activity.Current?.Id ?? context.TraceIdentifier;
    }
}
