using Greetings.Models;
using Microsoft.EntityFrameworkCore;

namespace Greetings.Data
{
    public class GreetingContext : DbContext
    {


        public GreetingContext(DbContextOptions<GreetingContext> options)
            : base(options) { }

        public DbSet<Greeting> Greetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding initial data
            modelBuilder.Entity<Greeting>().HasData(
                new Greeting
                {
                    Id = 1,
                    Name = "World",
                    GreetingText = "Hello, World",
                    CreatedAt = new DateTime(2025, 06, 23)
                }
            );
        }
    }
}
