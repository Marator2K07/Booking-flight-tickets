using Azure;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            modelBuilder.Entity<Airline>().HasData(
                new Airline { Id = 1, Name = "S8 Airline", License = "LKMN" },
                new Airline { Id = 2, Name = "Barnaulskie avialinii", License = "QWER" },
                new Airline { Id = 3, Name = "Altair avia", License = "BGYU" },
                new Airline { Id = 4, Name = "Average lines", License = "WASD" }
            );
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id = 1, Date = DateTime.ParseExact("11/22/2023 12:15",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 3 },
                new Schedule { Id = 2, Date = DateTime.ParseExact("11/23/2023 11:30",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 1 },
                new Schedule { Id = 3, Date = DateTime.ParseExact("11/24/2023 15:15",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 2 },
                new Schedule { Id = 4, Date = DateTime.ParseExact("11/25/2023 16:55",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 4 },
                new Schedule { Id = 5, Date = DateTime.ParseExact("11/26/2023 13:45",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 3 },
                new Schedule { Id = 6, Date = DateTime.ParseExact("11/27/2023 10:10",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 3 },
                new Schedule { Id = 7, Date = DateTime.ParseExact("11/28/2023 15:15",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 2 },
                new Schedule { Id = 8, Date = DateTime.ParseExact("11/29/2023 20:00",
                "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), AirlineId = 1 }
            );
        }
    }
}
