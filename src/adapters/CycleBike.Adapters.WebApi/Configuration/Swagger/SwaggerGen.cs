using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CycleBike.Adapters.WebApi.Configuration.Swagger;

public static class SwaggerGen
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        
        services.AddSwaggerGen();

        return services;
    }
}