using DataModelLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAccess.Contexts;

public class CarMaintenanceDbContext(DbContextOptions<CarMaintenanceDbContext> options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<ServiceRecord> ServiceRecords { get; set; }
    public DbSet<TireRecord> TireRecords { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarMaintenanceDbContext).Assembly);
    }
}

