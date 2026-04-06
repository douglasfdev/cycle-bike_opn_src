using System.Linq.Expressions;
using CycleBike.Core.Domain.Filters;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Requests;
using CycleBike.Core.Domain.Responses;

namespace CycleBike.Core.Domain.Services;

public class ProductService(IDatabaseGenericRepository<Product> repository) : FilterableService<Product, ProductRequest.ProductSearchRequest>, IProductService
{
    public async Task<bool> CreateAsync(Product entity, CancellationToken cancellationToken)
    {
        await repository.AddAsync(entity);
        await repository.CommitAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        var searchProduct = await repository.GetByPredicateAsync(x => x.Id == product.Id && !x.IsDeleted);

        if (searchProduct is not null)
        {
            searchProduct.IsDeleted = true;
            repository.Update(searchProduct);
            await repository.CommitAsync();
            return true;
        }

        return false;
    }
    
    public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var searchProduct = await repository.GetByPredicateAsync(x => x.Id == product.Id && !x.IsDeleted);

        if (searchProduct is not null)
        {
            searchProduct.Name = product.Name;
            searchProduct.Price = product.Price;
            searchProduct.Description = product.Description;
            repository.Update(searchProduct);
            await repository.CommitAsync();
            return true;
        }

        return false;
    }
    
    public async Task<PagedResponse<Product>> GetAllAsync(int page, int pageSize, ProductRequest.ProductSearchRequest filters, CancellationToken cancellationToken)
    {
        var query = repository.GetQueryable();
        query = query.Where(x => !x.IsDeleted);

        var filteredQuery = ApplyFilters(query, filters);

        return await repository.GetPagedAsync(page, pageSize, filteredQuery);
    }
    
    public async Task<Product?> GetByIdAsync(Ulid id, CancellationToken cancellationToken)
    {
        return await repository.GetByPredicateAsync(x => x.Id == id && !x.IsDeleted);
    }

    protected override IQueryable<Product> ApplyFilters(IQueryable<Product> query, ProductRequest.ProductSearchRequest filters)
    {
        var filteredQuery = query.Where(GetProductPredicate(filters));
        return filteredQuery;
    }
    
    /// <summary>
    /// Centraliza as regras de filtragem de produtos. 
    /// Facilitando a manutenção de campos e critérios.
    /// </summary>
    private static Expression<Func<Product, bool>> GetProductPredicate(ProductRequest.ProductSearchRequest filters)
    {
        return product =>
            (string.IsNullOrWhiteSpace(filters.Name) || 
             product.Name.ToLower().Contains(filters.Name.ToLower())) &&

            (!filters.MinPrice.HasValue || 
             product.Price >= filters.MinPrice.Value) &&

            (!filters.MaxPrice.HasValue || 
             product.Price <= filters.MaxPrice.Value);
    }
}