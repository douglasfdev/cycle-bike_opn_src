using Grpc.Net.Client;

namespace CycleBike.Adapters.gRPC.Examples;

public class GrpcClientExample
{
    public static async Task RunExampleAsync()
    {
        // Criar canal gRPC
        using var channel = GrpcChannel.ForAddress("http://localhost:8081");
        var client = new GrpcClient(channel);

        Console.WriteLine("=== CycleBike gRPC Client Example ===\n");

        try
        {
            // Exemplo 1: Criar bicicleta
            Console.WriteLine("1. Creating bicycle...");
            var createRequest = new CreateBicycleRequest
            {
                Name = "Mountain Bike Elite",
                Price = 2500.99,
                Description = "Professional mountain bicycle with advanced suspension"
            };

            var createResponse = await client.CreateBicycleAsync(createRequest);
            Console.WriteLine($"   Created bicycle with ID: {createResponse.Id}");
            Console.WriteLine($"   Name: {createResponse.Name}");
            Console.WriteLine($"   Price: ${createResponse.Price}");
            Console.WriteLine($"   Description: {createResponse.Description}");
            Console.WriteLine();

            // Exemplo 2: Obter bicicleta
            Console.WriteLine("2. Getting bicycle by ID...");
            var getRequest = new GetBicycleRequest { Id = createResponse.Id };
            var getResponse = await client.GetBicycleAsync(getRequest);
            
            Console.WriteLine($"   ID: {getResponse.Id}");
            Console.WriteLine($"   Name: {getResponse.Name}");
            Console.WriteLine($"   Price: ${getResponse.Price}");
            Console.WriteLine($"   Status: {getResponse.Status}");
            Console.WriteLine($"   Version: {getResponse.Version}");
            Console.WriteLine();

            // Exemplo 3: Listar bicicletas
            Console.WriteLine("3. Listing bicycles...");
            var listRequest = new ListBicyclesRequest { Page = 1, Size = 10 };
            var listResponse = await client.ListBicyclesAsync(listRequest);
            
            Console.WriteLine($"   Total bicycles: {listResponse.Total}");
            Console.WriteLine("   Bicycles:");
            
            foreach (var bicycle in listResponse.Bicycles)
            {
                Console.WriteLine($"     - {bicycle.Name} (${bicycle.Price}) - {bicycle.Status}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}