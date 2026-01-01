using MongoDB.Driver;

namespace CycleBike.Adapters.NoSQL.Interfaces;

public interface IMongoContext
{
    IMongoDatabase Connect();
}