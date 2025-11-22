using MongoDB.Driver;

namespace CycleBike.Adapters.NoSQLContext.Interfaces;

public interface IMongoContext
{
    IMongoDatabase Connect();
}