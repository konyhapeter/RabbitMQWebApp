namespace RabbitMQWebApp.Web.Rest.Model
{
    public class SensorMessageReply
    {
        public List<SensorMessage> Messages = [];

        public SensorMessageReply(List<SensorMessage> messages)
        {
            this.Messages = messages;
        }
    }

}
