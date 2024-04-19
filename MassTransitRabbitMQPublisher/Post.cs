using System.ComponentModel.DataAnnotations;

namespace MassTransitRabbitMQPublisher;

public record Post
{
    [Key]
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Content { get; init; }
    public DateTime CreatedAt { get; init; }
}