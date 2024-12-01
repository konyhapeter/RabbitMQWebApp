using Microsoft.EntityFrameworkCore;
using RabbitMQWebApp.Config;
using RabbitMQWebApp.Mapper;
using RabbitMQWebApp.ReceiverService;
using RabbitMQWebApp.SensorMessageDao;
using RabbitMQWebApp.SensorMessageMigrations;
using RabbitMQWebApp.SensorMessageService;
using RabbitMQWebApp.SensorMessageService.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQConfig"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SensorMessageContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHostedService<RabbitMQMessageReceiver>();

builder.Services.AddScoped<ISensorMessageService, SensorMessageService>();
builder.Services.AddScoped<ISensorMessageModelMapper, SensorMessageModelMapper>();

builder.Services.AddControllers();
builder.Services.AddScoped<SensorMessageMigrator>();

var app = builder.Build();

var scope = app.Services.CreateScope();
SensorMessageContext sensorMessageContext = scope.ServiceProvider.GetRequiredService<SensorMessageContext>();

sensorMessageContext.Database.EnsureCreated();

app.UseRouting();
app.MapControllers();
app.Run();
