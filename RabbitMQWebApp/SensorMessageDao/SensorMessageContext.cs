using Microsoft.EntityFrameworkCore;
using RabbitMQWebApp.DBModel;

namespace RabbitMQWebApp.SensorMessageDao
{
    public class SensorMessageContext : DbContext
    {
        public SensorMessageContext() : base() { }

        public SensorMessageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SensorMessageDBModel> SensorMessages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}