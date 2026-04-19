using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Account(Ulid id, string createdBy, Profile profile) : AggregateRoot(createdBy)
{
    public Profile Profile { get; set; } = profile;
}