using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Interfaces;

namespace Cycle.Core.Application.Modules.Product;

/// <summary>
/// This handler is a example of a command handler that creates a product in cache
/// </summary>
/// <param name="cacheService"></param>
/// <param name="outboxService"></param>
public class CreateProductCacheHandler(
    ICacheService cacheService,
    IOutboxService outboxService)
    : CommandHandler<ProductCommands.CreateProduct, CycleBike.Core.Domain.Modules.Entities.Product>
{
    public override async Task<ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>> HandleAsync(ProductCommands.CreateProduct command, CancellationToken cancellationToken)
    {
        var getCache = await cacheService.GetOrSetDataAsync(command.Name, async () =>
        {
            var product = new CycleBike.Core.Domain.Modules.Entities.Product(command.Name, command.Price, command.Description);
            await outboxService.EnqueueAsync(product);
            
            return product;
        }, TimeSpan.FromMinutes(2));
        
        return ApiResult<CycleBike.Core.Domain.Modules.Entities.Product>.Success("Cache retrieved", getCache, 200);
    }
}
