namespace CycleBike.Core.Domain.Entities.Extensions;

public record BaseEntity : IBaseEntity
{
    public Guid Id { get; } = Guid.NewGuid();
    public bool IsDeleted { get; } = false;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = null;
}