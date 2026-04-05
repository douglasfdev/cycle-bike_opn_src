namespace CycleBike.Core.Domain.Interfaces;

public interface IMessagePublisher
{
    Task PublishAsync<T>(T message, string process, string routingKey) where T : class;
}