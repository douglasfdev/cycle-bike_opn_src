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
    
    public static T TryGetEnvironment<T>(string key, Func<T, T>? resolver = null)
    {
        ArgumentNullException.ThrowIfNull(_configuration);

        var section = _configuration.GetSection(key);
        T? result;

        result = section.Get<T>();

        if (result == null)
            throw new Exception($"Configuração '{key}' não encontrada.");

        return resolver != null ? resolver(result) : result;
    }
}