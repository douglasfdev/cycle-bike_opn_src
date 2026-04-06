using CycleBike.Core.Common.Interfaces;
using CycleBike.Core.Common.MessageBroker.Providers;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Requests;
using CycleBike.Core.Domain.Services;
using CycleBike.Core.Domain.Services.Events;
using Microsoft.Extensions.DependencyInjection;

namespace CycleBike.Core.Domain;

public static class DomainDependencyInjectionLayer
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IOutboxRelayService, OutboxRelayServiceService>();
        services.AddScoped<IOutboxService, OutboxService>();
        services.AddScoped<IMessagePublisher, MessagePublisher>();
        services.AddSingleton<IExchangeProvider, ExchangeProvider>();
        services.AddScoped(typeof(IConsumerStrategy<>), typeof(RegisterProductEvent<>));
        services.AddScoped<IProductService, ProductService>();
    }
}