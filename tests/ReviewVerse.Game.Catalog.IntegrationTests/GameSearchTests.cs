using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ReviewVerse.Game.Catalog.API.Contracts;
using ReviewVerse.Game.Catalog.Domain;
using ReviewVerse.Game.Catalog.Infrastructure;
using Xunit;

namespace ReviewVerse.Game.Catalog.IntegrationTests;

[Collection("Catalog")]
public sealed class GameSearchTests(CatalogFixture fixture)
{
    private Task<GameSearchResponse?> SearchAsync(string term, string extra = "") =>
        fixture.Client.GetFromJsonAsync<GameSearchResponse>($"/api/games?name={Uri.EscapeDataString(term)}{extra}");

    [Fact]
    public async Task AnonymousSearchAggregatesPlatformsAndKeepsHomonyms()
    {
        await fixture.ResetAsync("Ação no Espaço", "Ação no Espaço", "Outro");
        await using var db = fixture.CreateDb();
        db.GamePlatforms.Add(new GamePlatform { GameId = CatalogFixture.Id(1), PlatformId = CatalogFixture.Id(1002) });
        await db.SaveChangesAsync();
        var response = await fixture.Client.GetAsync("/api/games?name=acao");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
        var page = (await response.Content.ReadFromJsonAsync<GameSearchResponse>())!;
        Assert.Equal(2, page.Total);
        Assert.Equal(2, page.Items.Count);
        Assert.Equal(2, page.Items[0].Platforms.Count);
        Assert.Equal(new[] { "Árcade", "PC" }, page.Items[0].Platforms.Select(platform => platform.Name));
        Assert.Equal("Ação no Espaço", page.Items[0].Title);
        Assert.NotEqual(page.Items[0].Id, page.Items[1].Id);
        Assert.Null(fixture.Client.DefaultRequestHeaders.Authorization);
    }

    [Theory]
    [InlineData("AÇÃO")]
    [InlineData("acao")]
    [InlineData("  espaço  ")]
    [InlineData("Ac\u0327a\u0303o")]
    public async Task MatchesCaseAccentsAndTrimmedLiteralSubstring(string term)
    {
        await fixture.ResetAsync("Ação no Espaço", "Ac\u0327a\u0303o no Espac\u0327o", "Aventura no Tempo");
        var page = (await SearchAsync(term))!;
        Assert.Equal(2, page.Total);
        Assert.Equal(new[] { CatalogFixture.Id(1), CatalogFixture.Id(2) }, page.Items.Select(game => game.Id));
    }

    [Theory]
    [InlineData("%", "Arena 100%", "Arena 1000")]
    [InlineData("_", "Caminho_Secreto", "CaminhoXSecreto")]
    [InlineData("\\", "Caminho\\Lunar", "Caminho Lunar")]
    [InlineData("'", "D'Água", "D Agua")]
    [InlineData("  ", "Duas  Luas", "Duas Luas")]
    [InlineData("-", "Lua-Sol", "Lua Sol")]
    public async Task PreservesLiteralCharacters(string term, string match, string other)
    {
        // Espaços internos precisam de caracteres nas pontas para não serem um termo vazio.
        if (term == "  ")
            term = "Duas  Luas";
        await fixture.ResetAsync(match, other);
        var page = (await SearchAsync(term))!;
        Assert.Equal(1, page.Total);
        Assert.Equal(match, Assert.Single(page.Items).Title);
    }

    [Fact]
    public async Task EmptyCatalogAndNoMatchReturnEmptyArraysWithoutWriting()
    {
        await fixture.ResetAsync();
        var empty = (await SearchAsync("missing"))!;
        Assert.Empty(empty.Items);
        Assert.Equal(0, empty.Total);
        await fixture.ResetAsync("Preservado");
        var missing = (await SearchAsync("' OR 1=1 --"))!;
        Assert.Empty(missing.Items);
        await using var db = fixture.CreateDb();
        Assert.Equal(1, await db.Games.CountAsync());
        Assert.Equal("Preservado", await db.Games.Select(game => game.Title).SingleAsync());
    }

