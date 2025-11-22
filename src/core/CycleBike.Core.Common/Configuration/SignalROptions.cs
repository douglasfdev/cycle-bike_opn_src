namespace CycleBike.Core.Common.Configuration;

public sealed record SignalROptions
{
    public required string HubUrl { get; init; }
    public bool AutomaticReconnect { get; init; } = true;
    public int[] ReconnectDelays { get; init; } = [0, 2000, 10000, 30000];
    public TimeSpan HandshakeTimeout { get; init; } = TimeSpan.FromSeconds(15);
    public TimeSpan KeepAliveInterval { get; init; } = TimeSpan.FromSeconds(15);
    public TimeSpan ServerTimeout { get; init; } = TimeSpan.FromSeconds(30);
    public Dictionary<string, string>? Headers { get; init; }
    public Func<string>? AccessTokenProvider { get; init; }
}