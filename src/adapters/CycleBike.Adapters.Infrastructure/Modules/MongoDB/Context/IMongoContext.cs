using MongoDB.Driver;

namespace CycleBike.Adapters.Infrastructure.Modules.MongoDB.Context;

public interface IMongoContext : IDisposable
{
    IMongoDatabase Connect();
    IClientSessionHandle? Session { get; }
    bool HasSession { get; }
    Task<IClientSessionHandle> StartSessionAsync();
}