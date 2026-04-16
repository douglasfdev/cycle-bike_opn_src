# CycleBike

## Sobre
CycleBike é uma aplicação Open Source para gerenciar alugueis de bicicletas elétricas!

Ela é dedicada para aprendizagem com:
- .NET 10
- Entity Framework Core
- MongoDB
- RabbitMQ
- Redis
- Docker
- Wolverine
- WebSocket - SignalR
- WebApi
- Workers Consumers
- CQRS
- Event Sourcing
- GraphQL
- Outbox Pattern
- Message Broker
- Microservices
- Hexagonal Architecture

## Arquitetura 
O projeto segue a arquitetura Hexagonal (Ports and Adapters).

![img.png](docs/hexagonal-arch.png)

Com Dominios Ricos, CQRS separado em Command e Query

![img.png](docs/cqrs.png)

- Utiliza o padrão de Event Sourcing para persistência de dados.
- Utiliza o padrão de Outbox Pattern para envio de mensagens a RabbitMQ e o padrão de Message Broker para recebimento de mensagens do RabbitMQ.
- Utiliza o padrão de Workers Consumers para processamento de mensagens do RabbitMQ.
- Utiliza o conceito de aplicação distribuida utilizando o padrão de Microservices.



## Testes
Utiliza xUnit para realizar a piramide de testes

![img.png](docs/pyramid-tests.png)

## Funcionalidades Esperadas
- Cadastro de bicicletas
- Aluguel de bicicletas
- Devolução de bicicletas
- Consulta de bicicletas disponíveis
- Consulta de alugueis realizados
- Consulta de alugueis em andamento
- Consulta de alugueis finalizados
- Consulta de alugueis cancelados
- Consulta de alugueis por usuário
- Consulta de alugueis por bicicleta
- Consulta de alugueis por data
- Consulta de alugueis por status
- Consulta de bicicletas por status
- Consulta de bicicletas por localização
- Consulta de bicicletas por modelo
- Consulta de bicicletas por marca
- Cadastro de usuários
- Login de usuários
- Consulta de usuários
- Cadastro de Perfil
- Consulta de Perfil
- Pagamento de aluguel de bicicletas
- Envio de notificações para usuários
- Envio de notificações para administradores
- Envio de notificações para técnicos
- Registro de cupons
- Notificações de cupons

# Startup

Para iniciar a aplicação é necessário que você tenha o Docker instalado na máquina, ou trocar as variáveis de ambiente para um serviço real hospedado ao invés de localhost.
Se tiver o Docker instalado, basta rodar o comando `docker compose up -d` (ou `docker-compose up -d` dependendo de como você instalou o Docker) na pasta raiz da aplicação.

Depois iniciar o WebApi para abrir a API Rest ou GraphQL.
Caso publicar algo em fila, o worker responsável por consumir a fila é o OutboxRelay, Repare que por hora temos um exemplo de caso de uso.
Caso queira usar cacheamento com Redis o Handler CreateProductCacheHandler segue de exemplo, basta verificar como é chamado os Command Handlers que estão no ApplicationLayer.
Os serviços de notificações com WebSockets ainda estão sendo implementados com SignalR, mas também podem ser implementados com GraphQL.
