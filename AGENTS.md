# CycleBike AI Agent Guidelines

## Architecture Overview
This is a .NET 10 microservices application following **Hexagonal Architecture (Ports & Adapters)** with **CQRS** and **Event Sourcing**.

- **Core Layer**: `src/core/`
  - `CycleBike.Core.Domain`: Business logic, entities, domain services, events
  - `Cycle.Core.Application`: Application services, command/query handlers, schemas
- **Adapters Layer**: `src/adapters/`
  - `WebApi`: REST API controllers
  - `GraphQL`: GraphQL API using HotChocolate, fully decoupled from core
  - `Infrastructure`: EF Core (PostgreSQL read/write contexts), MongoDB, Redis, Wolverine messaging
  - `NotificationWorker`: Background worker for notifications via SignalR
  - `OutboxRelay`: Consumer for outbox messages via RabbitMQ
  - Other adapters: Socket adapters, HTTP clients

## Key Patterns & Conventions

### CQRS Implementation
- **Commands**: Records inheriting `Message` and `ICommand`, e.g., `ProductCommands.CreateProduct`
- **Queries**: Records implementing `IQuery`, e.g., `ProductQueries.GetProductById`
- **Handlers**: Inherit from `CommandHandler<TCommand, TResult>` or `QueryHandler<TQuery, TResult>`
  - Use primary constructors for dependency injection
  - Return `ApiResult<T>` with success/failure status
  - Multiple handlers per command allowed (e.g., `CreateProductHandler` + `CreateProductCacheHandler`)

### Dependency Injection
- Core layers register services in `*DependencyInjectionLayer.cs` files
- Adapters inject and use core ports (interfaces like `ICommandHandler`, `IQueryHandler`)

### Messaging & Events
- **Wolverine**: For RabbitMQ messaging, event sourcing, outbox pattern
- **Outbox Pattern**: Messages stored in database before publishing to RabbitMQ
- Exchanges: Auto-provisioned, e.g., `Process.ProductProcess.ProductRegistration`
- Consumers: Classes like `ProductRequestConsumer` in workers

### Data Access
- **CQRS Databases**: Separate read/write PostgreSQL contexts (`DatabaseReadContext`, `DatabaseWriteContext`)
- **NoSQL**: MongoDB for event storage, Redis for caching
- Repositories: Generic, read, write interfaces (`IDatabaseGenericRepository<T>`)

### GraphQL Integration
- Fully decoupled adapter reusing core handlers
- Endpoints: `/graphql` (IDE), `/graphql/schema`
- Types: `ObjectType<T>`, Input types, mutations/queries/subscriptions
- Real-time: WebSocket subscriptions via SignalR

## Development Workflow

### Building & Running
```bash
# Full stack with Docker
docker-compose up --build

# Individual services
dotnet build CycleBike.sln
dotnet run --project src/adapters/CycleBike.Adapters.WebApi

# Workers
dotnet run --project src/adapters/CycleBike.Adapters.NotificationWorker
dotnet run --project src/adapters/CycleBike.Adapters.OutboxRelay
```

### Testing
- **Framework**: xUnit
- **Structure**: `tests/IntegratedTests/`, `tests/UnitTest/`
```bash
dotnet test
```

### Debugging
- WebApi: `http://localhost:8080` (Docker) or `http://localhost:5000` (direct)
- GraphQL IDE: `http://localhost:8080/graphql`
- RabbitMQ Management: `http://localhost:15672`
- MongoDB: `localhost:27017`
- Redis: `localhost:6379`

## Adding New Features

### New Module (e.g., Customer)
1. **Domain**: Add entities, requests, services in `CycleBike.Core.Domain/Modules/`
2. **Application**: Add commands/queries in `Schemas/`, handlers in `Modules/`
3. **Adapters**:
   - WebApi: Controller in `Controllers/V1/`
   - GraphQL: Types, queries/mutations in respective folders, register in `GraphQLExtensions.cs`
   - Infrastructure: Repositories if needed

### New Adapter
- Create new project in `src/adapters/`
- Implement ports from core
- Register in appropriate DI layer

## Code Examples

### Command Handler
```csharp
public class CreateProductHandler(IProductService service)
    : CommandHandler<ProductCommands.CreateProduct, Product>
{
    public override async Task<ApiResult<Product>> HandleAsync(
        ProductCommands.CreateProduct command, CancellationToken cancellationToken)
    {
        var product = new Product(command.Name, command.Price, command.Description);
        var created = await service.CreateAsync(product, cancellationToken);
        return created 
            ? ApiResult<Product>.Success("Created", product, 201)
            : ApiResult<Product>.Failure("Failed");
    }
}
```

### GraphQL Query
```csharp
[ExtendObjectType("Query")]
public class ProductQuery
{
    public async Task<ApiResult_Product> GetProductById(
        [Service] IQueryHandler<ProductQueries.GetProductById, Product> handler,
        Ulid id, CancellationToken cancellationToken)
    {
        var query = new ProductQueries.GetProductById(id);
        var result = await handler.HandleAsync(query, cancellationToken);
        return new ApiResult_Product(result);
    }
}
```

## Key Files
- `docker-compose.yaml`: Infrastructure setup
- `docs/graphql-usage.md`: GraphQL guide
- `src/core/Cycle.Core.Application/ApplicationDependencyInjectionLayer.cs`: Handler registrations
- `src/adapters/CycleBike.Adapters.WebApi/Program.cs`: WebApi entry point
- `src/adapters/CycleBike.Adapters.Infrastructure/InfrastructureDependencyInjectionLayer.cs`: Data & messaging setup</content>
<parameter name="filePath">C:\Users\User\RiderProjects\CycleBike\AGENTS.md
