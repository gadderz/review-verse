using MediatR;
using ReviewVerse.Domain.Repositories;

namespace ReviewVerse.Application.Game.Commands.CreateGameCategory;

public record CreateGameCategoryCommand : IRequest
{
    public string? Name { get; init; }
}

public class CreateGameCategoryCommandHandler : IRequestHandler<CreateGameCategoryCommand>
{
    private readonly IGameCategoryRepository _repository;

    public CreateGameCategoryCommandHandler(IGameCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateGameCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.GameCategory { Name = request.Name!, };

        await _repository.AddAsync(entity);
    }
}
