using RabbitMQWebApp.Config;
using RabbitMQWebApp.ReceiverService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQConfig"));

builder.Services.AddHostedService<RabbitMQMessageReceiver>();    

var app = builder.Build();

app.Run();
