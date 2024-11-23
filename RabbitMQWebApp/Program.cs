using Microsoft.EntityFrameworkCore;
using RabbitMQWebApp.Config;
using RabbitMQWebApp.ReceiverService;
using RabbitMQWebApp.SensorMessage;
using RabbitMQWebApp.SensorMessageMigrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQConfig"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SensorMessageContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHostedService<RabbitMQMessageReceiver>();

builder.Services.AddScoped<SensorMessageMigrator>();

var app = builder.Build();

var scope = app.Services.CreateScope();
SensorMessageContext sensorMessageContext = scope.ServiceProvider.GetRequiredService<SensorMessageContext>();

sensorMessageContext.Database.EnsureCreated();

app.Run();
