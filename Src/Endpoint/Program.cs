using System.Reflection;
using Core.Application.Tasks.Commands.CreateTask;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(Program)); // Register all consumers in the assembly

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context); // auto-bind consumers to queues
    });
});

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
