using CycleBike.Adapters.gRPC.Examples;

Console.WriteLine("Starting gRPC Client Example...");

await GrpcClientExample.RunExampleAsync();

Console.WriteLine("\nExample completed. Press any key to exit...");
Console.ReadKey();