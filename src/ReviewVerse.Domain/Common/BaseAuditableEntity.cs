namespace ReviewVerse.Domain.Common;

public abstract class BaseAuditableEntity<TId> : BaseEntity<TId>
    where TId : struct, IEquatable<TId>
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? DeletedBy { get; set; }
}
