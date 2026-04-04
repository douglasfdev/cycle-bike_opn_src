namespace CycleBike.Core.Domain.Interfaces;

public interface IDefaultCachePolicy
{
    Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> fetchFunc, TimeSpan? expiry = null);
}