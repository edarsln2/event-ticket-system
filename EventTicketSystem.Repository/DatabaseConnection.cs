using Microsoft.EntityFrameworkCore;
using EventTicketSystem.Entity;

namespace EventTicketSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
