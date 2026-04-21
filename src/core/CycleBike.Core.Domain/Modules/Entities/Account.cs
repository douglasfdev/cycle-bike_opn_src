using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Account : AggregateRoot
{
    public Profile Profile { get; set; }
    
    public Account() : base(default!) {}

    private Account(Profile profile, string createdBy) : base(createdBy)
    {
        Profile = profile;
        CreatedBy = createdBy;
    }

    public static Account Create(Profile profile, string createdBy)
        => new(profile, createdBy);
}