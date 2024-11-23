using Microsoft.EntityFrameworkCore;

namespace RabbitMQWebApp.SensorMessage
{
    public class SensorMessageContext : DbContext
    {
        public SensorMessageContext() : base() { }

        public SensorMessageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SensorMessageHolder> SensorMessages { get; set; }
    }
}