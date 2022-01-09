using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class PalitaxDbContext:DbContext
    {
        public PalitaxDbContext(DbContextOptions<PalitaxDbContext> options):base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
