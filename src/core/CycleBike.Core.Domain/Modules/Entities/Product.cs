using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Product : AggregateRoot
{
    public Ulid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Cria uma nova instância de Product.
    /// </summary>
    public Product() { }

    /// <summary>
    /// Cria uma nova instância de Product.
    /// </summary>
    /// <param name="name">O nome do produto.</param>
    /// <param name="price">O preço do produto.</param>
    /// <param name="description">A descrição do produto.</param>
    public Product(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
}