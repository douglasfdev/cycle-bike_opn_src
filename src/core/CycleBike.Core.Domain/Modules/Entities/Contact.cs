using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Contact : AggregateRoot
{
    private readonly List<Phone> _phones = new();
    public virtual IReadOnlyCollection<Phone> Phones => _phones.AsReadOnly();
    public Address Address { get; set; }
    public string Email { get; set; }
    
    public Contact() : base(default!) { }

    private Contact(List<Phone> phones, Address address, string email, string createdBy) : base(createdBy)
    {
        _phones = phones;
        Address = address;
        Email = email;
    }

    public static Contact Create(List<Phone> phones, Address address, string email, string createdBy)
        => new(phones, address, email, createdBy);
    
    public void AddPhone(Phone phone)
    {
        if (_phones.Any(p => p.Number == phone.Number)) return;
        _phones.Add(phone);
    }
}