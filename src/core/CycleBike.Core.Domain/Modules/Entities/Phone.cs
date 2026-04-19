using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Phone : AggregateRoot
{
    public string Number { get; set; } = string.Empty;
    public string AreaCode { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Ulid ContactId { get; set; }

    /// <summary>
    /// Cria uma nova instância de Phone.
    /// </summary>
    public Phone() : base(default!) { }
    
    /// <summary>
    /// Cria uma nova instância de Phone.
    /// </summary>
    /// <param name="number">O número do telefone.</param>
    /// <param name="areaCode">O código de área do telefone.</param>
    /// <param name="countryCode">O código do país do telefone.</param>
    /// <param name="type">O tipo do telefone.</param>
    /// <param name="createdBy">O Identificador de quem criou</param>
    private Phone(string number, string areaCode, string countryCode, string type, string createdBy) : base(createdBy)
    {
        Number = number;
        AreaCode = areaCode;
        CountryCode = countryCode;
        Type = type;
        CreatedBy = createdBy;
    }

    public static Phone Create(string number, string areaCode, string countryCode, string type, string createdBy)
        => new(number, areaCode, countryCode, type, createdBy);
    
    public Contact Contact { get; set; }

    public void AddContact(Contact contact)
    {
        Contact = contact;
    }
}