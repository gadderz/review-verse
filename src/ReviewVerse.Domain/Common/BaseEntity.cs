namespace ReviewVerse.Domain.Common;

public abstract class BaseEntity<TId>
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
}
