using System.Text.Json;
using System.Text.Json.Serialization;
using CycleBike.Adapters.Infrastructure.Modules.MongoDB.Context;
using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Adapters.Infrastructure.Modules.Redis;
using CycleBike.Adapters.Infrastructure.Modules.Wolverine.Policies;
using CycleBike.Adapters.Infrastructure.Repositories;
using CycleBike.Adapters.NoSQL.Interfaces;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Exchanges;
using CycleBike.Core.Domain.Interfaces;
using JasperFx.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using StackExchange.Redis;
using Wolverine;
using Wolverine.ErrorHandling;
using Wolverine.RabbitMQ;

namespace CycleBike.Adapters.Infrastructure;

public static class InfrastructureDependencyInjectionLayer
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        services.AddDbContext<DatabaseReadContext>(options =>
            options.UseNpgsql(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddDbContext<DatabaseWriteContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped(typeof(DatabaseGenericRepository<>));

        services.AddScoped(typeof(IDatabaseGenericRepository<>), typeof(DatabaseGenericRepository<>));
        services.AddScoped(typeof(IDatabaseWriteRepository<>), typeof(DatabaseWriteRepository<>));
        services.AddScoped(typeof(IDatabaseReadRepository<>), typeof(DatabaseReadRepository<>));
    }

    public static IHostBuilder AddServiceBus(this IHostBuilder host)
    {
        return host.UseWolverine(opts =>
        {
            opts.UseRabbitMq(new Uri(EnvironmentVariable.MessageBroker().ConnectionString!))
                .AutoProvision()
                .ConfigureListeners(listener =>
                {
                    listener.PreFetchCount(10);

                    listener.Sequential();
                })
                .DeclareExchanges();

            opts.Policies.OnException<HttpRequestException>()
                .Or<MongoException>()
                .RetryWithCooldown(500.Milliseconds(), 1.Seconds(), 5.Seconds());

            // opts.Policies.OnException<BusinessException>()
            //     .MoveToErrorQueue();
            
            opts.Policies.Add<IdempotencyPolicy>();

            opts.Policies.OnException<Exception>()
                .MoveToErrorQueue();

            // opts.Policies.AllLocalQueues(queue =>
            // {
            //     queue.MaximumParallelMessages(10);
            // });
        });
    }

    public static void AddNoSqlLayer(this IServiceCollection services,
        Action<JsonSerializerOptions>? configureJsonOptions = null)
    {
        var redisConnectionString = EnvironmentVariable.Redis().ConnectionString;
        var mongoConnectionString = EnvironmentVariable.MongoDb().ConnectionString;

        services.AddRedisCache(redisConnectionString, configureJsonOptions);
        services.AddMongoDb(mongoConnectionString);
    }

    private static void AddRedisCache(this IServiceCollection services, string connectionString,
        Action<JsonSerializerOptions>? configureJsonOptions = null)
    {
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
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            configureJsonOptions?.Invoke(jsonOptions);

            return jsonOptions;
        });

        services.AddSingleton<ICacheAdapter, RedisCacheAdapter>();
    }

    private static void AddMongoDb(this IServiceCollection services, string connectionStringKey)
    {
        services.AddSingleton<IMongoClient>(sp =>
        {
            var settings = MongoClientSettings.FromConnectionString(connectionStringKey);
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
            settings.ConnectTimeout = TimeSpan.FromSeconds(5);
            settings.SocketTimeout = TimeSpan.FromSeconds(5);

            return new MongoClient(settings);
        });

        services.AddScoped<IMongoContext, MongoContext>();
        services.AddScoped(typeof(INoSQLRepository<>), typeof(NoSqlRepository<>));
    }
}