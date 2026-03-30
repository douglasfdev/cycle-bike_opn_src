namespace CycleBike.Core.Domain.Interfaces;

public interface IOutboxRelayService
{
    Task RelayAsync<T>(T message);
}