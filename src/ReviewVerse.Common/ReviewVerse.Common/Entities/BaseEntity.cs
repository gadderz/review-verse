namespace ReviewVerse.Common.Entities;

public abstract class BaseEntity<T> : IAuditable
{
    public T Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; } = default!;
    public string? UpdatedBy { get; set; }
}

public class BaseEntity : BaseEntity<Guid> { }
