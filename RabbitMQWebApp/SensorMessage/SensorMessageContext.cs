using Microsoft.EntityFrameworkCore;

namespace RabbitMQWebApp.SensorMessage
{
    public class SensorMessageContext : DbContext
    {

        public SensorMessageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SensorMessage> SensorMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqlserver,1433;Database=SensorMessage;Trusted_Connection=True;");
        }
    }
}
