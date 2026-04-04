using CycleBike.Core.Domain.Interfaces;

namespace CycleBike.Adapters.Infrastructure.Modules.Redis;

public class CacheService(ITokenCachePolicy TokenPolicy, IDefaultCachePolicy DefaultPolicy) : ICacheService
{
    public async Task<T?> GetOrSetTokenAsync<T>(string serviceKey, Func<Task<(T value, TimeSpan expiry)>> fetchFunc) where T : class
    {
        var key = $"hubapi:token:{serviceKey}";
        return await TokenPolicy.GetOrSetAsync(key, fetchFunc);
    }

    public async Task<T?> GetOrSetDataAsync<T>(string key, Func<Task<T>> fetchData, TimeSpan? expiry = null) where T : class
    {
        return await DefaultPolicy.GetOrSetAsync(key, fetchData, expiry);
    }
}