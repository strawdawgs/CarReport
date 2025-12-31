using EntityFrameworkAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarReportTests.Integration.Data;

public class ServiceRecordTests
{
    private static CarMaintenanceDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<CarMaintenanceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new CarMaintenanceDbContext(options);
    }

    [Fact]
    public async Task Can_Persist_ServiceRecord()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicle(context);
        TestDataSeeder.SeedServiceType(context);
        await context.SaveChangesAsync();
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        var serviceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        if (vehicle == null || serviceType == null)
        {
            throw new Exception("Seeded data not found.");
        }
        TestDataSeeder.SeedServiceRecord(context, vehicle.Id, serviceType.Id);
        await context.SaveChangesAsync();
        var serviceRecord = await context.ServiceRecords
            .Include(sr => sr.Vehicle)
            .Include(sr => sr.ServiceType)
            .FirstOrDefaultAsync(sr => sr.VehicleId == vehicle.Id && sr.ServiceTypeId == serviceType.Id);
        Assert.NotNull(serviceRecord);
        Assert.Equal(vehicle.Id, serviceRecord.VehicleId);
        Assert.Equal(serviceType.Id, serviceRecord.ServiceTypeId);
    }

    [Fact]
    public async Task Can_Persist_Multiple_ServiceRecords()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicles(context);
        TestDataSeeder.SeedServiceTypes(context);
        await context.SaveChangesAsync();
        var vehicles = await context.Vehicles.ToListAsync();
        var serviceTypes = await context.ServiceTypes.ToListAsync();
        foreach (var vehicle in vehicles)
        {
            foreach (var serviceType in serviceTypes)
            {
                TestDataSeeder.SeedServiceRecord(context, vehicle.Id, serviceType.Id);
            }
        }
        await context.SaveChangesAsync();
        var serviceRecords = await context.ServiceRecords.ToListAsync();
        Assert.Equal(vehicles.Count * serviceTypes.Count, serviceRecords.Count);
    }

    [Fact]
    public async Task Can_Update_ServiceRecord()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicle(context);
        TestDataSeeder.SeedServiceType(context);
        await context.SaveChangesAsync();
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        var serviceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        if (vehicle == null || serviceType == null)
        {
            throw new Exception("Seeded data not found.");
        }
        TestDataSeeder.SeedServiceRecord(context, vehicle.Id, serviceType.Id);
        await context.SaveChangesAsync();
        var serviceRecord = await context.ServiceRecords
            .FirstOrDefaultAsync(sr => sr.VehicleId == vehicle.Id && sr.ServiceTypeId == serviceType.Id);
        if (serviceRecord == null)
        {
            throw new Exception("Seeded service record not found.");
        }
        serviceRecord.Notes = "Changed oil and filter.";
        await context.SaveChangesAsync();
        var updatedServiceRecord = await context.ServiceRecords
            .FirstOrDefaultAsync(sr => sr.VehicleId == vehicle.Id && sr.ServiceTypeId == serviceType.Id);
        if (updatedServiceRecord == null)
        {
            throw new Exception("Updated service record not found.");
        }
        Assert.Equal("Changed oil and filter.", updatedServiceRecord.Notes);
    }

    [Fact]
    public async Task Can_Delete_ServiceRecord()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicle(context);
        TestDataSeeder.SeedServiceType(context);
        await context.SaveChangesAsync();
        var vehicle = await context.Vehicles.FirstOrDefaultAsync(v => v.DisplayName == "Brandons Car");
        var serviceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        if (vehicle == null || serviceType == null)
        {
            throw new Exception("Seeded data not found.");
        }
        TestDataSeeder.SeedServiceRecord(context, vehicle.Id, serviceType.Id);
        await context.SaveChangesAsync();
        var serviceRecord = await context.ServiceRecords
            .FirstOrDefaultAsync(sr => sr.VehicleId == vehicle.Id && sr.ServiceTypeId == serviceType.Id);
        if (serviceRecord == null)
        {
            throw new Exception("Seeded service record not found.");
        }
        context.ServiceRecords.Remove(serviceRecord);
        await context.SaveChangesAsync();
        var deletedServiceRecord = await context.ServiceRecords
            .FirstOrDefaultAsync(sr => sr.VehicleId == vehicle.Id && sr.ServiceTypeId == serviceType.Id);
        Assert.Null(deletedServiceRecord);
    }

    [Fact]
    public async Task Can_Retrieve_ServiceRecords_By_Vehicle()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicles(context);
        TestDataSeeder.SeedServiceTypes(context);
        await context.SaveChangesAsync();
        var vehicles = await context.Vehicles.ToListAsync();
        var serviceTypes = await context.ServiceTypes.ToListAsync();
        foreach (var vehicle in vehicles)
        {
            foreach (var serviceType in serviceTypes)
            {
                TestDataSeeder.SeedServiceRecord(context, vehicle.Id, serviceType.Id);
            }
        }
        await context.SaveChangesAsync();
        var targetVehicle = vehicles.First();
        var serviceRecords = await context.ServiceRecords
            .Where(sr => sr.VehicleId == targetVehicle.Id)
            .ToListAsync();
        Assert.Equal(serviceTypes.Count, serviceRecords.Count);
        foreach (var serviceRecord in serviceRecords)
        {
            Assert.Equal(targetVehicle.Id, serviceRecord.VehicleId);
        }
    }

    [Fact]
    public async Task Can_Retrieve_ServiceRecords_By_ServiceType()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedVehicles(context);
        TestDataSeeder.SeedServiceTypes(context);
        await context.SaveChangesAsync();
        var vehicles = await context.Vehicles.ToListAsync();
        var serviceTypes = await context.ServiceTypes.ToListAsync();
        foreach (var vehicle in vehicles)
        {
            foreach (var serviceType in serviceTypes)
            {
                TestDataSeeder.SeedServiceRecord(context, vehicle.Id, serviceType.Id);
            }
        }
        await context.SaveChangesAsync();
        var targetServiceType = serviceTypes.First();
        var serviceRecords = await context.ServiceRecords
            .Where(sr => sr.ServiceTypeId == targetServiceType.Id)
            .ToListAsync();
        Assert.Equal(vehicles.Count, serviceRecords.Count);
        foreach (var serviceRecord in serviceRecords)
        {
            Assert.Equal(targetServiceType.Id, serviceRecord.ServiceTypeId);
        }
    }
}
