using Microsoft.EntityFrameworkCore;
using ReviewVerse.Game.Catalog.Domain;

namespace ReviewVerse.Game.Catalog.Infrastructure;

public static class CatalogDevelopmentData
{
    public static async Task SeedAsync(CatalogDbContext db, CancellationToken cancellationToken = default)
    {
        string[] titles =
        [
            "Ação no Espaço",
            "Além do Horizonte",
            "Arena 100%",
            "Caminho_Secreto",
            "Caminho\\Lunar",
            "Crônicas de Papel",
            "D'Água",
            "Eco",
            "Eco",
            "Floresta Azul",
            "Guardiões do Sol",
            "Ilha das Marés",
            "Jardim de Cristal",
            "Labirinto de Areia",
            "Luz e Sombra",
            "Montanha Distante",
            "Noite Estelar",
            "Oceano de Vidro",
            "Ponte do Amanhã",
            "Queda das Estrelas",
            "Reino Perdido",
            "Sonho de Inverno",
            "Torre do Vento",
            "Universo de Tinta",
            "Vale da Lua",
        ];
        await using var transaction = await db.Database.BeginTransactionAsync(cancellationToken);
        var pc = Guid.Parse("00000000-0000-0000-0001-000000000001");
        var console = Guid.Parse("00000000-0000-0000-0001-000000000002");
        foreach (
            var platform in new[]
            {
                new CatalogPlatform { Id = pc, Name = "PC" },
                new CatalogPlatform { Id = console, Name = "Console de teste" },
            }
        )
        {
            await db.Database.ExecuteSqlInterpolatedAsync(
                $"""
                INSERT INTO catalog.platforms (id, name) VALUES ({platform.Id}, {platform.Name})
                ON CONFLICT (id) DO UPDATE SET name = EXCLUDED.name
                """,
                cancellationToken
            );
        }
        for (var i = 0; i < titles.Length; i++)
        {
            var id = Guid.Parse($"00000000-0000-0000-0000-{i + 1:000000000000}");
            await db.Database.ExecuteSqlInterpolatedAsync(
                $"""
                INSERT INTO catalog.games (id, title) VALUES ({id}, {titles[i]})
                ON CONFLICT (id) DO UPDATE SET title = EXCLUDED.title
                """,
                cancellationToken
            );
            await db.Database.ExecuteSqlInterpolatedAsync(
                $"""
                INSERT INTO catalog.game_platforms (game_id, platform_id) VALUES ({id}, {pc})
                ON CONFLICT DO NOTHING
                """,
                cancellationToken
            );
            if (i == 0)
                await db.Database.ExecuteSqlInterpolatedAsync(
                    $"""
                    INSERT INTO catalog.game_platforms (game_id, platform_id) VALUES ({id}, {console})
                    ON CONFLICT DO NOTHING
                    """,
                    cancellationToken
                );
        }
        await transaction.CommitAsync(cancellationToken);
    }
}
