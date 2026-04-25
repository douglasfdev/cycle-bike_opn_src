using CycleBike.Core.Domain.Logging;

namespace CycleBike.Core.Domain.Interfaces;

public interface ILogRepository
{
    Task SaveLogAsync(LogEntry log);
    Task SaveLogsAsync(IEnumerable<LogEntry> logs);
}