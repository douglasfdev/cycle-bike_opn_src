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
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        })
        .AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "v{ApiVersion}";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}