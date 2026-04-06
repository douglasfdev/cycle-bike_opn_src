using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Interfaces;

namespace Cycle.Core.Application.Modules.Product;

public class GetProductByIdHandler(IProductService service) : QueryHandler<ProductQueries.GetProductById, ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>>
{
    public override async Task<ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>> HandleAsync(ProductQueries.GetProductById query, CancellationToken cancellationToken)
    {
        var product = await service.GetByIdAsync(query.Id, cancellationToken);
        if (product == null)
            return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Failure("Product not found");
        return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Success(product);
    }
}
