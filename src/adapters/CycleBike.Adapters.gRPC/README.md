# CycleBike gRPC Adapter

Este adaptador implementa uma interface gRPC para o sistema CycleBike, seguindo os princípios de arquitetura hexagonal e CQRS.

## Estrutura

- **Protos**: Defineções dos serviços e mensagens gRPC
- **Services**: Implementações dos serviços gRPC
- **GrpcDependencyInjectionLayer**: Configuração de injeção de dependência
- **Program.cs**: Ponto de entrada do serviço gRPC

## Execução

### Serviço Independente
```bash
dotnet run --project src/adapters/CycleBike.Adapters.gRPC
```

Integração com outros serviços:
```bash
dotnet build src/adapters/CycleBike.Adapters.gRPC.csproj
dotnet add reference src/adapters/CycleBike.Adapters.gRPC/CycleBike.Adapters.gRPC.csproj
dotnet add src/adapters/CycleBike.Adapters.gRPC/CycleBike.Adapters.gRPC.csproj
```

## Endpoints

- gRPC Server: `localhost:8081`
- Health Check: `localhost:8081` (disponibilizado pelo gRPC Health Check)

## Exemplo de Uso

### Cliente C#
```csharp
var channel = GrpcChannel.ForAddress("http://localhost:8081");
var client = new BicycleService.BicycleServiceClient(channel);

// Criar bicicleta
var createRequest = new CreateBicycleRequest
{
    Name = "Mountain Bike",
    Price = 1200.50,
    Description = "Bicicleta de montanha"
};
var createResponse = await client.CreateBicycleAsync(createRequest);

// Buscar bicicleta
var getRequest = new GetBicycleRequest { Id = createResponse.Id };
var getResponse = await client.GetBicycleAsync(getRequest);
```

## Integração

Para integrar este adaptador com outros serviços do CycleBike:

1. Adicione a referência ao projeto
2. Use `GrpcAdapterDependencyInjectionLayer.AddGrpcClientAdapter()` na configuração do DI
3. Utilize o canal gRPC para comunicação entre serviços

## Boas Práticas

- Todo o gRPC é totalmente desacoplado do core
- Utiliza os handlers existentes de CQRS
- Segue os padrões de arquitetura hexagonal
- Mensagens são mapeadas entre gRPC e entidades do domínio