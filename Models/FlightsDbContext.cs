using Azure;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_Project.Models
{
    public class FlightsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Airticket> Airtickets { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public FlightsDbContext(DbContextOptions options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Standart" },
                new Role { Id = 2, Name = "Administrator" }
            );
            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = 1, Name = "Administrator",
                    Surname = "Administrator", DocumentNumber = "0000",
                    Login = "Admin", Password = "12345",
                    RoleId = 2, Airtickets = new List<Airticket>() 
                }
            );
        }
    }
}
