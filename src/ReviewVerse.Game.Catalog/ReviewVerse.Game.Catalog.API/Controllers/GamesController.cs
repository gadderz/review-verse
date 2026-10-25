using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewVerse.Game.Catalog.API.Contracts;
using ReviewVerse.Game.Catalog.Application;

namespace ReviewVerse.Game.Catalog.API.Controllers;

[ApiController]
[Route("api/games")]
[AllowAnonymous]
public sealed class GamesController(IGameSearch search) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<GameSearchResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status503ServiceUnavailable, "application/problem+json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError, "application/problem+json")]
    public async Task<ActionResult<GameSearchResponse>> Get(
        [FromQuery] GameSearchRequest request,
        CancellationToken cancellationToken
    )
    {
        if (!request.TryValidate(Request.Query, out var query, out var errors))
        {
            var result = new ObjectResult(CatalogProblems.Validation(HttpContext, errors)) { StatusCode = 400 };
            result.ContentTypes.Add("application/problem+json");
            return result;
        }
        return Ok(GameSearchResponse.From(await search.SearchAsync(query!, cancellationToken)));
    }
}
