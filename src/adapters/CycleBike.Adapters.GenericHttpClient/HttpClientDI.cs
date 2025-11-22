using CycleBike.Adapters.GenericHttpClient.Abstractions;
using CycleBike.Adapters.GenericHttpClient.Interfaces;
using CycleBike.Adapters.GenericHttpClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CycleBike.Adapters.GenericHttpClient;

public static class HttpClientDI
{
    public static IServiceCollection AddHttpClientAdapter(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddSingleton<IAuthenticationOrchestrator, AuthenticationOrchestrator>();
        services.AddSingleton<BaseHttpClientFactory>();
        services.AddScoped<IHttpClientAdapter, HttpClientAdapter>();
        
        return services;
    }
}