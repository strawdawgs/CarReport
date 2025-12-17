using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataModelLibrary.Models;

namespace EntityFrameworkAccess.Contexts.Configuration;

public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {
        builder.HasKey(st => st.Id);
        builder.Property(st => st.Type).HasMaxLength(100);
        builder.Property(st => st.RecommendedIntervalInMilesMinimum);
        builder.Property(st => st.RecommendedIntervalInMilesMaximum);
        builder.Property(st => st.RecommendedIntervalInYears);
    }
}
