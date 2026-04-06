using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Interfaces;

namespace Cycle.Core.Application.Modules.Product;

public class CreateProductHandler(
    IProductService service)
    : CommandHandler<ProductCommands.CreateProduct, CycleBike.Core.Domain.Modules.Entities.Product>
{
    public override async Task<ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>> HandleAsync(ProductCommands.CreateProduct command, CancellationToken cancellationToken)
    {
        var product = new CycleBike.Core.Domain.Modules.Entities.Product(command.Name, command.Price, command.Description);
        var created = await service.CreateAsync(product, cancellationToken);
        if (!created)
        {
            return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Failure("Failed to create product");
        }

        return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Success("Product created successfully", product, 201);
    }
}