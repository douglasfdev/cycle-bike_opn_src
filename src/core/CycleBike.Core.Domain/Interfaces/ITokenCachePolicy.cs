namespace CycleBike.Core.Domain.Interfaces;

public interface ITokenCachePolicy
{
    Task<T?> GetOrSetAsync<T>(string key, Func<Task<(T value, TimeSpan expiry)>> fetchFunc) where T : class;
}