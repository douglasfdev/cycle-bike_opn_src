using CycleBike.Adapters.GenericHttpClient.Models;

namespace CycleBike.Adapters.GenericHttpClient.Interfaces;

public interface IAuthenticationOrchestrator
{
    Task ApplyAuthenticationAsync(
        HttpRequestMessage request,
        AuthenticationConfig config,
        CancellationToken cancellationToken = default);
}