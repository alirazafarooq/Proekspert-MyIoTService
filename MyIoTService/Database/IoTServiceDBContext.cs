using Microsoft.EntityFrameworkCore;
using MyIoTService.Entities;

namespace MyIoTService.Database
{
    public class IoTServiceDBContext : DbContext
    {
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EndUser>().HasData(
                new EndUser()
                {
                    Id = 1,
                    FirstName = "Muhammad",
                    LastName = "Zubair",
                    Password = "admin",
                    Username = "admin"
                });
            base.OnModelCreating(modelBuilder);
        }

        public IoTServiceDBContext(DbContextOptions<IoTServiceDBContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
