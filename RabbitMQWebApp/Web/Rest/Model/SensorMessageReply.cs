namespace RabbitMQWebApp.Web.Rest.Model
{
    public record SensorMessageReply
    {
        public List<SensorMessage> Messages { get; set; }
    }

}
