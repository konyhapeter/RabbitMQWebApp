namespace RabbitMQWebApp.Web.Rest.Model
{
    public class SensorMessage()
    {
        public string Message { get; set; }
        public int Id { get; set; } 
        public SensorMessage(string value, int id) : this()
        {
            Message = value;
            Id = id;
        }
    }
}
