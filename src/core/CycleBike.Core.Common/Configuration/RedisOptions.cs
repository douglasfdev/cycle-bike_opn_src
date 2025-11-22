using System.Text.Json;

namespace CycleBike.Core.Common.Configuration;

public class RedisOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public int ConnectTimeout { get; set; } = 5000;
    public int SyncTimeout { get; set; } = 5000;
    public int AsyncTimeout { get; set; } = 5000;
    public bool AbortOnConnectFail { get; set; } = false;
}