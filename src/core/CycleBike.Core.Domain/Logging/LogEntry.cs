namespace CycleBike.Core.Domain.Logging;

public class LogEntry
{
    private Ulid Id { get; init; } = Ulid.NewUlid();
    private DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public string ApplicationName { get; set; }
    private string Level { get; init; }
    private string Message { get; init; }
    private string Category { get; init; }
    private string? Exception { get; init; }
    public IDictionary<string, object> Properties { get; init; } = new Dictionary<string, object>();

    public LogEntry() {}
    
    private LogEntry(string level, string message, string category, string? exception)
    {
        Level = level;
        Message = message;
        Category = category;
        Exception = exception;
    }

    public static LogEntry Create(string level, string message, string category, string? exception) =>
        new(level, message, category, exception);
}