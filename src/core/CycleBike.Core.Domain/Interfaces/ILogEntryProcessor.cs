using CycleBike.Core.Domain.Logging;

namespace CycleBike.Core.Domain.Interfaces;

public interface ILogEntryProcessor
{
    Task ProcessLogAsync(LogEntry log);
    Task ProcessLogsAsync(IEnumerable<LogEntry> logs);
}