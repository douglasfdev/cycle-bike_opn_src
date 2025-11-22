namespace CycleBike.Adapters.GenericHttpClient.Models;

public class HttpRequestConfig
{
    public Dictionary<string, string> Headers { get; set; } = new();
    public Dictionary<string, string> QueryParameters { get; set; } = new();
    public TimeSpan? Timeout { get; set; }
    public AuthenticationConfig? Authentication { get; set; }
}