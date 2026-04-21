using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Interfaces;

namespace Cycle.Core.Application.Modules.Product;

public class CreateProductHandler(
    ICacheService cacheService,
    IProductService service,
    IUserService userService)
    : CommandHandler<ProductCommands.CreateProduct, CycleBike.Core.Domain.Modules.Entities.Product>
{
    public override async Task<ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>> HandleAsync(ProductCommands.CreateProduct command, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(command.CreatedBy, out var createdBy)) throw new ArgumentException(nameof(command.CreatedBy));
        byte[] bytes = createdBy.ToByteArray();
        var ulid = new Ulid(bytes);
        
        var user = await userService.FindByIdAsync(ulid);
        var cached = await cacheService.GetOrSetDataAsync(command.Name, async () =>
        {
            var product = CycleBike.Core.Domain.Modules.Entities.Product.Create(command.Name, command.Price, command.Description, user.Id.ToString());
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