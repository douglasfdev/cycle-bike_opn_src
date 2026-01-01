using System.Text.Json;
using CycleBike.Adapters.NoSQL.Interfaces;
using CycleBike.Adapters.NoSQL.Modules.MongoDB.Context;
using CycleBike.Adapters.NoSQL.Modules.Redis;
using CycleBike.Adapters.NoSQL.Modules.Repositories;
using CycleBike.Core.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using StackExchange.Redis;

namespace CycleBike.Adapters.NoSQL;

public static class NoSQLDependcyInjectionLayer
{
    public static IServiceCollection AddNoSqlLayer(this IServiceCollection services,
        IConfiguration configuration,
        Action<JsonSerializerOptions>? configureJsonOptions = null)
    {
        var redisConnectionString = EnvironmentVariable.Redis().ConnectionString;
        var mongoConnectionString = EnvironmentVariable.MongoDb().ConnectionString;
        
        services.AddRedisCache(redisConnectionString, configureJsonOptions);
        services.AddMongoDb(configuration, mongoConnectionString);

        return services;
    }
    
    private static IServiceCollection AddRedisCache(
        this IServiceCollection services,
        string connectionString,
        Action<JsonSerializerOptions>? configureJsonOptions = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

        services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var options = ConfigurationOptions.Parse(connectionString);
            options.AbortOnConnectFail = false;
            options.ConnectTimeout = 5000;
            options.SyncTimeout = 5000;
            options.AsyncTimeout = 5000;
            
            return ConnectionMultiplexer.Connect(options);
        });

        services.AddSingleton(sp =>
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            configureJsonOptions?.Invoke(jsonOptions);
            
            return jsonOptions;
        });

        services.AddSingleton<ICacheAdapter, RedisCacheAdapter>();

        return services;
    }
    
    private static IServiceCollection AddMongoDb(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringKey)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionStringKey);

        services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = MongoClientSettings.FromConnectionString(connectionStringKey);
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
            settings.ConnectTimeout = TimeSpan.FromSeconds(5);
            settings.SocketTimeout = TimeSpan.FromSeconds(5);
            
            return new MongoClient(settings);
        });

        services.AddScoped<MongoContext>();
        services.AddScoped(typeof(IMongoDbRepository<>), typeof(MongoDbRepository<>));

        return services;
    }
}