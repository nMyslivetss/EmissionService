using EmissionService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmissionService.Data.Configurations
{
    public class EmissionValuesConfiguration : IEntityTypeConfiguration<EmissionValues>
    {
        public void Configure(EntityTypeBuilder<EmissionValues> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CO2).HasColumnType("decimal(18,4)");
            builder.Property(e => e.CO2e).HasColumnType("decimal(18,4)");
            builder.Property(e => e.CH4).HasColumnType("decimal(18,4)");
            builder.Property(e => e.N2O).HasColumnType("decimal(18,4)");
        }
    }
}
