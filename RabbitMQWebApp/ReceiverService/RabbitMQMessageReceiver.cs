using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQWebApp.Config;
using System.Text;

namespace RabbitMQWebApp.ReceiverService
{
    public class RabbitMQMessageReceiver : BackgroundService
    {

        private readonly RabbitMQConfig _rabbitMQConfig;

        //mosquitto_pub -h localhost -p 1884 -P guest -u guest -t mqtt_topic -m "Hello, RabbitMQ!"

        public RabbitMQMessageReceiver(IOptions<RabbitMQConfig> rabbitMQConfig)
        {
            _rabbitMQConfig = rabbitMQConfig.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _rabbitMQConfig.HostName, // Use appropriate host address
                UserName = _rabbitMQConfig.RabbitUserName,     // Use your RabbitMQ username
                Password = _rabbitMQConfig.RabbitPassword,      // Use your RabbitMQ password
                Port = _rabbitMQConfig.RabbitPort
            };
            IConnection _connection = await factory.CreateConnectionAsync();
            IChannel _channel = await _connection.CreateChannelAsync();
            await _channel.QueueDeclareAsync(queue: _rabbitMQConfig.QueueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
            await _channel.QueueBindAsync(queue: _rabbitMQConfig.QueueName, exchange: _rabbitMQConfig.ExchangeName, routingKey: _rabbitMQConfig.RoutingKey);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[x] Received: {message}");
            };
            await _channel.BasicConsumeAsync(queue: _rabbitMQConfig.QueueName,
                   autoAck: true,
                   consumer: consumer);



            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(100, stoppingToken);
            }


        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Background service is stopping.");
            return base.StopAsync(stoppingToken);
        }
    }
}
