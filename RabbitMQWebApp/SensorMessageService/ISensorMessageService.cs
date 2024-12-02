using RabbitMQWebApp.Web.Rest.Model;

namespace RabbitMQWebApp.SensorMessageService
{
    public interface ISensorMessageService
    {
        public Task<List<SensorMessage>> GetAllSensorMessages();
    } 
}

