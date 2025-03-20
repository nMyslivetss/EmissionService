using EmissionService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmissionService.Data.Configurations
{
    public class EmissionRecordConfiguration : IEntityTypeConfiguration<EmissionRecord>
    {
        public void Configure(EntityTypeBuilder<EmissionRecord> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Customer).IsRequired();
            builder.Property(e => e.CustomerId).IsRequired();
            builder.Property(e => e.Month).IsRequired();
            builder.Property(e => e.Scope).IsRequired();

            
            builder.HasOne(e => e.LocationBasedEmissions)
                .WithMany() 
                .HasForeignKey(e => e.LocationBasedEmissionsId)
                .OnDelete(DeleteBehavior.NoAction);

            
            builder.HasOne(e => e.MarketBasedEmissions)
                .WithMany()  
                .HasForeignKey(e => e.MarketBasedEmissionsId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
