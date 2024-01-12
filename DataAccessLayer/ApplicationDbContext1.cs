using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DBContext
{
    public class ApplicationDbContext1 : DbContext
    {
        public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here using modelBuilder.Entity<T>().

            // Example:
            // modelBuilder.Entity<Event>().HasKey(e => e.Id);
            // modelBuilder.Entity<Ticket>().HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
