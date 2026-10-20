using ReviewVerse.Game.Catalog.Application;
using Xunit;

namespace ReviewVerse.Game.Catalog.UnitTests;

public sealed class GameSearchQueryTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" \t\n ")]
    public void RejectsMissingName(string? name)
    {
        Assert.False(GameSearchQuery.TryCreate(name, 1, 20, out var query, out var errors));
        Assert.Null(query);
        Assert.Contains("name", errors.Keys);
    }

    [Fact]
    public void ValidatesLengthAfterTrimmingWithoutChangingLiteralContent()
    {
        var term = "A_%\\ ção" + new string('x', 192);
        Assert.Equal(200, term.Length);
        Assert.True(GameSearchQuery.TryCreate($" \t{term}\n", 1, 100, out var query, out _));
        Assert.Equal(term, query!.Name);
        Assert.False(GameSearchQuery.TryCreate(term + "x", 1, 20, out _, out var errors));
        Assert.Contains("name", errors.Keys);
    }

    [Theory]
    [InlineData(0, 20, "page")]
    [InlineData(-1, 20, "page")]
    [InlineData(1, 0, "pageSize")]
    [InlineData(1, 101, "pageSize")]
    public void RejectsInvalidPagination(int page, int size, string field)
    {
        Assert.False(GameSearchQuery.TryCreate("game", page, size, out _, out var errors));
        Assert.Contains(field, errors.Keys);
    }

    [Fact]
    public void CalculatesLargePageOffsetWithoutOverflow()
    {
        Assert.True(GameSearchQuery.TryCreate("game", int.MaxValue, 100, out var query, out _));
        Assert.Equal(214748364600L, query!.Offset);
    }
}
