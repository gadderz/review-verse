using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewVerse.Domain.Entities;

namespace ReviewVerse.Persistence.Data.Configurations;

public class GameCategoryConfiguration : IEntityTypeConfiguration<GameCategory>
{
    public void Configure(EntityTypeBuilder<GameCategory> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();

        SeedData(builder);
    }

    private void SeedData(EntityTypeBuilder<GameCategory> modelBuilder)
    {
        modelBuilder.HasData(
            new GameCategory { Id = 1, Name = "Action" },
            new GameCategory { Id = 2, Name = "Adventure" },
            new GameCategory { Id = 3, Name = "RPG" },
            new GameCategory { Id = 4, Name = "Simulation" },
            new GameCategory { Id = 5, Name = "Strategy" },
            new GameCategory { Id = 6, Name = "Sports" },
            new GameCategory { Id = 7, Name = "Puzzle" },
            new GameCategory { Id = 8, Name = "Racing" },
            new GameCategory { Id = 9, Name = "Horror" },
            new GameCategory { Id = 10, Name = "FPS" },
            new GameCategory { Id = 11, Name = "Fighting" },
            new GameCategory { Id = 12, Name = "MMO" }
        );
    }
}
