# MassTransit .NET 8 + RabbitMQ Example

This is a simple example of using MassTransit with RabbitMQ in a .NET 8 application. The project is structured into three main components: a message publisher, a message consumer, and a shared library.

The `MassTransitRabbitMQPublisher` application serves as the message publisher. It exposes an API endpoint that allows for the publishing of messages to a RabbitMQ queue. Additionally, it handles the storage of data in a PostgreSQL database.

The `MassTransitRabbitMQConsumer` application acts as the message consumer. It listens to the RabbitMQ queue and processes incoming messages.

The `MassTransitRabbitMQShared` is a shared library that contains common classes used by both the publisher and consumer applications.

This project demonstrates a basic use case of a distributed system using message queues for communication. It can be used as a starting point for building more complex systems that require asynchronous messaging.
## Prerequisites

- .NET 8 SDK
- Docker

## How to Run

1. Start the necessary services (RabbitMQ, PostgreSQL) using Docker:

```bash
docker-compose up -d
```

2. Run the application:

```bash
dotnet run --project MassTransitRabbitMQConsumer/MassTransitRabbitMQConsumer.csproj
dotnet run --project MassTransitRabbitMQPublisher/MassTransitRabbitMQPublisher.csproj
```

## Application structure

* `MassTransitRabbitMQConsumer` - an application that consumes messages from the RabbitMQ queue.
* `MassTransitRabbitMQPublisher` - an application with API endpoint that publishes messages to the RabbitMQ queue and stores data in PostgreSQL database.
* `MassTransitRabbitMQShared` - a shared library with common class for the publisher and consumer applications.
* `docker-compose.yml` - a file with the configuration for the PostgreSQL and RabbitMQ services.