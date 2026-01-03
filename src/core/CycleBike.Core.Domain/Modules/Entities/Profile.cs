namespace CycleBike.Core.Domain.Modules.Entities;

public class Profile
{
    public Ulid Id { get; set; }
    public Ulid AccountId { get; set; }
    public Customer Customer { get; set; }
    public Contact Contact { get; set; }
    public Address Address { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; }
}