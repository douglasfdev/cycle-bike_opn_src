namespace CycleBike.Core.Common.Interfaces;

public interface IConsumer<T> where T : class
{
    public Task Handle(T message);
}