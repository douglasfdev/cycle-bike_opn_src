namespace CycleBike.Core.Common.Configuration;

public sealed record SocketIOAdapterOptions
{
    public required string ServerUrl { get; init; }
    public bool Reconnection { get; init; } = true;
    public int ReconnectionAttempts { get; init; } = 5;
    public int ReconnectionDelay { get; init; } = 1000;
    public TimeSpan ConnectionTimeout { get; init; } = TimeSpan.FromSeconds(20);
}