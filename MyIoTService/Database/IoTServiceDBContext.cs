using Microsoft.EntityFrameworkCore;
using MyIoTService.Entities;

namespace MyIoTService.Database
{
    public class IoTServiceDBContext : DbContext
    {
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Device> Devices { get; set; }

        public IoTServiceDBContext(DbContextOptions<IoTServiceDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
