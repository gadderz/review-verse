using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ReviewVerse.Game.Catalog.Domain;
using ReviewVerse.Game.Catalog.Infrastructure;
using Xunit;

namespace ReviewVerse.Game.Catalog.IntegrationTests;

public sealed class CatalogFactory(string connectionString, string environment = "Testing")
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment(environment);
        builder.UseSetting("ConnectionStrings:Catalog", connectionString);
    }
}

public sealed class CatalogFixture : IAsyncLifetime
{
    public string ConnectionString { get; private set; } = "";
    public CatalogFactory Factory { get; private set; } = null!;
    public HttpClient Client { get; private set; } = null!;

    public static Guid Id(int number) => Guid.Parse($"00000000-0000-0000-0000-{number:000000000000}");

    public async Task InitializeAsync()
    {
        ConnectionString =
            Environment.GetEnvironmentVariable("ConnectionStrings__CatalogTests")
            ?? throw new InvalidOperationException(
                "Set ConnectionStrings__CatalogTests explicitly; integration tests require PostgreSQL."
            );
        if (new NpgsqlConnectionStringBuilder(ConnectionString).Database != "reviewverse_catalog_tests")
            throw new InvalidOperationException("Integration tests only operate on reviewverse_catalog_tests.");
        await using var db = CreateDb();
        var database = await db.Database.SqlQuery<string>($"SELECT current_database() AS \"Value\"").SingleAsync();
        if (database != "reviewverse_catalog_tests")
            throw new InvalidOperationException("Refusing to modify a non-test database.");
        await db.Database.MigrateAsync();
        Factory = new CatalogFactory(ConnectionString);
        Client = Factory.CreateClient(
            new WebApplicationFactoryClientOptions { BaseAddress = new Uri("https://localhost") }
        );
    }

    public CatalogDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<CatalogDbContext>();
        CatalogRegistration.Configure(options, ConnectionString);
        return new CatalogDbContext(options.Options);
    }

    public async Task ResetAsync(params string[] titles)
    {
        await using var db = CreateDb();
        // O nome real do banco foi conferido antes de permitir qualquer limpeza.
        await db.Database.ExecuteSqlRawAsync("TRUNCATE catalog.game_platforms, catalog.games, catalog.platforms");
        db.Platforms.AddRange(
            new CatalogPlatform { Id = Id(1001), Name = "PC" },
            new CatalogPlatform { Id = Id(1002), Name = "Árcade" }
        );
        for (var i = 0; i < titles.Length; i++)
        {
            db.Games.Add(new CatalogGame { Id = Id(i + 1), Title = titles[i] });
            db.GamePlatforms.Add(new GamePlatform { GameId = Id(i + 1), PlatformId = Id(1001) });
        }
        await db.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        Client?.Dispose();
        if (Factory is not null)
            await Factory.DisposeAsync();
    }
}

[CollectionDefinition("Catalog", DisableParallelization = true)]
public sealed class CatalogCollection : ICollectionFixture<CatalogFixture>;
