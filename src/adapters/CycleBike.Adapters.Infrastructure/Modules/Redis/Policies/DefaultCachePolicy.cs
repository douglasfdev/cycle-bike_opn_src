using CycleBike.Core.Domain.Interfaces;

namespace CycleBike.Adapters.Infrastructure.Modules.Redis.Policies;

public class DefaultCachePolicy(ICacheAdapter cacheAdapter) : IDefaultCachePolicy
{
    public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> fetchFunc, TimeSpan? expiry = null)
    {
        var cached = await cacheAdapter.GetAsync<T>(key);
        if (cached != null) return cached;

        var value = await fetchFunc();
        await cacheAdapter.SetAsync(key, value, expiry);
        return value;
    }
}