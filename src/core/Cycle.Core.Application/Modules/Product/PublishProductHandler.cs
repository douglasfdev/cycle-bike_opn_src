using System.Text.Json;
using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Requests.Events;
using Microsoft.Extensions.Logging;

namespace Cycle.Core.Application.Modules.Product;

public class PublishProductHandler(
    ILogger<PublishProductHandler> logger,
    IMessagePublisher messagePublisher,
    IOutboxService outboxService)
    : CommandHandler<ProductCommands.PublishProduct, object>
{
    public override async Task<ApiResult<object>> HandleAsync(ProductCommands.PublishProduct command, CancellationToken cancellationToken)
    {
        var envelope = await outboxService.EnqueueAsync(command.Request);
        await messagePublisher.PublishAsync(envelope,  nameof(Process.ProductProcess.ProductRegistration), nameof(RoutingKey.Step.Initial));
        envelope.SetSent(true, DateTime.UtcNow);
        
        await outboxService.UpdateAsync(envelope);
        
        logger.LogInformation("Dispatched '{envelop}'", JsonSerializer.Serialize(envelope));

        return ApiResult<object>.Success("Produto sendo processado", 202);
    }
}
