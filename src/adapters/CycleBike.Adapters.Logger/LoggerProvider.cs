using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Channels;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Domain.Logging;
using Microsoft.Extensions.Logging;

namespace CycleBike.Adapters.Logger;

public class LoggerProvider : ILoggerProvider
{
    private readonly LoggerOptions _options;
    private readonly ILogger _logger;
    private readonly Channel<LogEntry> _logChannel;
    private readonly Task _workerTask;
    private readonly HttpClient _httpClient = new();
    private readonly CancellationTokenSource _cts = new();

    public LoggerProvider(LoggerOptions options)
    {
        _options = options;
        _logChannel = Channel.CreateUnbounded<LogEntry>();
        _logger = LoggerFactory.Create(builder => 
            builder.AddConsole()).CreateLogger(nameof(LoggerProvider));
        _workerTask = Task.Run(WorkerAsync); 
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new CycleBike.Core.Domain.Logging.Logger(categoryName, _logChannel, _options);
    }
    
    public void Dispose()
    {
        _cts.Cancel();
        _logChannel.Writer.TryComplete();
        _workerTask.GetAwaiter().GetResult();
        _httpClient.Dispose();
    }
    
    private async Task WorkerAsync()
    {
        var batch = new List<LogEntry>();
        var batchSize = _options.BatchSize;
        var batchTimeout = _options.BatchTimeout;

        using var timer = new PeriodicTimer(batchTimeout);
        
        try
        {
            while (await _logChannel.Reader.WaitToReadAsync())
            {
                while (_logChannel.Reader.TryRead(out var log))
                {
                    batch.Add(log);
                    
                    if (batch.Count >= batchSize)
                    {
                        await SendBatchAsync(batch);
                        batch.Clear();
                    }
                }
            }

            if (batch.Count > 0)
            {
                await SendBatchAsync(batch);
            }
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogError(ex, "Worker crashed");
        }
    }
    
    private async Task SendBatchAsync(List<LogEntry> batch)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _options.Endpoint);
            request.Content = new StringContent(JsonSerializer.Serialize(batch));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            await _httpClient.SendAsync(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send batch");
        }
    }
}