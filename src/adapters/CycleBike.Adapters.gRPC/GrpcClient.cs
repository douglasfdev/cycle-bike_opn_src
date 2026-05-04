using Grpc.Net.Client;

namespace CycleBike.Adapters.gRPC;

public class GrpcClient(GrpcChannel channel) : BicycleService.BicycleServiceClient(channel)
{
    
}