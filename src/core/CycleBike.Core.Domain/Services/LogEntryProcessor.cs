using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Logging;
using Microsoft.Extensions.Logging;

namespace CycleBike.Core.Domain.Services;

public class LogEntryProcessor(ILogger<LogEntryProcessor> _logger, IDatabaseGenericRepository<LogEntry> _repository) : ILogEntryProcessor
{
    public async Task ProcessLogAsync(LogEntry log)
    {
        var enrichedLog = EnrichLog(log);
        await SaveLogAsync(enrichedLog);
    }

    public async Task ProcessLogsAsync(IEnumerable<LogEntry> logs)
    {
        var enrichedLogs = logs.Select(EnrichLog);
        await SaveLogsAsync(enrichedLogs);
    }
    
    private LogEntry EnrichLog(LogEntry log)
    {
        log.Properties["MachineName"] = Environment.MachineName;
        log.Properties["ApplicationName"] = "CycleBike";
        log.Properties["Environment"] = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        
        return log;
    }
    
    private async Task SaveLogAsync(LogEntry log)
    {
        await _repository.AddAsync(log);
        await _repository.CommitAsync();
    }

    private async Task SaveLogsAsync(IEnumerable<LogEntry> logs)
    {
        await _repository.AddRangeAsync(logs);
        await _repository.CommitAsync();
    }
}