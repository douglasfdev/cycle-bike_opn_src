using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Requests;

namespace CycleBike.Adapters.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class ProductMutation
{
    public async Task<ApiResult<Product>> CreateProduct(
        [Service] ICommandHandler<ProductCommands.CreateProduct, Product> handler,
        ProductRequest.CreateProduct input,
        CancellationToken cancellationToken)
    {
        var command = new ProductCommands.CreateProduct(input.Name, input.Price, input.Description);
        return await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<ApiResult<Product>> UpdateProduct(
        [Service] ICommandHandler<ProductCommands.UpdateProduct, Product> handler,
        ProductRequest.UpdateProduct input,
        CancellationToken cancellationToken)
    {
        var command = new ProductCommands.UpdateProduct(input.Id, input.Name, input.Price, input.Description);
        return await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<ApiResult<Product>> DeleteProduct(
        [Service] ICommandHandler<ProductCommands.DeleteProduct, Product> handler,
        Ulid id,
        CancellationToken cancellationToken)
    {
        var command = new ProductCommands.DeleteProduct(id, true);
        return await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<ApiResult<object>> PublishProduct(
        [Service] ICommandHandler<ProductCommands.PublishProduct, object> handler,
        ProductRequest.CreateProduct input,
        CancellationToken cancellationToken)
    {
        var request = new ProductRequest.CreateProduct(input.Name, input.Price, input.Description);
        var command = new ProductCommands.PublishProduct(request);
        return await handler.HandleAsync(command, cancellationToken);
    }
}
