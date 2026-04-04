namespace CycleBike.Core.Domain.Interfaces;

public interface ICacheService
{
    public Task<T?> GetOrSetTokenAsync<T>(string serviceKey, Func<Task<(T value, TimeSpan expiry)>> fetchFunc) where T : class;

    public Task<T?> GetOrSetDataAsync<T>(string key, Func<Task<T>> fetchData, TimeSpan? expiry = null) where T : class;
}