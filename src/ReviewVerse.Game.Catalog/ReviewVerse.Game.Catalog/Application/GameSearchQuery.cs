namespace ReviewVerse.Game.Catalog.Application;

public sealed record GameSearchQuery
{
    private GameSearchQuery(string name, int page, int pageSize)
    {
        Name = name;
        Page = page;
        PageSize = pageSize;
    }

    public string Name { get; }
    public int Page { get; }
    public int PageSize { get; }
    public long Offset => ((long)Page - 1) * PageSize;

    public static bool TryCreate(
        string? name,
        int page,
        int pageSize,
        out GameSearchQuery? query,
        out Dictionary<string, string[]> errors
    )
    {
        errors = [];
        var term = name?.Trim();
        if (string.IsNullOrEmpty(term) || term.Length > 200)
            errors["name"] = ["Name must contain between 1 and 200 characters."];
        if (page < 1)
            errors["page"] = ["Page must be a positive integer."];
        if (pageSize is < 1 or > 100)
            errors["pageSize"] = ["Page size must be between 1 and 100."];

        query = errors.Count == 0 ? new GameSearchQuery(term!, page, pageSize) : null;
        return query is not null;
    }
}
