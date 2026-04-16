using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CycleBike.Adapters.WebApi.Configuration.Swagger;

public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "CycleBike API",
            Version = description.ApiVersion.ToString(),
            Description = "API para gerenciamento de aluguel de bicicletas elétricas."
        };

        if (description.IsDeprecated)
        {
            info.Description += " ** Esta versão está obsoleta. **";
        }

        return info;
    }
}