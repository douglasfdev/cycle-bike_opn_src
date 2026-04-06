using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Requests;
using CycleBike.Core.Domain.Responses;

namespace CycleBike.Core.Domain.Interfaces;

public interface IProductService
{
    public Task<bool> CreateAsync(Product entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Product entity, CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(Ulid id, CancellationToken cancellationToken);
    Task<PagedResponse<Product>> GetAllAsync(int page, int pageSize, ProductRequest.ProductSearchRequest filters, CancellationToken cancellationToken);

}