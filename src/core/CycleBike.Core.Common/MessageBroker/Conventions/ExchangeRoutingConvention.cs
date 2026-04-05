using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Interfaces;
using Wolverine;
using Wolverine.Configuration;
using Wolverine.RabbitMQ.Internal;
using Wolverine.Runtime;
using Wolverine.Runtime.Routing;

namespace CycleBike.Core.Common.MessageBroker.Conventions;

/// <summary>
/// Conven��o de routing do Wolverine que usa o ExchangeProvider para
/// resolver exchanges e routing keys dinamicamente baseado no tipo da mensagem.
/// </summary>
public class ExchangeRoutingConvention : IMessageRoutingConvention
{
    private readonly IExchangeProvider _exchangeProvider;

    public ExchangeRoutingConvention(IExchangeProvider exchangeProvider)
    {
        _exchangeProvider = exchangeProvider;
    }

    public void DiscoverListeners(IWolverineRuntime runtime, IReadOnlyList<Type> handledMessageTypes)
    {
        // N�o configuramos listeners aqui - isso � feito via ListenToExchangeQueues
    }

    public IEnumerable<Endpoint> DiscoverSenders(Type messageType, IWolverineRuntime runtime)
    {
        var rabbitTransport = runtime.Options.Transports.GetOrCreate<RabbitMqTransport>();
        var exchanges = EnvironmentVariable
            .TryGetEnvironment<Configuration.MessageBroker>(nameof(Configuration.MessageBroker)).Exchanges;

        foreach (var exchangeConfig in exchanges)
        {
            var exchange = rabbitTransport.Exchanges[exchangeConfig.Name.ToLowerInvariant()];
            
            // Para cada fila no exchange, cria um routing
            foreach (var queue in exchangeConfig.Queues)
            {
                var routing = exchange.Routings[queue.RoutingKey.ToLowerInvariant()];
                yield return routing;
            }
        }
    }
}

/// <summary>
/// Extens�es para configurar a conven��o de routing.
/// </summary>
public static class ExchangeRoutingConventionExtensions
{
    /// <summary>
    /// Adiciona a conven��o de routing baseada em ExchangeProvider.
    /// </summary>
    public static WolverineOptions UseExchangeRouting(this WolverineOptions options, IExchangeProvider exchangeProvider)
    {
        options.RouteWith(new ExchangeRoutingConvention(exchangeProvider));
        return options;
    }
}
