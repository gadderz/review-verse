using MediatR;
using ReviewVerse.Domain.Repositories;

namespace ReviewVerse.Application.Game.Commands.CreateGame;

public record CreateGameCommand : IRequest
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand>
{
    private readonly IGameRepository _repository;

    public CreateGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Game
        {
            Name = request.Name!,
            Description = request.Description!,
        };

        await _repository.AddAsync(entity);
    }
}
