namespace CycleBike.Core.Domain.Interfaces;

public interface IConsumerStrategy<T> where T : class
{
    Task HandleAsync(T message);
}