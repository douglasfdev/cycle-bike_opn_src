using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Product : AggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Cria uma nova instância de Product.
    /// </summary>
    public Product() : base(default!){ }

    /// <summary>
    /// Cria uma nova instância de Product com nome preço e descrição.
    /// </summary>
    /// <param name="name">O nome do produto.</param>
    /// <param name="price">O preço do produto.</param>
    /// <param name="description">A descrição do produto.</param>
    ///  <param name="createdBy">O Identificador de quem criou</param>
    private Product(string name, decimal price, string description, string createdBy): base(createdBy)
    {
        Name = name;
        Price = price;
        Description = description;
        CreatedBy = createdBy;
    }

    public static Product Create(string name, decimal price, string description, string createdBy)
        => new(name, price, description, createdBy);
}