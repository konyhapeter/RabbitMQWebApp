using Microsoft.AspNetCore.Mvc;
using RabbitMQWebApp.Mapper;
using RabbitMQWebApp.SensorMessageService;
using RabbitMQWebApp.Web.Rest.Model;

namespace RabbitMQWebApp.Web.Rest
{
    [ApiController]
    [Route("sensormessage")]
    public class SensorMessageController(ISensorMessageService sensorMessageService, ISensorMessageModelMapper messageModelMapper, ILogger<SensorMessageController> logger) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SensorMessageReply>> GetSensorMessages()
        {
            SensorMessageReply reply = new SensorMessageReply(await sensorMessageService.GetAllSensorMessages());
            if (reply.Messages.Count == 0){
                return Ok(reply);
            }
            logger.LogInformation("reply: size {size}", reply.Messages.Count);
            reply.Messages.ForEach(message => logger.LogInformation("message from db: {message}", message.message));
            return Ok(reply);
        }
    }
}
