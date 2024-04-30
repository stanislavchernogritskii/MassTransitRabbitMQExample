using MassTransit;
using MassTransitRabbitMQPublisher;
using MassTransitRabbitMQShared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(o => 
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/posts", async (AppDbContext dbContext, Post post, IBus bus) =>
{
    post = post with { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow };
    await dbContext.Posts.AddAsync(post);
    await dbContext.SaveChangesAsync();
    await bus.Publish(new BlogPost(post.Id, post.Title));
    return Results.Created($"/posts/{post.Id}", post.Title);
});

app.Run();

// docker compose up -d
// dotnet ef database update