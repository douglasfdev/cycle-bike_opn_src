using Microsoft.Extensions.Configuration;

namespace CycleBike.Core.Common.Configuration;

public static class EnvironmentVariable
{
    public static SocketIOAdapterOptions SocketIoAdapterOptions;
    public static SignalROptions SignalROptions;
    
    /// <summary>
    /// Obtém uma seção de configuração completa e a mapeia para um objeto de tipo T.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto (record, class string, bool, etc) a ser mapeado.</typeparam>
    /// <param name="configuration">A instância IConfiguration.</param>
    /// <param name="key">A chave da seção de configuração, ex: "SocketIOAdapterOptions".</param>
    /// <returns>Uma instância de T com os valores da configuração.</returns>
    /// <exception cref="InvalidOperationException">Lançada se a seção não for encontrada ou o binding falhar.</exception>
    public static void InitializeEnvironments(this IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        try
        {
            SocketIoAdapterOptions = configuration
                .GetSection(nameof(SocketIoAdapterOptions))
                .Get<SocketIOAdapterOptions>() 
                    ?? throw new ArgumentNullException($"Failed to bind configuration of type SocketIOAdapterOptions for key: {nameof(SocketIoAdapterOptions)}");
            
            SignalROptions = configuration
                .GetSection(nameof(SignalROptions))
                .Get<SignalROptions>() 
                    ?? throw new ArgumentNullException($"Failed to bind configuration of type SignalROptions for key: {nameof(SignalROptions)}");
        }
        catch(Exception e)
        {
            throw new ArgumentNullException($"Failed to bind configurations {e.Message}");
        }
    }
}