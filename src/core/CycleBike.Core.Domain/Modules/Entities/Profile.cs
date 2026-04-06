using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Profile : AggregateRoot
{
    public Profile() { }
    public Profile(Ulid accountId, Customer customer, Contact contact, Address address)
    {
        AccountId = accountId;
        Customer = customer;
        Contact = contact;
        Address = address;
    }

    public Ulid AccountId { get; set; }
    public Customer Customer { get; set; }
    public Contact Contact { get; set; }
    public Address Address { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; } = new();
}