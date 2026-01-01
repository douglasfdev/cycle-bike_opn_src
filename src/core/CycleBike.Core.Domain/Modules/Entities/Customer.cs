using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.Enums;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Customer : AggregateRoot
{
    public Ulid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string DocumentType { get; set; }
    
    
    /// <summary>
    /// Cria uma nova instância de Customer.
    /// </summary>
    public Customer() { }
    
    
    /// <summary>
    /// Cria uma nova instância de Customer.
    /// </summary>
    /// <param name="name">O nome do cliente.</param>
    /// <param name="email">O email do cliente.</param>
    /// <param name="document">O documento do cliente.</param>
    /// <param name="documentType">O tipo do documento do cliente.</param>
    public Customer(string name, string email, string document, DocumentType documentType)
    {
        Name = name;
        Email = email;
        Document = document;
        DocumentType = documentType.ToString().ToUpperInvariant();
    }
}