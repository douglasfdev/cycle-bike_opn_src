using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Interfaces;

namespace Cycle.Core.Application.Modules.Product;

public class UpdateProductHandler(IProductService service) : CommandHandler<ProductCommands.UpdateProduct, CycleBike.Core.Domain.Modules.Entities.Product>
{
    public override async Task<ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>> HandleAsync(ProductCommands.UpdateProduct command, CancellationToken cancellationToken)
    {
        var product = await service.GetByIdAsync(command.Id, cancellationToken);
        if (product == null)
            return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Failure("Product not found");

        product.Name = command.Name;
        product.Price = command.Price;
        product.Description = command.Description;

        await service.UpdateAsync(product, cancellationToken);
        return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Success(product);
    }
}
