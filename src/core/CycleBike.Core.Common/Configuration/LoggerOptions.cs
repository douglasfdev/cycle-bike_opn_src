using Microsoft.Extensions.Logging;

namespace CycleBike.Core.Common.Configuration;

public class LoggerOptions
{
    public int BatchSize { get; set; }
    public TimeSpan BatchTimeout { get; set; }
    public string Endpoint { get; set; }
    public LogLevel MinimumLevel { get; set; }
}