using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Logging;

public class LogEntry : AggregateRoot
{
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public string ApplicationName { get; set; }
    public string Level { get; init; }
    public string Message { get; init; }
    public string Category { get; init; }
    public string? Exception { get; init; }
    public IDictionary<string, object> Properties { get; init; } = new Dictionary<string, object>();

    public LogEntry() : base(default!) {}
    
    private LogEntry(string level, string message, string category, string createdBy, string? exception) : base(createdBy)
    {
        Level = level;
        Message = message;
        Category = category;
        Exception = exception;
        CreatedBy = createdBy;
    }

    public static LogEntry Create(string level, string message, string category, string createdBy, string? exception) =>
        new(level, message, category, createdBy, exception);
}