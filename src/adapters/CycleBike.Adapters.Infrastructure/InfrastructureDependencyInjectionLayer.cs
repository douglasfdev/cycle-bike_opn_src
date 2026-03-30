using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Adapters.Infrastructure.Repositories;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Exchanges;
using CycleBike.Core.Domain.Interfaces;
using JasperFx.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
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

            opts.Policies.OnException<Exception>()
                .MoveToErrorQueue();
                
            // opts.Policies.AllLocalQueues(queue =>
            // {
            //     queue.MaximumParallelMessages(10);
            // });
        });
    }
}