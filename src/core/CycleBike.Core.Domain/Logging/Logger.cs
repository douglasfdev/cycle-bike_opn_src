using System.Threading.Channels;
using CycleBike.Core.Common.Configuration;
using Microsoft.Extensions.Logging;

namespace CycleBike.Core.Domain.Logging;

public class Logger(string categoryName, Channel<LogEntry> logChannel, LoggerOptions opts) : ILogger
{
    public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= opts.MinimumLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        try
        {
            var logEntry = LogEntry.Create(logLevel.ToString(), formatter(state, exception), categoryName, string.Empty, exception?.ToString());

            logChannel.Writer.TryWrite(logEntry);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to write log: {ex.Message}");
        }
    }
    
    private Dictionary<string, object> ConvertProperties<TState>(TState state)
    {
        var properties = new Dictionary<string, object>();
        
        if (state is IEnumerable<KeyValuePair<string, object>> keyValuePairs)
        {
            foreach (var kvp in keyValuePairs)
            {
                properties[kvp.Key] = kvp.Value;
            }
        }
        else if (state is not null)
        {
            properties["State"] = state;
        }

        return properties;
    }

    private class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();
        public void Dispose() { }
    }
}