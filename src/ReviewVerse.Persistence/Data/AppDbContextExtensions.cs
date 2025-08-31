using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ReviewVerse.Persistence.Data;

public static class AppDbContextExtensions
{
    public static void AddApplicationDbContext(
        this IServiceCollection services,
        string connectionString,
        string? migrationAssembly
    )
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                b =>
                {
                    if (migrationAssembly is not null)
                        b.MigrationsAssembly(migrationAssembly);
                }
            );
        });
    }
}
