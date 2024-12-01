using RabbitMQWebApp.DBModel;
using RabbitMQWebApp.Web.Rest.Model;

namespace RabbitMQWebApp.Mapper
{
    public class SensorMessageModelMapper: ISensorMessageModelMapper
    {
        public SensorMessage entityToApi(SensorMessageDBModel pSensorMessage)
        {
            SensorMessage message= new SensorMessage(pSensorMessage.MESSAGE, pSensorMessage.ID);
            return message;
        }
    }
}

