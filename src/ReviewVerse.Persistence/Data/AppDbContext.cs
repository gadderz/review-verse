using Microsoft.EntityFrameworkCore;
using ReviewVerse.Domain.Entities;

namespace ReviewVerse.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Game> Games { get; set; }
    public DbSet<GameCategory> GameCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
