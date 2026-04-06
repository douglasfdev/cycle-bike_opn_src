using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Responses;

namespace Cycle.Core.Application.Modules.Product;

public class GetAllProductsHandler(IProductService service) : QueryHandler<ProductQueries.GetAllProducts, ApiResult<PagedResponse<CycleBike.Core.Domain.Modules.Entities.Product>>>
{
    public override async Task<ApiResult<PagedResponse<CycleBike.Core.Domain.Modules.Entities.Product>>> HandleAsync(ProductQueries.GetAllProducts query, CancellationToken cancellationToken)
    {
        var products = await service.GetAllAsync(query.Page, query.PageSize, query.Filters, cancellationToken);
        return ApiResult<PagedResponse<CycleBike.Core.Domain.Modules.Entities.Product>>.Success(products);
    }
}
