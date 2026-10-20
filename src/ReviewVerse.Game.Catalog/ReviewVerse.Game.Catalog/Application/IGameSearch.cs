namespace ReviewVerse.Game.Catalog.Application;

public interface IGameSearch
{
    Task<GameSearchPage> SearchAsync(GameSearchQuery query, CancellationToken cancellationToken);
}

public sealed record PlatformSummary(Guid Id, string Name);

public sealed record GameSummary(Guid Id, string Title, IReadOnlyList<PlatformSummary> Platforms);

public sealed record GameSearchPage(IReadOnlyList<GameSummary> Items, int Page, int PageSize, long Total);
