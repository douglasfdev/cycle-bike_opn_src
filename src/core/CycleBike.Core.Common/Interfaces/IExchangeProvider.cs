using CycleBike.Core.Common.MessageBroker;

namespace CycleBike.Core.Common.Interfaces;

public interface IExchangeProvider
{
    ExchangeResource GetExchange(string process, string routingKey);
}