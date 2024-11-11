using Microsoft.EntityFrameworkCore;

namespace AttendanceApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Attendee> Attendees { get; set; }
    }
}
