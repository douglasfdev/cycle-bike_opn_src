using CycleBike.Adapters.HttpClient.Models;

namespace CycleBike.Adapters.HttpClient.Interfaces;

public interface IAuthenticationOrchestrator
{
    Task ApplyAuthenticationAsync(
        HttpRequestMessage request,
        AuthenticationConfig config,
        CancellationToken cancellationToken = default);
}