using CycleBike.Core.Common.Configuration;
using MongoDB.Driver;

namespace CycleBike.Adapters.Infrastructure.Modules.MongoDB.Context;

public class MongoContext(IMongoClient client): IMongoContext
{
    public IMongoDatabase Connect()
        => client.GetDatabase(EnvironmentVariable.MongoDb().Database);

    public void Dispose()
    {
        client.Dispose();
    }
    public IClientSessionHandle? Session => client.StartSession();
    public async Task<IClientSessionHandle> StartSessionAsync()
    {
        return await client.StartSessionAsync();
    }
}