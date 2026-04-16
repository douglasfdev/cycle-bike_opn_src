# GraphQL Usage Guide

## Overview

O GraphQL foi implementado como um **adapter** seguindo a arquitetura Hexagonal. O adapter está totalmente desacoplado do core da aplicação e reutiliza os mesmos ports (ICommandHandler, IQueryHandler) que o WebApi REST.

## Endpoints

Após rodar a aplicação, o GraphQL estará disponível em:

- **GraphQL Endpoint**: `http://localhost:5000/graphql` (ou a porta configurada)
- **GraphQL IDE (Banana Cake Pop)**: `http://localhost:5000/graphql` (acessível via browser)
- **Schema SDL**: `http://localhost:5000/graphql/schema`

## Arquitetura

```
┌─────────────────────────────────────────────────────────────┐
│                    CycleBike.Adapters.GraphQL               │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐       │
│  │   Queries    │  │  Mutations   │  │ Subscriptions│       │
│  └──────┬───────┘  └──────┬───────┘  └──────┬───────┘       │
│         │                  │                │               │
│         └──────────────────┴────────────────┘               │
│                            │                                │
│                    GraphQL Schema (HotChocolate)            │
└────────────────────────────┼────────────────────────────────┘
                             │
                    ┌────────▼────────┐
                    │  IQueryHandler  │  (Port)
                    │ ICommandHandler │
                    └────────┬────────┘
                             │
┌────────────────────────────┼─────────────────────────────────┐
│        Cycle.Core.Application                                │
│  ┌──────────────┐  ┌───────────────┐  ┌──────────────┐       │
│  │ ProductQuery │  │ProductMutation│  │ Domain Logic │       │
│  │   Handler    │  │   Handler     │  │              │       │
│  └──────────────┘  └───────────────┘  └──────────────┘       │
└──────────────────────────────────────────────────────────────┘
```

## Exemplos de Uso

### 1. Queries (Leitura)

#### Buscar produto por ID
```graphql
query GetProductById {
  getProductById(id: "01HJZQ...") {
    isSuccess
    data {
      id
      name
      price
      description
      isDeleted
      createdAt
      updatedAt
    }
    message
    statusCode
  }
}
```

#### Listar todos os produtos (paginado)
```graphql
query GetAllProducts {
  getAllProducts(page: 1, pageSize: 10, filters: {
    name: "Bike"
    minPrice: 100
    maxPrice: 5000
  }) {
    isSuccess
    data {
      items {
        id
        name
        price
        description
      }
      totalItems
      pageNumber
      pageSize
    }
    message
    statusCode
  }
}
```

#### Buscar mensagens pendentes (Outbox)
```graphql
query GetPendingMessages {
  getPendingMessages {
    isSuccess
    data {
      id
      messageType
      sent
      sentAt
      attempts
      status
      createdAt
    }
    message
    statusCode
  }
}
```

### 2. Mutations (Escrita)

#### Criar produto
```graphql
mutation CreateProduct {
  createProduct(input: {
    name: "Bike Elétrica X"
    price: 2999.99
    description: "Bike elétrica com motor 500W"
  }) {
    isSuccess
    data {
      id
      name
      price
      description
    }
    message
    statusCode
  }
}
```

#### Atualizar produto
```graphql
mutation UpdateProduct {
  updateProduct(input: {
    id: "01HJZQ..."
    name: "Bike Elétrica X Pro"
    price: 3499.99
    description: "Bike elétrica com motor 750W"
  }) {
    isSuccess
    data {
      id
      name
      price
      description
    }
    message
    statusCode
  }
}
```

#### Deletar produto
```graphql
mutation DeleteProduct {
  deleteProduct(id: "01HJZQ...") {
    isSuccess
    data {
      id
      isDeleted
    }
    message
    statusCode
  }
}
```

#### Publicar produto (enviar para RabbitMQ)
```graphql
mutation PublishProduct {
  publishProduct(input: {
    name: "Bike Elétrica X"
    price: 2999.99
    description: "Bike elétrica com motor 500W"
  }) {
    isSuccess
    message
    statusCode
  }
}
```

### 3. Subscriptions (Real-time)

As subscriptions permitem receber notificações em tempo real quando eventos ocorrem:

