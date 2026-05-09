using CycleBike.Adapters.gRPC;
using CycleBike.Adapters.gRPC.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

var grpcConfig = builder.Configuration.GetSection(GrpcAdapterConfiguration.SectionName).Get<GrpcAdapterConfiguration>();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(grpcConfig?.Port ?? 8081, configure =>
    {
        configure.Protocols = HttpProtocols.Http2;
    });
    options.Limits.MaxRequestBodySize = grpcConfig?.MaxMessageSize ?? 4 * 1024 * 1024;
    options.Limits.MaxRequestHeaderCount = 100;
    options.Limits.MaxRequestHeadersTotalSize = 32 * 1024;
});
builder.Services.Configure<GrpcAdapterConfiguration>(
    builder.Configuration.GetSection(GrpcAdapterConfiguration.SectionName));

builder.Services.AddGrpcAdapter();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");
app.MapGrpcService<GrpcService>();
app.MapGrpcService<HealthCheck>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");
if (grpcConfig?.EnableHealthCheck == true)
{
    app.MapHealthChecks("/health");
}

app.Run();