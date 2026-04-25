using CycleBike.Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CycleBike.Core.Domain.Logging;

public static class LoggingDependencyInjectionLayer
{
    public static IServiceCollection AddLoggingInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<LogEntryProcessor>();
        
        return services;
    }
}