namespace CycleBike.Core.Domain.Modules.Entities.Extensions;

public interface IBaseEntity
{
    Ulid Id { get; }
    string CreatedBy { get; }
    string UpdatedBy { get; }
    bool IsDeleted { get; }
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; }
}