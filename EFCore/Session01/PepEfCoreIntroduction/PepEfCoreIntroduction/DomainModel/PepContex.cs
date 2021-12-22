using Microsoft.EntityFrameworkCore;

namespace PepEfCoreIntroduction.DomainModel
{
    public class PepContex:DbContext
    {
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=PepDb;User Id=sa;Password=1qaz!QAZ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
