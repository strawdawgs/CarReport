using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataModelLibrary.Models;

namespace EntityFrameworkAccess.Contexts.Configuration;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.DisplayName).HasMaxLength(100);
        builder.Property(v => v.Year);
        builder.Property(v => v.Make).HasMaxLength(50);
        builder.Property(v => v.Model).HasMaxLength(50);
        builder.Property(v => v.Vin).HasMaxLength(17);
        builder.Property(v => v.CurrentMileage);
        builder.Property(v => v.Notes);
    }
}
