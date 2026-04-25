using RabbitMQ.Client;

namespace CycleBike.Adapters.LogGateway.Services;

public class LogProcessingWorker : BackgroundService
{
    private readonly ILogger<LogProcessingWorker> _logger;
    private readonly IConnection _rabbitConnection;
    private readonly IModel _channel;

    public LogProcessingWorker(ILogger<LogProcessingWorker> logger, IConnection rabbitConnection)
    {
        _logger = logger;
        _rabbitConnection = rabbitConnection;
        _channel = rabbitConnection.CreateModel();
        _channel.QueueDeclare(queue: "logs.processing", durable: true, exclusive: false, autoDelete: false, arguments: null);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessLogsAsync(stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task ProcessLogsAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Processing logs...");
            
            await Task.Delay(100, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing logs");
        }
    }

    public override void Dispose()
    {
        _channel?.Dispose();
        _rabbitConnection?.Dispose();
        base.Dispose();
    }
}