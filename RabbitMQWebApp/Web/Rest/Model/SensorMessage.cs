namespace RabbitMQWebApp.Web.Rest.Model
{
    public record SensorMessage(string message)
    {
        public static SensorMessage From(string message)
        {
            return new SensorMessage(message);
        }
    }
}
