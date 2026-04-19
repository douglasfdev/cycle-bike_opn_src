using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class AccessControl : AggregateRoot
{
    public Ulid UserId { get; private set; }
    public string Role { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime LastAccess { get; private set; }

    private AccessControl(string  createdBy, Ulid userId, string role)
        : base(createdBy)
    {
        UserId = userId;
        Role = role;
        IsActive = true;
        LastAccess = DateTime.UtcNow;
    }

    public static AccessControl Create(string clientId, Ulid userId, string role)
        => new (
            clientId,
            userId,
            role
        );

    public void UpdateLastAccess(string updatedBy)
    {
        LastAccess = DateTime.UtcNow;
        Update(updatedBy);
    }

    public void Deactivate(string deactivatedBy)
    {
        if (!IsActive) return;
        
        IsActive = false;
        Update(deactivatedBy);
    }
}