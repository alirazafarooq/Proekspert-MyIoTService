using IoTDevice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IoTDevice.Database
{
    public class IoTDeviceDBContext : DbContext
    {
        public DbSet<Device> devices { get; set; }

        public IoTDeviceDBContext(DbContextOptions<IoTDeviceDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
