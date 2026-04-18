using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Interfaces;

namespace Cycle.Core.Application.Modules.Product;

public class CreateProductHandler(
    ICacheService cacheService,
    IProductService service)
    : CommandHandler<ProductCommands.CreateProduct, CycleBike.Core.Domain.Modules.Entities.Product>
{
    public override async Task<ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>> HandleAsync(ProductCommands.CreateProduct command, CancellationToken cancellationToken)
    {
        var cached = await cacheService.GetOrSetDataAsync(command.Name, async () =>
        {
            var product = new CycleBike.Core.Domain.Modules.Entities.Product(command.Name, command.Price, command.Description);
            await service.CreateAsync(product, cancellationToken);
            return product;
        }, TimeSpan.FromMinutes(10));

        if (cached is null)
        {
            return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Failure("Failed to create product");
        }

        return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Success("Product created successfully", cached, 201);
    }
}