using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Phone : AggregateRoot
{
    public Ulid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string AreaCode { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Cria uma nova instância de Phone.
    /// </summary>
    public Phone() { }
    
    /// <summary>
    /// Cria uma nova instância de Phone.
    /// </summary>
    /// <param name="number">O número do telefone.</param>
    /// <param name="areaCode">O código de área do telefone.</param>
    /// <param name="countryCode">O código do país do telefone.</param>
    /// <param name="type">O tipo do telefone.</param>
    public Phone(string number, string areaCode, string countryCode, string type)
    {
        Number = number;
        AreaCode = areaCode;
        CountryCode = countryCode;
        Type = type;
    }
}