using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class PalitaxDbContext:DbContext
    {
        public PalitaxDbContext(DbContextOptions<PalitaxDbContext> options):base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
    }
}
