namespace ReviewVerse.Game.Catalog.Domain;

public sealed class CatalogGame
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
}
