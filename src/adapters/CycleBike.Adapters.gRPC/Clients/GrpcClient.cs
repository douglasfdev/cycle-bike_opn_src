using Grpc.Net.Client;

namespace CycleBike.Adapters.gRPC.Clients;

public class GrpcClient(GrpcChannel channel) : BicycleService.BicycleServiceClient(channel)
{
    
}