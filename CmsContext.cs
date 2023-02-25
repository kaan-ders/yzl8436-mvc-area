using Area.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcEf
{
    public class CmsContext : DbContext
    {
        public CmsContext(DbContextOptions<CmsContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }        
    }
}