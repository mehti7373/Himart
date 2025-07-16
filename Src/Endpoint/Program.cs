using System.Reflection;
using System.Text.Json.Serialization;
using Core.Application.Tasks.Commands.CreateTask;
using Core.Domain.TaskAggregate.DomainService;
using Endpoint.Extensions;
using Infrastructure.Data;
using MassTransit;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext();
});


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

builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly));
builder.Services.AddScoped<ITaskDomainService, TaskDomainService>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    //options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.WriteIndented = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHimartSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseHimartSwagger(app);
}

app.Services.MigrateDbContext();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseSerilogRequestLogging(); // ✅ Optional: logs all HTTP requests
app.MapControllers();

app.Run();
