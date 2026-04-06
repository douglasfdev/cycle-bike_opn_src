using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Account : AggregateRoot
{
    public Profile Profile { get; set; }
}