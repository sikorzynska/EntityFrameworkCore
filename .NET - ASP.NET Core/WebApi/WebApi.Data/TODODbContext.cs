using Microsoft.EntityFrameworkCore;
using WebApi.Data.Configurations;
using WebApi.Data.Entities;

namespace WebApi.Data
{
    public class TODODbContext : DbContext
    {
        public TODODbContext()
            : base()
        {
        }

        public TODODbContext(DbContextOptions<TODODbContext> options)
            : base(options)
        {
        }

        public DbSet<TODO> TODOs { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TODOConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
