using Microsoft.EntityFrameworkCore;
using RabbitMQWebApp.DBModel;
using RabbitMQWebApp.SensorMessageDao;
using RabbitMQWebApp.Web.Rest.Model;

namespace RabbitMQWebApp.SensorMessageService.Impl
{
    public class SensorMessageService(SensorMessageContext context, ILogger<SensorMessageService> logger) : ISensorMessageService
    {
        public async Task<List<SensorMessage>> GetAllSensorMessages()
        {
            List<SensorMessageDBModel> messages = await context.SensorMessages.ToListAsync();
            
            logger.LogInformation("returned messages: {messages.Count}", messages.Count);
            
            
            List<SensorMessage>? copiedList = messages.Select(message => new SensorMessage(message.MESSAGE, message.ID)).ToList();
            
            
            logger.LogInformation("copied messages: {copiedList}", copiedList);
            return copiedList;
            
        }
    }
}
