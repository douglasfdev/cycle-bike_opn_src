using Microsoft.Extensions.Configuration;

namespace CycleBike.Core.Common.Configuration;

public static class EnvironmentVariable
{
    private static IConfiguration? _configuration;

    /// <summary>
    /// Inicializa as variáveis de ambiente a partir da IConfiguration.
    /// </summary>
    /// <param name="configuration">A instância IConfiguration.</param>
    public static void InitializeEnvironments(this IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static SocketIOAdapterOptions SocketIoAdapter()
    {
        ArgumentNullException.ThrowIfNull(_configuration);
        try
        {
            return Validate(_configuration
                .GetSection(nameof(SocketIOAdapterOptions))
                .Get<SocketIOAdapterOptions>());
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException($"Failed to bind configurations {e.Message}");
        }
    }

    public static SignalROptions SignalR()
    {
        ArgumentNullException.ThrowIfNull(_configuration);
        try
        {
            return Validate(_configuration
                .GetSection(nameof(SignalROptions))
                .Get<SignalROptions>());
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException($"Failed to bind configurations {e.Message}");
        }
    }

    public static MongoDbOptions MongoDb()
    {
        ArgumentNullException.ThrowIfNull(_configuration);
        try
        {
            return Validate(_configuration
                .GetSection(nameof(MongoDbOptions))
                .Get<MongoDbOptions>());
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException($"Failed to bind configurations {e.Message}");
        }
    }

    public static RedisOptions Redis()
    {
        ArgumentNullException.ThrowIfNull(_configuration);
        try
        {
            return Validate(_configuration
                .GetSection(nameof(RedisOptions))
                .Get<RedisOptions>());
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentNullException($"Failed to bind configurations {e.Message}");
        }
    }

    private static T Validate<T>(T? environment) where T : class
    {
        ArgumentNullException.ThrowIfNull(typeof(T).Name, $"Configuration section '{typeof(T).Attributes}' is missing or could not be bound.");
        return environment!;
    }
}