    [Fact]
    public async Task PaginationTraversesGamesInNormalizedOrderIncludingTies()
    {
        var titles = Enumerable.Range(1, 125).Select(i => $"Fixture {i:000}").ToArray();
        titles[19] = "Fíxture 020";
        titles[20] = "fixture 020";
        await fixture.ResetAsync(titles);
        await using (var db = fixture.CreateDb())
        {
            db.GamePlatforms.Add(
                new GamePlatform { GameId = CatalogFixture.Id(20), PlatformId = CatalogFixture.Id(1002) }
            );
            await db.SaveChangesAsync();
        }
        var first = (await SearchAsync("fixture"))!;
        Assert.Equal(1, first.Page);
        Assert.Equal(20, first.PageSize);
        Assert.Equal(125, first.Total);
        Assert.Equal(20, first.Items.Count);
        Assert.Equal(CatalogFixture.Id(20), first.Items.Last().Id);
        var all = new List<Guid>();
        for (var page = 1; page <= 7; page++)
        {
            var result = (await SearchAsync("fixture", $"&page={page}"))!;
            Assert.Equal(125, result.Total);
            Assert.Equal(page, result.Page);
            all.AddRange(result.Items.Select(game => game.Id));
        }
        Assert.Equal(Enumerable.Range(1, 125).Select(CatalogFixture.Id), all);
        Assert.Equal(125, all.Distinct().Count());
        Assert.Single((await SearchAsync("fixture", "&pageSize=1"))!.Items);
        Assert.Equal(100, (await SearchAsync("fixture", "&pageSize=100"))!.Items.Count);
        var beyond = (await SearchAsync("fixture", "&page=2147483647&pageSize=100"))!;
        Assert.Empty(beyond.Items);
        Assert.Equal(125, beyond.Total);
        Assert.Equal(int.MaxValue, beyond.Page);
        Assert.Equal(100, beyond.PageSize);
    }

    [Theory]
    [InlineData("", "name")]
    [InlineData("?name=", "name")]
    [InlineData("?name=%20%09", "name")]
    [InlineData("?name=x&page=", "page")]
    [InlineData("?name=x&page=0", "page")]
    [InlineData("?name=x&page=-1", "page")]
    [InlineData("?name=x&page=1.5", "page")]
    [InlineData("?name=x&page=abc", "page")]
    [InlineData("?name=x&page=2147483648", "page")]
    [InlineData("?name=x&pageSize=", "pageSize")]
    [InlineData("?name=x&pageSize=0", "pageSize")]
    [InlineData("?name=x&pageSize=-1", "pageSize")]
    [InlineData("?name=x&pageSize=101", "pageSize")]
    [InlineData("?name=x&pageSize=1.5", "pageSize")]
    [InlineData("?name=x&pageSize=abc", "pageSize")]
    [InlineData("?name=x&name=y", "name")]
    [InlineData("?name=x&page=1&page=2", "page")]
    [InlineData("?name=x&pageSize=1&pageSize=2", "pageSize")]
    public async Task RejectsInvalidRequestsWithConsistentProblemDetails(string query, string field)
    {
        var response = await fixture.Client.GetAsync("/api/games" + query);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("about:blank", body.GetProperty("type").GetString());
        Assert.Equal("Invalid request", body.GetProperty("title").GetString());
        Assert.Equal(400, body.GetProperty("status").GetInt32());
        Assert.Equal("validation_error", body.GetProperty("code").GetString());
        Assert.False(string.IsNullOrEmpty(body.GetProperty("traceId").GetString()));
        Assert.True(body.GetProperty("errors").TryGetProperty(field, out _));
    }

    [Fact]
    public async Task ValidatesNameLengthAfterTrim()
    {
        await fixture.ResetAsync(new string('x', 200));
        Assert.Single((await SearchAsync("  " + new string('x', 200) + "  "))!.Items);
        var invalid = await fixture.Client.GetAsync("/api/games?name=" + new string('x', 201));
        Assert.Equal(HttpStatusCode.BadRequest, invalid.StatusCode);
    }

