using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ReviewVerse.Game.Catalog.Application;

namespace ReviewVerse.Game.Catalog.Infrastructure;

public static class CatalogRegistration
{
    public static IServiceCollection AddCatalog(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CatalogDbContext>(options => Configure(options, connectionString));
        services.AddScoped<IGameSearch, PostgresGameSearch>();
        return services;
    }

    public static void Configure(DbContextOptionsBuilder options, string connectionString)
    {
        var connection = new NpgsqlConnectionStringBuilder(connectionString)
        {
            Timeout = 3,
            CommandTimeout = 5,
            IncludeErrorDetail = false,
        };
        options.UseNpgsql(
            connection.ConnectionString,
            postgres =>
            {
                postgres.SetPostgresVersion(16, 0);
                postgres.MigrationsHistoryTable("__EFMigrationsHistory", "catalog");
            }
        );
    }
}

public sealed class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        var connection =
            Environment.GetEnvironmentVariable("ConnectionStrings__Catalog")
            ?? throw new InvalidOperationException("Set ConnectionStrings__Catalog before applying migrations.");
        var options = new DbContextOptionsBuilder<CatalogDbContext>();
        CatalogRegistration.Configure(options, connection);
        return new CatalogDbContext(options.Options);
    }
}
