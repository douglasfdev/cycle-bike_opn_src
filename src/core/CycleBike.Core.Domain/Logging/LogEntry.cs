using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Logging;

public class LogEntry : AggregateRoot
{
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public string ApplicationName { get; set; } = string.Empty;
    public string Level { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string? Exception { get; init; } = string.Empty;
    public IDictionary<string, object> Properties { get; init; } = new Dictionary<string, object>();

    public LogEntry() : base(default!) {}
    
    private LogEntry(string level, string message, string category, string applicationName, string createdBy, string? exception) : base(createdBy)
    {
        Level = level;
        Message = message;
        Category = category;
        Exception = exception;
        ApplicationName = applicationName;
        CreatedBy = createdBy;
    }

    public static LogEntry Create(string level, string message, string category, string applicationName, string createdBy, string? exception) =>
        new(level, message, category, applicationName, createdBy, exception);
}