using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CycleBike.Core.Domain;

public static class DomainDependencyInjectionLayer
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IOutboxRelayService, OutboxRelayServiceService>();
        services.AddScoped<IOutboxService, OutboxService>();
    }
}