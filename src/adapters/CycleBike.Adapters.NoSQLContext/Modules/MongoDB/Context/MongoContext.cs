using CycleBike.Adapters.NoSQLContext.Interfaces;
using CycleBike.Core.Common.Configuration;
using MongoDB.Driver;

namespace CycleBike.Adapters.NoSQLContext.Modules.MongoDB.Context;

public class MongoContext(IMongoClient client): IMongoContext
{
    public IMongoDatabase Connect()
        => client.GetDatabase(EnvironmentVariable.MongoDb().Database);
}