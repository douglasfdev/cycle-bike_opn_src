using Asp.Versioning;

namespace CycleBike.Adapters.WebApi.Configuration;

public static class ApiVersioning
{
    public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });

        return services;
    }
}