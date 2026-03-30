using System.Text.Json.Serialization;
using CycleBike.Adapters.Infrastructure;
using CycleBike.Core.Domain;
using Wolverine;

namespace CycleBike.Adapters.OutboxRelay.Middlewares;

public static class DependencyInjectionLayer
{
    public static void AddMiddlewares(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain();
        services.AddNoSqlLayer(opt =>
        {
            opt.PropertyNameCaseInsensitive = true;
            opt.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        });
        services.AddInfrastructure(configuration);
    }
}