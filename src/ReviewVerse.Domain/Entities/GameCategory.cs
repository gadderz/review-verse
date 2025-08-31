using ReviewVerse.Domain.Common;

namespace ReviewVerse.Domain.Entities;

public class GameCategory : BaseAuditableEntity<int>
{
    public required string Name { get; set; }
    public IList<Game> Games { get; set; } = [];
}
