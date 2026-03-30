namespace CycleBike.Core.Domain.Modules.Entities;

public class Profile
{
    public string Id { get => Id.ToString(); set; }
    public Ulid AccountId { get; set; }
    public Customer Customer { get; set; }
    public Contact Contact { get; set; }
    public Address Address { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; }
}