```graphql
subscription OnProductCreated {
  onProductCreated {
    id
    name
    price
    description
    createdAt
  }
}

subscription OnProductUpdated {
  onProductUpdated {
    id
    name
    price
    description
    updatedAt
  }
}

subscription OnProductDeleted {
  onProductDeleted {
    id
    isDeleted
  }
}
```

**Nota**: Para usar subscriptions, você precisa usar WebSocket. O HotChocolate suporta isso automaticamente.

## Schema Disponível

O schema completo pode ser visualizado acessando `http://localhost:5000/graphql/schema` ou usando o Banana Cake Pop IDE.

### Tipos Principais

- **Product**: Entidade de produto
- **ApiResult_Product**: Wrapper padrão de resposta
- **PagedResponse_Product**: Resposta paginada
- **OutboxEnvelope**: Mensagem do Outbox Pattern
- **Ulid**: Custom scalar para Ulid (string formatada)

## Como Adicionar Novos Módulos

Para adicionar GraphQL para um novo módulo (ex: Customer):

1. **Criar o GraphQL Type** (Types/):
```csharp
public class CustomerType : ObjectType<Customer>
{
    protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
    {
        descriptor.Name("Customer");
        descriptor.Field(f => f.Id).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.Name).Type<StringType>();
        // ... outros campos
    }
}
```

2. **Criar Input Types** (Types/):
```csharp
public class CreateCustomerInputType : InputObjectType<CustomerRequest.CreateCustomer>
{
    protected override void Configure(IInputObjectTypeDescriptor<CustomerRequest.CreateCustomer> descriptor)
    {
        descriptor.Name("CreateCustomerInput");
        // ... campos
    }
}
```

3. **Criar Queries** (Queries/):
```csharp
[ExtendObjectType("Query")]
public class CustomerQuery
{
    public async Task<ApiResult_Customer> GetCustomerById(
        [Service] IQueryHandler<CustomerQueries.GetCustomerById, Customer> handler,
        Ulid id,
        CancellationToken cancellationToken)
    {
        var query = new CustomerQueries.GetCustomerById(id);
        var result = await handler.HandleAsync(query, cancellationToken);
        return new ApiResult_Customer(result);
    }
}
```

4. **Criar Mutations** (Mutations/):
```csharp
[ExtendObjectType("Mutation")]
public class CustomerMutation
{
    public async Task<MutationResult_Customer> CreateCustomer(
        [Service] ICommandHandler<CustomerCommands.CreateCustomer, Customer> handler,
        CreateCustomerInput input,
        CancellationToken cancellationToken)
    {
        var command = new CustomerCommands.CreateCustomer(input.Name, ...);
        var result = await handler.HandleAsync(command, cancellationToken);
        return new MutationResult_Customer(result);
    }
}
```

5. **Registrar em GraphQLExtensions.cs**:
```csharp
.AddType<CustomerType>()
.AddType<CustomerApiResultType>()
.AddTypeExtension<CustomerQuery>()
.AddTypeExtension<CustomerMutation>()
```

## Vantagens da Implementação

1. **Totalmente Desacoplado**: O GraphQL adapter não conhece a implementação dos handlers, apenas os ports (interfaces)
2. **Reutilizável**: Usa os mesmos ICommandHandler e IQueryHandler que o WebApi REST
3. **Type-Safe**: O HotChocolate gera o schema automaticamente a partir dos tipos C#
4. **Extensível**: Fácil adicionar novos módulos seguindo o padrão
5. **Subscriptions**: Suporte nativo para real-time via WebSocket
6. **Error Handling**: Centralizado via GraphQLErrorFilter

## Testing

Você pode testar o GraphQL usando:

1. **Banana Cake Pop** (IDE nativa do HotChocolate) - acessível via browser
2. **Postman** - suporta GraphQL
3. **GraphQL Playground** - ferramenta web popular
4. **cURL**:
```bash
curl -X POST http://localhost:5000/graphql \
  -H "Content-Type: application/json" \
  -d '{"query": "{ getProductById(id: \"...\") { data { id name } } }"}'
```

## Próximos Passos

Para expandir o GraphQL:

1. Adicionar **Authorization** - integrar com o sistema de autenticação
2. Adicionar **Validation** - usar FluentValidation para validar inputs
3. Adicionar **DataLoader** - para otimizar N+1 queries
4. Adicionar **Complex Types** - para filtros avançados
5. Adicionar **Federation** - se usar Apollo Federation para microservices
