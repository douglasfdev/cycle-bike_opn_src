using CycleBike.Core.Common.Resources;
using CycleBike.Core.Domain.Interfaces;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CycleBike.Adapters.Infrastructure.Modules.Redis.Decorators;

public class LoggingCacheDecorator(
    ICacheAdapter Inner,
    ILogger<LoggingCacheDecorator> Logger,
    IStringLocalizer<ResourceMessages> _stringLocalizer) : ICacheAdapter
{

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(_stringLocalizer[ResourceMessages.INF00001, key]);
        return await Inner.GetAsync<T>(key, cancellationToken);
    }

    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(_stringLocalizer[ResourceMessages.INF00003, key]);
        return await Inner.SetAsync(key, value, expiration, cancellationToken);
    }

    public async Task<bool> DeleteAsync(string key, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(_stringLocalizer[ResourceMessages.INF00002, key]);
        return await Inner.DeleteAsync(key, cancellationToken);
    }

    public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(_stringLocalizer[ResourceMessages.INF00004, key]);
        return await Inner.ExistsAsync(key, cancellationToken);
    }

    public async Task<bool> SetMultipleAsync<T>(IDictionary<string, T> keyValuePairs, TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
    {
        Logger.LogInformation(_stringLocalizer[ResourceMessages.INF00005, keyValuePairs.Count]);
        return await Inner.SetMultipleAsync(keyValuePairs, expiration, cancellationToken);
    }

    public async Task<IDictionary<string, T?>> GetMultipleAsync<T>(IEnumerable<string> keys, CancellationToken cancellationToken = default)
    {
        var enumerable = keys.ToArray();
        Logger.LogInformation(_stringLocalizer[ResourceMessages.INF00006, enumerable.Count()]);
        return await Inner.GetMultipleAsync<T>(enumerable, cancellationToken);
    }
}