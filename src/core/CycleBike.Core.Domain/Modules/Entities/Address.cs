using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Address : AggregateRoot
{
    public Ulid Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    
    /// <summary>
    /// Cria uma nova instância de Address.
    /// </summary>
    public Address() { }
    
    /// <summary>
    /// Cria uma nova instância de Address.
    /// </summary>
    /// <param name="street">A rua do endereço.</param>
    /// <param name="number">O número do endereço.</param>
    /// <param name="complement">O complemento do endereço.</param>
    /// <param name="neighborhood">O bairro do endereço.</param>
    /// <param name="city">A cidade do endereço.</param>
    /// <param name="state">O estado do endereço.</param>
    /// <param name="country">O país do endereço.</param>
    /// <param name="postalCode">O CEP do endereço.</param>
    public Address(string street, string number, string complement, string neighborhood, string city, string state, string country, string postalCode)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
    }
}