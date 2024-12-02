using RabbitMQWebApp.DBModel;
using RabbitMQWebApp.Web.Rest.Model;

namespace RabbitMQWebApp.Mapper
{
    public interface ISensorMessageModelMapper
    {
        SensorMessage entityToApi(SensorMessageDBModel sensorMessage);
    }
}
