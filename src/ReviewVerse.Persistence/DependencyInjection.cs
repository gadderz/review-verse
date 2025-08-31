using Microsoft.Extensions.DependencyInjection;
using ReviewVerse.Domain.Repositories;
using ReviewVerse.Persistence.Data;
using ReviewVerse.Persistence.Data.Repositories;

namespace ReviewVerse.Persistence.DependencyInjection;

public static class DependencyInjection
{
    public static void AddPersistenceServices(
        this IServiceCollection services,
        string connectionString,
        string? migratrionAssembly = null
    )
    {
        services.AddApplicationDbContext(connectionString, migratrionAssembly);

        services.AddScoped<IGameCategoryRepository, GameCategoryRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
    }
}
