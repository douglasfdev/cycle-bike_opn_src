using CycleBike.Adapters.SocketAdapter.Abstractions;
using CycleBike.Core.Domain.Entities;

namespace CycleBike.Adapters.NotificationWorker;

public class Worker(ILogger<Worker> logger, ISocketAdapter socketAdapter) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        socketAdapter.On<NotificationMessage>("notification", msg =>
        {
            logger.LogInformation(
                "[WORKER] Notification: Ok={Ok}, Source={Source}, Message={Message}",
                msg.Ok, msg.Source, msg.Message);
        });

        await socketAdapter.ConnectAsync(stoppingToken);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}