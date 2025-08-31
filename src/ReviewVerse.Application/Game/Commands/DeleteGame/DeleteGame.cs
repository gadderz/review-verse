using MediatR;
using ReviewVerse.Domain.Repositories;

namespace ReviewVerse.Application.Game.Commands.DeleteGame;

public record DeleteGameCommand : IRequest
{
    public Guid Id { get; init; }
}

public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
{
    private readonly IGameRepository _repository;

    public DeleteGameCommandHandler(IGameRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        await _repository.DeleteAsync(entity);
    }
}
