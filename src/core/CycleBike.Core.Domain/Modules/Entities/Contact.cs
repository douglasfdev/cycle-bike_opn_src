namespace CycleBike.Core.Domain.Modules.Entities;

public class Contact
{
    public Ulid Id { get; set; }
    public Phone Phone { get; set; }
    public Address Address { get; set; }
    public string[] Email { get; set; }
}