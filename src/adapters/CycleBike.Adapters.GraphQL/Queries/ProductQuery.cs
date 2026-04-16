using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Requests;
using CycleBike.Core.Domain.Responses;

namespace CycleBike.Adapters.GraphQL.Queries;

[ExtendObjectType("Query")]
public class ProductQuery
{
    public async Task<ApiResult_Product> GetProductById(
        [Service] IQueryHandler<ProductQueries.GetProductById, Product> handler,
        Ulid id,
        CancellationToken cancellationToken)
    {
        var query = new ProductQueries.GetProductById(id);
        var result = await handler.HandleAsync(query, cancellationToken);
        return new ApiResult_Product(result);
    }

    public async Task<ApiResult_PagedProduct> GetAllProducts(
        [Service] IQueryHandler<ProductQueries.GetAllProducts, PagedResponse<Product>> handler,
        int page = 1,
        int pageSize = 10,
        ProductRequest.ProductSearchRequest? filters = null,
        CancellationToken cancellationToken = default)
    {
        filters ??= new ProductRequest.ProductSearchRequest(null, null, null);
        var query = new ProductQueries.GetAllProducts(page, pageSize, filters);
        var result = await handler.HandleAsync(query, cancellationToken);
        return new ApiResult_PagedProduct(result);
    }

    public async Task<ApiResult_OutboxEnvelopeList> GetPendingMessages(
        [Service] IQueryHandler<ProductQueries.GetPendingMessages, List<OutboxEnvelope?>> handler,
        CancellationToken cancellationToken)
    {
        var query = new ProductQueries.GetPendingMessages();
        var result = await handler.HandleAsync(query, cancellationToken);
        return new ApiResult_OutboxEnvelopeList(result);
    }

    public async Task<ApiResult_OutboxEnvelope?> GetPendingMessage(
        [Service] IQueryHandler<ProductQueries.GetPendingMessage, OutboxEnvelope?> handler,
        string id,
        CancellationToken cancellationToken)
    {
        var query = new ProductQueries.GetPendingMessage(id);
        var result = await handler.HandleAsync(query, cancellationToken);
        return result.IsSuccess ? new ApiResult_OutboxEnvelope(result) : null;
    }
}

public record ApiResult_Product(ApiResult<Product> Result)
{
    public bool IsSuccess => Result.IsSuccess;
    public Product? Data => Result.Data;
    public string? Message => Result.Message;
    public IReadOnlyCollection<string> Errors => Result.Errors;
    public int StatusCode => Result.StatusCode;
}

public record ApiResult_PagedProduct(ApiResult<PagedResponse<Product>> Result)
{
    public bool IsSuccess => Result.IsSuccess;
    public PagedResponse<Product>? Data => Result.Data;
    public string? Message => Result.Message;
    public IReadOnlyCollection<string> Errors => Result.Errors;
    public int StatusCode => Result.StatusCode;
}

public record ApiResult_OutboxEnvelopeList(ApiResult<List<OutboxEnvelope?>> Result)
{
    public bool IsSuccess => Result.IsSuccess;
    public List<OutboxEnvelope?>? Data => Result.Data;
    public string? Message => Result.Message;
    public IReadOnlyCollection<string> Errors => Result.Errors;
    public int StatusCode => Result.StatusCode;
}

public record ApiResult_OutboxEnvelope(ApiResult<OutboxEnvelope?> Result)
{
    public bool IsSuccess => Result.IsSuccess;
    public OutboxEnvelope? Data => Result.Data;
    public string? Message => Result.Message;
    public IReadOnlyCollection<string> Errors => Result.Errors;
    public int StatusCode => Result.StatusCode;
}
