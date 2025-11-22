using System.Text.Json;
using CycleBike.Adapters.NoSQLContext.Interfaces;
using StackExchange.Redis;

namespace CycleBike.Adapters.NoSQLContext.Modules.Redis;

public sealed class RedisCacheAdapter(
    IConnectionMultiplexer connectionMultiplexer,
    JsonSerializerOptions? jsonOptions = null) : ICacheAdapter
{
    private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
    private readonly JsonSerializerOptions _jsonOptions = jsonOptions ?? new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        var value = await _database.StringGetAsync(key);
        
        return value.IsNullOrEmpty 
            ? default 
            : JsonSerializer.Deserialize<T>((string)value!, _jsonOptions);
    }

    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(value);

        var serializedValue = JsonSerializer.Serialize(value, _jsonOptions);
        
        return await _database.StringSetAsync((RedisKey)key, (RedisValue)serializedValue, expiration, When.Always, CommandFlags.None);
    }

    public async Task<bool> DeleteAsync(string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        
        return await _database.KeyExistsAsync(key);
    }

    public async Task<bool> SetMultipleAsync<T>(IDictionary<string, T> keyValuePairs, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(keyValuePairs);

        var batch = _database.CreateBatch();
        var tasks = new List<Task<bool>>();

        foreach (var kvp in keyValuePairs)
        {
            var serializedValue = JsonSerializer.Serialize(kvp.Value, _jsonOptions);
            tasks.Add(batch.StringSetAsync((RedisKey)kvp.Key, (RedisValue)serializedValue, expiration, When.Always, CommandFlags.None));
        }

        batch.Execute();
        var results = await Task.WhenAll(tasks);
        
        return results.All(r => r);
    }

    public async Task<IDictionary<string, T?>> GetMultipleAsync<T>(IEnumerable<string> keys, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(keys);

        var keyArray = keys.ToArray();
        var redisKeys = keyArray.Select(k => (RedisKey)k).ToArray();
        var values = await _database.StringGetAsync(redisKeys);

        var result = new Dictionary<string, T?>();
        
        for (int i = 0; i < keyArray.Length; i++)
        {
            result[keyArray[i]] = values[i].IsNullOrEmpty 
                ? default 
                : JsonSerializer.Deserialize<T>((string)values[i]!, _jsonOptions);
        }

        return result;
    }
}