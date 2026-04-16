using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Requests;

namespace CycleBike.Adapters.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class ProductMutation
{
    public async Task<MutationResult_Product> CreateProduct(
        [Service] ICommandHandler<ProductCommands.CreateProduct, Product> handler,
        CreateProductInput input,
        CancellationToken cancellationToken)
    {
        var command = new ProductCommands.CreateProduct(input.Name, input.Price, input.Description);
        var result = await handler.HandleAsync(command, cancellationToken);
        return new MutationResult_Product(result);
    }

    public async Task<MutationResult_Product> UpdateProduct(
        [Service] ICommandHandler<ProductCommands.UpdateProduct, Product> handler,
        UpdateProductInput input,
        CancellationToken cancellationToken)
    {
        var command = new ProductCommands.UpdateProduct(input.Id, input.Name, input.Price, input.Description);
        var result = await handler.HandleAsync(command, cancellationToken);
        return new MutationResult_Product(result);
    }

    public async Task<MutationResult_Product> DeleteProduct(
        [Service] ICommandHandler<ProductCommands.DeleteProduct, Product> handler,
        Ulid id,
        CancellationToken cancellationToken)
    {
        var command = new ProductCommands.DeleteProduct(id, true);
        var result = await handler.HandleAsync(command, cancellationToken);
        return new MutationResult_Product(result);
    }

    public async Task<MutationResult_Object> PublishProduct(
        [Service] ICommandHandler<ProductCommands.PublishProduct, object> handler,
        CreateProductInput input,
        CancellationToken cancellationToken)
    {
        var request = new ProductRequest.CreateProduct(input.Name, input.Price, input.Description);
        var command = new ProductCommands.PublishProduct(request);
        var result = await handler.HandleAsync(command, cancellationToken);
        return new MutationResult_Object(result);
    }
}

public record CreateProductInput(string Name, decimal Price, string Description);
public record UpdateProductInput(Ulid Id, string Name, decimal Price, string Description);

public record MutationResult_Product(ApiResult<Product> Result)
{
    public bool IsSuccess => Result.IsSuccess;
    public Product? Data => Result.Data;
    public string? Message => Result.Message;
    public IReadOnlyCollection<string> Errors => Result.Errors;
    public int StatusCode => Result.StatusCode;
}

public record MutationResult_Object(ApiResult<object> Result)
{
    public bool IsSuccess => Result.IsSuccess;
    public object? Data => Result.Data;
    public string? Message => Result.Message;
    public IReadOnlyCollection<string> Errors => Result.Errors;
    public int StatusCode => Result.StatusCode;
}
