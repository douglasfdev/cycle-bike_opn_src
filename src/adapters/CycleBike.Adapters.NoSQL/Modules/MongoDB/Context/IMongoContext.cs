using MongoDB.Driver;

namespace CycleBike.Adapters.NoSQL.Modules.MongoDB.Context;

public interface IMongoContext : IDisposable
{
    IMongoDatabase Connect();
    IClientSessionHandle? Session { get; }
}