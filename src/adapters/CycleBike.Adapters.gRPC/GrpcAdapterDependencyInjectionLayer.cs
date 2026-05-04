using CycleBike.Adapters.gRPC.Services;

namespace CycleBike.Adapters.gRPC;

public static class GrpcAdapterDependencyInjectionLayer
{
    public static IServiceCollection AddGrpcClientAdapter(this IServiceCollection services)
    {
        services.AddGrpcClient<GrpcService>(o =>
        {
            o.Address = new Uri("http://localhost:8081");
        });

        return services;
    }
    
    public static IServiceCollection AddGrpcServerAdapter(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddScoped<GrpcService>();
        
        return services;
    }
}