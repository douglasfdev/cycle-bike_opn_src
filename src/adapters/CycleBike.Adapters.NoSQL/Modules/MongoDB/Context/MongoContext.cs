using CycleBike.Core.Common.Configuration;
using MongoDB.Driver;

namespace CycleBike.Adapters.NoSQL.Modules.MongoDB.Context;

public class MongoContext(IMongoClient client): IMongoContext
{
    public IMongoDatabase Connect()
        => client.GetDatabase(EnvironmentVariable.MongoDb().Database);

    public void Dispose()
    {
        client.Dispose();
    }
    public IClientSessionHandle? Session => client.StartSession();
}