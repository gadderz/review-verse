using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using ReviewVerse.Game.Catalog.Application;

namespace ReviewVerse.Game.Catalog.API.Contracts;

public sealed class GameSearchRequest
{
    [FromQuery(Name = "name")]
    public string? Name { get; set; }

    [FromQuery(Name = "page")]
    public string? Page { get; set; }

    [FromQuery(Name = "pageSize")]
    public string? PageSize { get; set; }

    public bool TryValidate(
        IQueryCollection parameters,
        out GameSearchQuery? query,
        out Dictionary<string, string[]> errors
    )
    {
        var page = ReadInteger(parameters, "page", Page, 1, out var pageError);
        var pageSize = ReadInteger(parameters, "pageSize", PageSize, 20, out var pageSizeError);
        GameSearchQuery.TryCreate(Name, page, pageSize, out query, out errors);
        if (pageError)
            errors["page"] = ["Page must be a positive integer."];
        if (pageSizeError)
            errors["pageSize"] = ["Page size must be an integer between 1 and 100."];
        foreach (var key in new[] { "name", "page", "pageSize" })
            if (parameters[key].Count > 1)
                errors[key] = ["Provide a single value."];
        if (errors.Count != 0)
            query = null;
        return query is not null;
    }

    private static int ReadInteger(
        IQueryCollection parameters,
        string key,
        string? value,
        int defaultValue,
        out bool error
    )
    {
        error = false;
        if (!parameters.ContainsKey(key))
            return defaultValue;
        if (int.TryParse(value, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var result))
            return result;
        error = true;
        return 0;
    }
}
