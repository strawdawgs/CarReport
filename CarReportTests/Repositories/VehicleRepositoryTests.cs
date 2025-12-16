using DataModelLibrary.Models;
using EntityFrameworkAccess.Contexts;
using EntityFrameworkAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarReportTests.Repositories;

public class VehicleRepositoryTests
{
    private static CarMaintenanceDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<CarMaintenanceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new CarMaintenanceDbContext(options);
    }

    [Fact]
    public async Task FindByVehicleDisplayNameAsync()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicles(context);
        await context.SaveChangesAsync();
        EntityRepository<Vehicle> vehicleRepo = new EntityRepository<Vehicle>(context);
        var vehicle = await vehicleRepo.FindByIdAsync(1);
        Assert.NotNull(vehicle);
        Assert.True(vehicle.DisplayName == "Brandons Car");
    }
}
