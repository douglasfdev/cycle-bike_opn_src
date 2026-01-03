using MongoDB.Driver;

namespace CycleBike.Adapters.NoSQL.Modules.MongoDB.Context;

public interface IMongoContext
{
    IMongoDatabase Connect();
}