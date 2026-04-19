namespace CycleBike.Core.Domain.Requests;

public static class ProductRequest
{
    public record CreateProduct(string Name, decimal Price, string Description, string? CreatedBy = null);
    public record UpdateProduct(Ulid Id, string Name, decimal Price, string Description);
    public record DeleteProduct(Ulid Id);
    public record ProductSearchRequest(string? Name, decimal? MinPrice, decimal? MaxPrice);
}
