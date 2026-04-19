using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;
public class User : AggregateRoot
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    
    private readonly List<Trial> _trials = new();
    public IReadOnlyCollection<Trial> Trials => _trials.AsReadOnly();
    
    private readonly List<AccessControl> _accessControls = new();
    public IReadOnlyCollection<AccessControl> AccessControls => _accessControls.AsReadOnly();

    private User(string  createdBy, string username, string email, string passwordHash)
        : base(createdBy)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
    }

    public static User Create(string createdBy, string username, string email, string passwordHash)
    {
        return new User(
            createdBy,
            username,
            email,
            passwordHash
        );
    }

    public void AddTrial(Trial trial)
    {
        _trials.Add(trial);
    }

    public void AddAccessControl(AccessControl accessControl)
    {
        _accessControls.Add(accessControl);
    }

    public void Update(Ulid updatedBy, string? username = null, string? email = null)
    {
        if (!string.IsNullOrEmpty(username)) Username = username;
        if (!string.IsNullOrEmpty(email)) Email = email;
        
        Update(updatedBy);
    }

    public void Deactivate(Ulid deactivatedBy)
    {
        if (!IsActive) return;
        
        IsActive = false;
        Update(deactivatedBy);
    }
}