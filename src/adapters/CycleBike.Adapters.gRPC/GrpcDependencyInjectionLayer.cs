using CycleBike.Adapters.gRPC.Services;

namespace CycleBike.Adapters.gRPC;

public static class GrpcDependencyInjectionLayer
{
    public static IServiceCollection AddGrpcAdapter(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddScoped<GrpcService>();
        
        return services;
    }
}