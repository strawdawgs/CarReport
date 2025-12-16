using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataModelLibrary.Models;

namespace EntityFrameworkAccess.Contexts.Configuration;

public class ServiceRecordConfiguration : IEntityTypeConfiguration<ServiceRecord>
{
    public void Configure(EntityTypeBuilder<ServiceRecord> builder)
    {
        builder.HasKey(sr => sr.Id);
        builder.Property(sr => sr.ServiceType)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(sr => sr.DateLastServiced);
        builder.Property(sr => sr.MileageLastService);
        builder.Property(sr => sr.RecommendedInterval).HasMaxLength(50);
        builder.Property(sr => sr.NextDueMileage).HasMaxLength(50);
        builder.Property(sr => sr.NextDueDate);
        builder.Property(sr => sr.CostLastService);
        builder.Property(sr => sr.ShopName).HasMaxLength(100);
        builder.Property(sr => sr.Notes);
        builder.HasOne(sr => sr.Vehicle)
            .WithMany(v => v.ServiceRecords)
            .HasForeignKey(sr => sr.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
