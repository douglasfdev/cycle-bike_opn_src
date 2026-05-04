using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CycleBike.Core.Domain.Logging;

public static class LoggingDependencyInjectionLayer
{
    public static IServiceCollection AddLoggingInfrastructure(this IServiceCollection services, string applicationName)
    {
        services.AddSingleton<ILogEntryProcessor, LogEntryProcessor>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<LogEntryProcessor>>();
            var repository = sp.GetRequiredService<IDatabaseGenericRepository<LogEntry>>();
            return new LogEntryProcessor(logger, repository, applicationName);
        });
        
        return services;
    }
}