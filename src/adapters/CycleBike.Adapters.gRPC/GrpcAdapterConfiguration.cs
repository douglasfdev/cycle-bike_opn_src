namespace CycleBike.Adapters.gRPC;

public class GrpcAdapterConfiguration
{
    public const string SectionName = "GrpcAdapter";
    
    public int Port { get; set; } = 8081;
    public bool EnableHealthCheck { get; set; } = true;
    public string? AllowedOrigins { get; set; } = "*";
    public int MaxMessageSize { get; set; } = 4 * 1024 * 1024; // 4MB
    public int KeepAliveTimeMs { get; set; } = 10000;
    public int KeepAliveTimeoutMs { get; set; } = 3000;
    public bool EnableCompression { get; set; } = true;
}
