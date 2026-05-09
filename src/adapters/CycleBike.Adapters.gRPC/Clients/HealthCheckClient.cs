using Grpc.Net.Client;

namespace CycleBike.Adapters.gRPC.Clients;

public class HealthCheckClient(GrpcChannel channel): HealthCheckService.HealthCheckServiceClient(channel)
{
    
}