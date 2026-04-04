using CycleBike.Core.Domain.Interfaces;

namespace CycleBike.Adapters.Infrastructure.Modules.Redis.Policies;

public class TokenCachePolicy(ICacheAdapter CacheService)
    : ITokenCachePolicy
{
    public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<(T value, TimeSpan expiry)>> fetchFunc) where T : class
    {
        var cached = await CacheService.GetAsync<T>(key);
        if (cached != null) return cached;

        var token = await fetchFunc();
        await CacheService.SetAsync(key, token.value, token.expiry);
        return token.value;
    }
}