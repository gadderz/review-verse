using Microsoft.EntityFrameworkCore;
using ReviewVerse.Game.Catalog.Domain;

namespace ReviewVerse.Game.Catalog.Infrastructure;

public sealed class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    public DbSet<CatalogGame> Games => Set<CatalogGame>();
    public DbSet<CatalogPlatform> Platforms => Set<CatalogPlatform>();
    public DbSet<GamePlatform> GamePlatforms => Set<GamePlatform>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("catalog");
        modelBuilder.HasPostgresExtension("unaccent");
        modelBuilder.Entity<CatalogGame>(entity =>
        {
            entity.ToTable("games", table => table.HasCheckConstraint("ck_games_title", "btrim(title) <> ''"));
            entity.HasKey(game => game.Id);
            entity.Property(game => game.Id).HasColumnName("id").ValueGeneratedNever();
            entity.Property(game => game.Title).HasColumnName("title").IsRequired();
        });
        modelBuilder.Entity<CatalogPlatform>(entity =>
        {
            entity.ToTable("platforms", table => table.HasCheckConstraint("ck_platforms_name", "btrim(name) <> ''"));
            entity.HasKey(platform => platform.Id);
            entity.Property(platform => platform.Id).HasColumnName("id").ValueGeneratedNever();
            entity.Property(platform => platform.Name).HasColumnName("name").IsRequired();
        });
        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.ToTable("game_platforms");
            entity.HasKey(link => new { link.GameId, link.PlatformId });
            entity.Property(link => link.GameId).HasColumnName("game_id");
            entity.Property(link => link.PlatformId).HasColumnName("platform_id");
            entity.HasOne<CatalogGame>().WithMany().HasForeignKey(link => link.GameId);
            entity.HasOne<CatalogPlatform>().WithMany().HasForeignKey(link => link.PlatformId);
        });
    }
}
