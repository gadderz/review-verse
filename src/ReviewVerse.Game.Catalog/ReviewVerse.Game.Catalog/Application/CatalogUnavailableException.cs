namespace ReviewVerse.Game.Catalog.Application;

public sealed class CatalogUnavailableException(Exception innerException)
    : Exception("The catalog is temporarily unavailable.", innerException);
