using CycleBike.Adapters.Infrastructure.Modules.Pgsql.Context;
using CycleBike.Adapters.Infrastructure.Repositories;
using CycleBike.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
}