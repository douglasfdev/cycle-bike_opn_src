using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Contact : AggregateRoot
{
    public ICollection<Phone> Phones { get; set; }
    public Address Address { get; set; }
    public string Email { get; set; }
}