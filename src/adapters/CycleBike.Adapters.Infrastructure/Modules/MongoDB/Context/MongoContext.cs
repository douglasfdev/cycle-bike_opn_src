using CycleBike.Core.Common.Configuration;
using MongoDB.Driver;

namespace CycleBike.Adapters.Infrastructure.Modules.MongoDB.Context;

public class MongoContext(IMongoClient client): IMongoContext
{
    private IClientSessionHandle? _session;

    public IMongoDatabase Connect()
        => client.GetDatabase(EnvironmentVariable
            .TryGetEnvironment<MongoDbOptions>(nameof(MongoDbOptions)).Database);

    public IClientSessionHandle Session
        => _session ??= client.StartSession();

    public bool HasSession => _session != null;

    public async Task<IClientSessionHandle> StartSessionAsync()
        => _session ??= await client.StartSessionAsync();

    public void Dispose()
    {
        _session?.Dispose();
    }
}