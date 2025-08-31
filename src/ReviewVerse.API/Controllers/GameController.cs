using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewVerse.Application.Game.Commands.CreateGame;
using ReviewVerse.Application.Game.Commands.DeleteGame;
using ReviewVerse.Application.Game.Commands.UpdateGame;
using ReviewVerse.Application.Game.Queries.GetGameById;
using ReviewVerse.Application.Game.Queries.GetGames;

namespace ReviewVerse.API.Controllers;

[ApiController]
[Route("/v1/game")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Get all games
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var games = await _mediator.Send(new GetGamesQuery());

        return Ok(games);
    }

    /// <summary>
    /// Get a game by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var game = await _mediator.Send(new GetGameByIdQuery { Id = id });

        return Ok(game);
    }

    /// <summary>
    /// Create a new game
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "CreateGame")]
    public async Task<IActionResult> CreateAsync(CreateGameCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Update a game
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateGameCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Delete a game
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteGameCommand { Id = id });

        return Ok();
    }
}
