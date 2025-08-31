using MediatR;
using ReviewVerse.Domain.Repositories;

namespace ReviewVerse.Application.Game.Commands.UpdateGame;

public record UpdateGameCommand : IRequest
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
}

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
{
    private readonly IGameRepository _repository;

    public UpdateGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        entity.Name = request.Name!;
        entity.Description = request.Description!;

        await _repository.UpdateAsync(entity);
    }
}
