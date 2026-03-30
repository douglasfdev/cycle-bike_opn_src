using CycleBike.Core.Domain.Interfaces;

namespace CycleBike.Adapters.OutboxRelay;

public class Worker(ILogger<Worker> logger, IOutboxRelayService outboxRelayService): BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await outboxRelayService.RelayAsync(new OutboxMessage());
    }
}

public class OutboxMessage
{
}