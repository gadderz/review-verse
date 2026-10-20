using ReviewVerse.Game.Catalog.Application;

namespace ReviewVerse.Game.Catalog.API.Contracts;

public sealed record PlatformResponse(Guid Id, string Name);

public sealed record GameResponse(Guid Id, string Title, IReadOnlyList<PlatformResponse> Platforms);

public sealed record GameSearchResponse(IReadOnlyList<GameResponse> Items, int Page, int PageSize, long Total)
{
    public static GameSearchResponse From(GameSearchPage page) =>
        new(
            page.Items.Select(game => new GameResponse(
                    game.Id,
                    game.Title,
                    game.Platforms.Select(platform => new PlatformResponse(platform.Id, platform.Name)).ToArray()
                ))
                .ToArray(),
            page.Page,
            page.PageSize,
            page.Total
        );
}
