using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using System.Text.Json;
using Cycle.Core.Application.Responses;

namespace Cycle.Core.Application.Modules.Product;

public class GetPendingMessagesHandler(IOutboxService outboxService)
    : QueryHandler<ProductQueries.GetPendingMessages, List<OutboxEnvelope?>>
{
    public override async Task<ApiResult<List<OutboxEnvelope?>>> HandleAsync(ProductQueries.GetPendingMessages query, CancellationToken cancellationToken)
    {
        var envelopes = await outboxService.GetPendingMessagesAsync();
        var resolved = envelopes.Select<OutboxEnvelope, OutboxEnvelope?>(envelope =>
        {
            if (envelope.MessageType is null) return null;
            try
            {
                var messageType = Type.GetType(envelope.MessageType);

                if (messageType == null) return null;

                var decodedContent = JsonSerializer.Deserialize<OutboxEnvelope>(envelope.Data);

                if (decodedContent is null) return null;

                return decodedContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }).ToList();

        return ApiResult<List<OutboxEnvelope?>>.Success(resolved);
    }
}
