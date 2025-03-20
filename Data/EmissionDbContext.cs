using EmissionService.Data.Configurations;
using EmissionService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmissionService.Data
{
    public class EmissionDbContext : DbContext
    {
        public EmissionDbContext(DbContextOptions<EmissionDbContext> context) : base(context) { }
        
        public DbSet<EmissionRecord> EmissionRecords { get; set; }
        public DbSet<EmissionValues> EmissionValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmissionRecordConfiguration());
            modelBuilder.ApplyConfiguration(new EmissionValuesConfiguration());
        }
    }
}
