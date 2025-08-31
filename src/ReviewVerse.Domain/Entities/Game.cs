using ReviewVerse.Domain.Common;

namespace ReviewVerse.Domain.Entities;

public class Game : BaseAuditableEntity<Guid>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public IList<GameCategory> GameCategories { get; set; } = [];
}
