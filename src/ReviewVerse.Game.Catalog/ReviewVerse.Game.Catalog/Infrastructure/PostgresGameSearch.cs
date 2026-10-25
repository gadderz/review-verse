using System.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ReviewVerse.Game.Catalog.Application;

namespace ReviewVerse.Game.Catalog.Infrastructure;

internal sealed class PostgresGameSearch(CatalogDbContext db) : IGameSearch
{
    public async Task<GameSearchPage> SearchAsync(GameSearchQuery query, CancellationToken cancellationToken)
    {
        try
        {
            await using var transaction = await db.Database.BeginTransactionAsync(
                IsolationLevel.RepeatableRead,
                cancellationToken
            );
            await db.Database.ExecuteSqlRawAsync("SET TRANSACTION READ ONLY", cancellationToken);
            var total = await db
                .Database.SqlQuery<long>(
                    $"""
                    SELECT count(*) AS "Value" FROM catalog.games
                    WHERE strpos(lower(public.unaccent(title)), lower(public.unaccent({query.Name}))) > 0
                    """
                )
                .SingleAsync(cancellationToken);

            if (query.Offset >= total)
            {
                await transaction.CommitAsync(cancellationToken);
                return new GameSearchPage([], query.Page, query.PageSize, total);
            }

            var games = await db
                .Database.SqlQuery<GameRow>(
                    $"""
                    SELECT id AS "Id", title AS "Title" FROM catalog.games
                    WHERE strpos(lower(public.unaccent(title)), lower(public.unaccent({query.Name}))) > 0
                    ORDER BY lower(public.unaccent(title)) COLLATE "C", id
                    LIMIT {query.PageSize} OFFSET {query.Offset}
                    """
                )
                .ToListAsync(cancellationToken);
            var ids = games.Select(game => game.Id).ToArray();
            var platforms = await (
                from link in db.GamePlatforms.AsNoTracking()
                join platform in db.Platforms.AsNoTracking() on link.PlatformId equals platform.Id
                where ids.Contains(link.GameId)
                orderby EF.Functions.Collate(EF.Functions.Unaccent(platform.Name).ToLower(), "C"), platform.Id
                select new
                {
                    link.GameId,
                    platform.Id,
                    platform.Name
                }
            ).ToListAsync(cancellationToken);
            var byGame = platforms.ToLookup(platform => platform.GameId);
            var items = games
                .Select(game => new GameSummary(
                    game.Id,
                    game.Title,
                    byGame[game.Id].Select(platform => new PlatformSummary(platform.Id, platform.Name)).ToArray()
                ))
                .ToArray();
            await transaction.CommitAsync(cancellationToken);
            return new GameSearchPage(items, query.Page, query.PageSize, total);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (NpgsqlException exception) when (exception.IsTransient)
        {
            throw new CatalogUnavailableException(exception);
        }
        catch (InvalidOperationException exception)
            when (exception.InnerException is NpgsqlException { IsTransient: true })
        {
            // EF wraps transient provider failures when retries are not enabled.
            throw new CatalogUnavailableException(exception);
        }
        catch (TimeoutException exception)
        {
            throw new CatalogUnavailableException(exception);
        }
    }

    private sealed class GameRow
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
    }
}
