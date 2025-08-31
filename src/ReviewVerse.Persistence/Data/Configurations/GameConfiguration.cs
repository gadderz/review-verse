using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewVerse.Domain.Entities;

namespace ReviewVerse.Persistence.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(2000).IsRequired();
        builder.Property(p => p.ReleaseDate);

        builder
            .HasMany(p => p.GameCategories)
            .WithMany(p => p.Games)
            .UsingEntity("GamesToGameCategories");
    }
}
