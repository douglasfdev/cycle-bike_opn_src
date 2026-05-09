using CycleBike.Adapters.gRPC.Clients;
using Grpc.Net.Client;

namespace CycleBike.Adapters.gRPC.Examples;

public static class GrpcClientExample
{
    public static async Task RunExampleAsync()
    {
        // Criar canal gRPC
        using var channel = GrpcChannel.ForAddress("http://localhost:8081");
        var client = new HealthCheckClient(channel);

        Console.WriteLine("=== CycleBike gRPC Client Example ===\n");

        try
        {
            // Exemplo 1: Criar bicicleta
            Console.WriteLine("1. Creating bicycle...");
            var createRequest = new HealthCheckRequest
            {
                ServiceName = "Redis"
            };

            var createResponse = await client.CheckAsync(createRequest);
            Console.WriteLine($"   Created bicycle with ID: {createResponse.Message}");
            Console.WriteLine($"   Name: {createResponse.Status}");
            Console.WriteLine($"   Price: ${createResponse.Timestamp}");
            Console.WriteLine($"   Description: {createResponse.Version}");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}