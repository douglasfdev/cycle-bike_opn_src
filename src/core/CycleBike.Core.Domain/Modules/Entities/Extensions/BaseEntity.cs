namespace CycleBike.Core.Domain.Modules.Entities.Extensions;

public class BaseEntity : IBaseEntity, IEquatable<Ulid>, IEquatable<BaseEntity>
{
    public Ulid Id { get; private init; } = Ulid.NewUlid();
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    public bool Equals(Ulid other) => Id == other;

    public bool Equals(BaseEntity? other)
    {
        if (other is null) return false;
        return ReferenceEquals(this, other) || Id.Equals(other.Id);
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((BaseEntity)obj);
    }


    public override int GetHashCode() => HashCode.Combine(Id, IsDeleted, CreatedAt, UpdatedAt);
    
    public static bool operator ==(BaseEntity? left, BaseEntity? right) => Equals(left, right);

    public static bool operator !=(BaseEntity? left, BaseEntity? right) => !Equals(left, right);
}