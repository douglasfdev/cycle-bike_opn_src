using Asp.Versioning.ApiExplorer;
using CycleBike.Adapters.GraphQL.Configuration;
using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Adapters.WebApi.Middlewares;
using CycleBike.Core.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.InitializeEnvironments();
builder.Services.AddMiddlewares(builder.Configuration);
builder.Host.AddServiceBus();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.MapControllers();
app.MapHub<NotificationsHub>("/realtime");
app.MapGraphQLAdapter();
app.UseHttpsRedirection();

app.Run();