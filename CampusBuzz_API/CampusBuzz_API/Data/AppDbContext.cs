using CampusBuzz_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusBuzz_API.Data
{
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(

                new Event { EventId = 1, EventTitle = "Tech Workshop", Location = "Lab A", TicketPrice = "$50" },
                new Event { EventId = 2, EventTitle = "Music Festival", Location = "Main Hall", TicketPrice = "$120" },
                new Event { EventId = 3, EventTitle = "Startup Pitch", Location = "Auditorium", TicketPrice = "Free" }
            );
        }
    }
}
