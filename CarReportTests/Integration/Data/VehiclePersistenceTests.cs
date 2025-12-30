using DataModelLibrary.Models;
using EntityFrameworkAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarReportTests.Integration.Data;

public class VehiclePersistenceTests
{
    private static CarMaintenanceDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<CarMaintenanceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new CarMaintenanceDbContext(options);
    }

    [Fact]
    public async Task Can_Persist_Vehicle()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicle(context);
        await context.SaveChangesAsync();
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        Assert.NotNull(vehicle);
        Assert.Equal(2015, vehicle.Year);
        Assert.Equal("Honda", vehicle.Make);
        Assert.Equal("Civic", vehicle.Model);
    }

    [Fact]
    public async Task Can_Persist_Multiple_Vehicles()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicles(context);
        await context.SaveChangesAsync();
        var vehicles = await context.Vehicles.ToListAsync();
        Assert.Equal(2, vehicles.Count);
        Assert.Contains(vehicles, v => v.DisplayName == "Brandons Car" && v.Year == 2015);
        Assert.Contains(vehicles, v => v.DisplayName == "Mallorys Car" && v.Year == 2019);
    }

    [Fact]
    public async Task Can_Update_Vehicle()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicle(context);
        await context.SaveChangesAsync();
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        if (vehicle == null)
        {
            throw new Exception("Seeded vehicle not found.");
        }
        vehicle.Model = "Accord";
        await context.SaveChangesAsync();
        var updatedVehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        if (updatedVehicle == null)
        {
            throw new Exception("Updated vehicle not found.");
        }
        Assert.Equal("Accord", updatedVehicle.Model);
    }

    [Fact]
    public async Task Can_Delete_Vehicle()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicle(context);
        await context.SaveChangesAsync();
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        if (vehicle == null)
        {
            throw new Exception("Seeded vehicle not found.");
        }
        context.Vehicles.Remove(vehicle);
        await context.SaveChangesAsync();
        var deletedVehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        Assert.Null(deletedVehicle);
    }

    [Fact]
    public async Task Can_Query_Vehicles_By_Make()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicles(context);
        await context.SaveChangesAsync();
        var hondaVehicles = await context.Vehicles
            .Where(v => v.Make == "Honda")
            .ToListAsync();
        Assert.Equal(2, hondaVehicles.Count);
    }

    [Fact]
    public async Task Can_Query_Vehicles_By_Year()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicles(context);
        await context.SaveChangesAsync();
        var vehicles2019 = await context.Vehicles
            .Where(v => v.Year == 2019)
            .ToListAsync();
        Assert.Single(vehicles2019);
        Assert.Equal("Mallorys Car", vehicles2019[0].DisplayName);
    }
}
