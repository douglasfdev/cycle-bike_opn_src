namespace CycleBike.Core.Domain.Modules.Entities.Extensions;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; } = Guid.NewGuid();
    public bool IsDeleted { get; } = false;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; } = DateTime.UtcNow;
}