using System.ComponentModel.DataAnnotations;

namespace RabbitMQWebApp.Config
{
    public class RabbitMQConfig
    {
        [Required]
        public string HostName { get; set; }
        [Required]
        public string QueueName { get; set; }
        [Required]
        public string ExchangeName { get; set; }
        [Required]
        public string RoutingKey { get; set; }

        [Required]
        public string RabbitUserName { get; set; }

        [Required]
        public string RabbitPassword { get; set; }

        [Required]
        public int RabbitPort { get; set; }
    }
}
