using MassTransit;
using MassTransitRabbitMQShared;

namespace MassTransitRabbitMQConsumer.Consumers
{
    public class MessageConsumer :
        IConsumer<BlogPost>
    {
        public Task Consume(ConsumeContext<BlogPost> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received message: {message.Message}");
            return Task.CompletedTask;
        }
    }
}