    [Fact]
    public async Task DatabaseOutageReturns503AndInvalidInputStillReturns400()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        var connection = new NpgsqlConnectionStringBuilder(fixture.ConnectionString) { Port = port, Pooling = false };
        await using var factory = new CatalogFactory(connection.ConnectionString, "Development");
        using var client = factory.CreateClient(new() { BaseAddress = new Uri("https://localhost") });
        var response = await client.GetAsync("/api/games?name=acao");
        Assert.Equal(HttpStatusCode.ServiceUnavailable, response.StatusCode);
        var raw = await response.Content.ReadAsStringAsync();
        var problem = JsonSerializer.Deserialize<JsonElement>(raw);
        Assert.Equal("Catalog unavailable", problem.GetProperty("title").GetString());
        Assert.Equal("catalog_unavailable", problem.GetProperty("code").GetString());
        Assert.False(string.IsNullOrWhiteSpace(problem.GetProperty("traceId").GetString()));
        Assert.DoesNotContain(connection.Password!, raw);
        Assert.DoesNotContain(connection.Host!, raw);
        Assert.DoesNotContain("Npgsql", raw);
        Assert.Equal(HttpStatusCode.BadRequest, (await client.GetAsync("/api/games?name= ")).StatusCode);
    }

    [Fact]
    public async Task SqlDefectsReturnGeneric500InsteadOf503()
    {
        await fixture.ResetAsync("Game");
        await using var db = fixture.CreateDb();
        await db.Database.ExecuteSqlRawAsync("ALTER TABLE catalog.games RENAME COLUMN title TO temporarily_hidden");
        try
        {
            var response = await fixture.Client.GetAsync("/api/games?name=game");
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            var raw = await response.Content.ReadAsStringAsync();
            Assert.Contains("internal_error", raw);
            Assert.DoesNotContain("temporarily_hidden", raw);
            Assert.DoesNotContain("SELECT", raw);
        }
        finally
        {
            await db.Database.ExecuteSqlRawAsync("ALTER TABLE catalog.games RENAME COLUMN temporarily_hidden TO title");
        }
    }

    [Fact]
    public async Task MigrationsAndSeedAreRepeatableAndKeepExistingData()
    {
        await fixture.ResetAsync();
        await using var db = fixture.CreateDb();
        db.Games.Add(new CatalogGame { Id = CatalogFixture.Id(999), Title = "Registro fora da massa" });
        await db.SaveChangesAsync();
        await db.Database.MigrateAsync();
        await db.Database.MigrateAsync();
        await CatalogDevelopmentData.SeedAsync(db);
        var counts = (
            await db.Games.CountAsync(),
            await db.Platforms.CountAsync(),
            await db.GamePlatforms.CountAsync()
        );
        await CatalogDevelopmentData.SeedAsync(db);
        Assert.Equal(
            counts,
            (await db.Games.CountAsync(), await db.Platforms.CountAsync(), await db.GamePlatforms.CountAsync())
        );
        Assert.True(await db.Games.AnyAsync(game => game.Id == CatalogFixture.Id(999)));
        Assert.Equal(2, await db.Games.CountAsync(game => game.Title == "Eco"));
        var link = await db.GamePlatforms.AsNoTracking().FirstAsync();
        db.GamePlatforms.Add(new GamePlatform { GameId = link.GameId, PlatformId = link.PlatformId });
        var duplicate = await Assert.ThrowsAsync<DbUpdateException>(() => db.SaveChangesAsync());
        Assert.Equal(
            PostgresErrorCodes.UniqueViolation,
            Assert.IsType<PostgresException>(duplicate.InnerException).SqlState
        );
    }

    [Fact]
    public async Task OpenApiDocumentsTheContract()
    {
        await using var factory = new CatalogFactory(fixture.ConnectionString, "Development");
        using var client = factory.CreateClient(new() { BaseAddress = new Uri("https://localhost") });
        var document = await client.GetFromJsonAsync<JsonElement>("/openapi/v1.json");
        var operation = document.GetProperty("paths").GetProperty("/api/games").GetProperty("get");
        foreach (var status in new[] { "200", "400", "503", "500" })
            Assert.True(operation.GetProperty("responses").TryGetProperty(status, out _));
        var parameters = operation
            .GetProperty("parameters")
            .EnumerateArray()
            .ToDictionary(p => p.GetProperty("name").GetString()!);
        Assert.True(parameters["name"].GetProperty("required").GetBoolean());
        Assert.Equal("integer", parameters["page"].GetProperty("schema").GetProperty("type").GetString());
        Assert.Equal(1, parameters["page"].GetProperty("schema").GetProperty("default").GetInt32());
        Assert.Equal("integer", parameters["pageSize"].GetProperty("schema").GetProperty("type").GetString());
        Assert.Equal(20, parameters["pageSize"].GetProperty("schema").GetProperty("default").GetInt32());
        Assert.Equal(100, parameters["pageSize"].GetProperty("schema").GetProperty("maximum").GetInt32());
    }

    [Fact]
    public async Task ComposeStillLoadsWithoutCatalogEnvironmentVariables()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory is not null && !File.Exists(Path.Combine(directory.FullName, "docker-compose.yaml")))
            directory = directory.Parent;
        Assert.NotNull(directory);
        var start = new ProcessStartInfo("docker")
        {
            WorkingDirectory = directory!.FullName,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
        };
        foreach (
            var key in start
                .Environment.Keys.Where(key => key.StartsWith("CATALOG_", StringComparison.Ordinal))
                .ToArray()
        )
            start.Environment.Remove(key);
        foreach (var argument in new[] { "compose", "--env-file", "/dev/null", "config", "--quiet" })
            start.ArgumentList.Add(argument);
        using var process = Process.Start(start)!;
        var output = process.StandardOutput.ReadToEndAsync();
        var error = process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();
        await output;
        Assert.True(process.ExitCode == 0, await error);
    }
}
