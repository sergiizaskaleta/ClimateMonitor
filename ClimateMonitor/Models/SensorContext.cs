using Microsoft.EntityFrameworkCore;

namespace ClimateMonitor.Models
{
    public class SensorContext : DbContext
    {
        public SensorContext(DbContextOptions<SensorContext> options) : base(options)
        {
        }

        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
    }
}
