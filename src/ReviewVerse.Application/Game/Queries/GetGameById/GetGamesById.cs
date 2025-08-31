using AutoMapper;
using MediatR;
using ReviewVerse.Application.Game.Models;
using ReviewVerse.Domain.Repositories;

namespace ReviewVerse.Application.Game.Queries.GetGameById;

public record GetGameByIdQuery : IRequest<GameDto>
{
    public Guid Id { get; init; }
}

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDto>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GetGameByIdQueryHandler(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(request.Id);

        var response = _mapper.Map<GameDto>(game);
        return response;
    }
}
