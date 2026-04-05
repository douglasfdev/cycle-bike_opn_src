using CycleBike.Core.Common.Interfaces;
using CycleBike.Core.Domain.Interfaces;
using Wolverine;

namespace CycleBike.Core.Domain.Services;

public class MessagePublisher(IMessageBus bus) : IMessagePublisher
{
    public async Task PublishAsync<T>(T @event, string process, string routingKey) where T : class
    {
        await bus.SendAsync(@event);
        Console.WriteLine($"[Publisher] sent!");
    }
}