namespace CycleBike.Core.Domain.Modules.Entities.Extensions;

public interface IBaseEntity
{
    Guid Id { get; }
    bool IsDeleted { get; }
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; }
}