using System.Text.Json;
using CycleBike.Adapters.Infrastructure.Modules.MongoDB.Context;
using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Adapters.Infrastructure.Modules.Redis;
using CycleBike.Adapters.Infrastructure.Modules.Redis.Decorators;
using CycleBike.Adapters.Infrastructure.Modules.Redis.Policies;
using CycleBike.Adapters.Infrastructure.Modules.Wolverine.Policies;
using CycleBike.Adapters.Infrastructure.Repositories;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Interfaces;
using CycleBike.Core.Common.MessageBroker;
using CycleBike.Core.Common.Resources;
using CycleBike.Core.Domain.Interfaces;
using JasperFx.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
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

    public static IHostBuilder UseServiceBus(this IHostBuilder host, IHostEnvironment env, Action<WolverineOptions>? configure = null)
    {
        return host.UseWolverine(opts =>
        {
            configure?.Invoke(opts);
            var connection = new Uri(EnvironmentVariable.TryGetEnvironment<MessageBroker>(nameof(MessageBroker))
                .ConnectionString!);

            opts.UseRabbitMq(connection)
                .AutoProvision()
                .DeclareExchanges()
                .EnableWolverineControlQueues();
            
            opts.Policies.DisableConventionalLocalRouting();
            opts.Policies.UseDurableOutboxOnAllSendingEndpoints();
            opts.Policies.UseDurableInboxOnAllListeners();

            opts.RegisterTopicRouters();

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

            if (env.IsDevelopment())
            {
                opts.Durability.Mode = DurabilityMode.Solo;
            }
        });
    }

    public static void AddNoSqlLayer(this IServiceCollection services,
        Action<JsonSerializerOptions>? configureJsonOptions = null)
    {
        var redisConnectionString = EnvironmentVariable.TryGetEnvironment<RedisOptions>(nameof(RedisOptions)).ConnectionString;
        var mongoConnectionString = EnvironmentVariable.TryGetEnvironment<MongoDbOptions>(nameof(MongoDbOptions)).ConnectionString;
        
        var options = new JsonSerializerOptions();
        configureJsonOptions?.Invoke(options);
        var redisOptions = ConfigurationOptions.Parse(redisConnectionString);
        redisOptions.AbortOnConnectFail = true;
        redisOptions.ConnectTimeout = 5000;
        redisOptions.SyncTimeout = 5000;

        services.AddSingleton<IConnectionMultiplexer>(sp => 
            ConnectionMultiplexer.Connect(redisOptions));

        services.AddRedisCache();
        services.AddMongoDb(mongoConnectionString);
    }

    private static void AddRedisCache(this IServiceCollection services)
    {
        services.AddSingleton<ICacheAdapter>(sp =>
        {
            var redis = sp.GetRequiredService<IConnectionMultiplexer>();
            var logger = sp.GetRequiredService<ILogger<LoggingCacheDecorator>>();
            var adapter = new RedisCacheAdapter(redis);
            var localizer = sp.GetRequiredService<IStringLocalizer<ResourceMessages>>();
            return new LoggingCacheDecorator(adapter, logger, localizer);
        });
        
        services.AddSingleton<IDefaultCachePolicy>(sp =>
        {
            var cache = sp.GetRequiredService<ICacheAdapter>();
            return new DefaultCachePolicy(cache);
        });

        services.AddSingleton<ITokenCachePolicy>(sp =>
        {
            var cache = sp.GetRequiredService<ICacheAdapter>();
            return new TokenCachePolicy(cache);
        });

        services.AddSingleton<ICacheService, CacheService>();
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