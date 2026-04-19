using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Profile : AggregateRoot
{
    public Profile() : base(default!) { }
    private Profile(Ulid accountId, Customer customer, Contact contact, Address address, string createdBy) : base(createdBy)
    {
        AccountId = accountId;
        Customer = customer;
        Contact = contact;
        Address = address;
        CreatedBy = createdBy;
    }

    public Ulid AccountId { get; set; }
    public Customer Customer { get; set; }
    public Contact Contact { get; set; }
    public Address Address { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; } = new();
    
    public static Profile Create(Ulid accountId, Customer customer, Contact contact, Address address, string createdBy)
        => new (accountId, customer, contact, address, createdBy);
}