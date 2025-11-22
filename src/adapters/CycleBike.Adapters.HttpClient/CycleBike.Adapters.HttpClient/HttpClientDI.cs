using CycleBike.Adapters.HttpClient.Interfaces;
using CycleBike.Adapters.HttpClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CycleBike.Adapters.HttpClient;

public static class HttpClientDI
{
    public static IServiceCollection AddHttpClientAdapter(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddSingleton<IAuthenticationOrchestrator, AuthenticationOrchestrator>();
        services.AddScoped<IHttpClientAdapter, Services.HttpClientAdapter>();
        
        return services;
    }
}