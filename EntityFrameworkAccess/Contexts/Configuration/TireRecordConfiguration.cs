using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataModelLibrary.Models;

namespace EntityFrameworkAccess.Contexts.Configuration;

public class TireRecordConfiguration : IEntityTypeConfiguration<TireRecord>
{
    public void Configure(EntityTypeBuilder<TireRecord> builder)
    {
        builder.HasKey(tr => tr.Id);
        builder.Property(tr => tr.DateLastServiced);
        builder.Property(tr => tr.MileageLastServiced);
        builder.Property(tr => tr.Position).HasMaxLength(20);
        builder.Property(tr => tr.Brand).HasMaxLength(100);
        builder.Property(tr => tr.Model).HasMaxLength(100);
        builder.Property(tr => tr.TireSize).HasMaxLength(50);
        builder.Property(tr => tr.TreadDepth32nds);
        builder.Property(tr => tr.PressurePsi);
        builder.Property(tr => tr.CostPerTire);
        builder.Property(tr => tr.ShopName).HasMaxLength(100);
        builder.Property(tr => tr.Notes);
        builder.HasOne(tr => tr.Vehicle)
            .WithMany(v => v.TireRecords)
            .HasForeignKey(tr => tr.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
