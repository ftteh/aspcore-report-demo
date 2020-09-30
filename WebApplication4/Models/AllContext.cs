using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class AllContext : DbContext
    {
        public AllContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add uniqueness constraint
            //modelBuilder.Entity<Readership>().HasIndex(s => s.userId).IsUnique(false); modelBuilder.Entity<Readership>().HasIndex(s => s.reportId).IsUnique(false);
        }

        public AllContext(DbContextOptions<AllContext> options) : base(options)
        {
        }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Readership> Readerships { get; set; }
    }
}
