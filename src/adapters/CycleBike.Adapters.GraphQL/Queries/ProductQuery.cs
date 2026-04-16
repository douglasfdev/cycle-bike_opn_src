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
    public async Task<ApiResult<Product>> GetProductById(
        [Service] IQueryHandler<ProductQueries.GetProductById, Product> handler,
        Ulid id,
        CancellationToken cancellationToken)
    {
        var query = new ProductQueries.GetProductById(id);
        return await handler.HandleAsync(query, cancellationToken);
    }

    public async Task<ApiResult<PagedResponse<Product>>> GetAllProducts(
        [Service] IQueryHandler<ProductQueries.GetAllProducts, PagedResponse<Product>> handler,
        int page = 1,
        int pageSize = 10,
        ProductRequest.ProductSearchRequest? filters = null,
        CancellationToken cancellationToken = default)
    {
        filters ??= new ProductRequest.ProductSearchRequest(null, null, null);
        var query = new ProductQueries.GetAllProducts(page, pageSize, filters);
        return await handler.HandleAsync(query, cancellationToken);
    }

    public async Task<ApiResult<List<OutboxEnvelope?>>> GetPendingMessages(
        [Service] IQueryHandler<ProductQueries.GetPendingMessages, List<OutboxEnvelope?>> handler,
        CancellationToken cancellationToken)
    {
        var query = new ProductQueries.GetPendingMessages();
        return await handler.HandleAsync(query, cancellationToken);
    }

    public async Task<ApiResult<OutboxEnvelope?>> GetPendingMessage(
        [Service] IQueryHandler<ProductQueries.GetPendingMessage, OutboxEnvelope?> handler,
        string id,
        CancellationToken cancellationToken)
    {
        var query = new ProductQueries.GetPendingMessage(id);
       return await handler.HandleAsync(query, cancellationToken);
    }
}