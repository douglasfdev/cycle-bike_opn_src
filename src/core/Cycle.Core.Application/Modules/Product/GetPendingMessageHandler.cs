using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;

namespace Cycle.Core.Application.Modules.Product;

public class GetPendingMessageHandler(IOutboxService outboxService)
    : QueryHandler<ProductQueries.GetPendingMessage, OutboxEnvelope?>
{
    public override async Task<ApiResult<OutboxEnvelope?>> HandleAsync(ProductQueries.GetPendingMessage query, CancellationToken cancellationToken)
    {
        var message = await outboxService.GetPendingMessageAsync(query.Id);
        return ApiResult<OutboxEnvelope?>.Success(message);
    }
}
