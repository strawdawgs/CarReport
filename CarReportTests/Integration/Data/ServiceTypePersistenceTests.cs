using EntityFrameworkAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarReportTests.Integration.Data;

public class ServiceTypePersistenceTests
{
    private static CarMaintenanceDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<CarMaintenanceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new CarMaintenanceDbContext(options);
    }

    [Fact]
    public async Task Can_Persist_ServiceType()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedServiceType(context);
        await context.SaveChangesAsync();
        var serviceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        Assert.NotNull(serviceType);
        Assert.Equal(35, serviceType.EstimatedCost);
    }

    [Fact]
    public async Task Can_Persist_Multiple_ServiceTypes()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedServiceTypes(context);
        await context.SaveChangesAsync();
        var serviceTypes = await context.ServiceTypes.ToListAsync();
        Assert.Equal(2, serviceTypes.Count);
        Assert.Contains(serviceTypes, st => st.Type == "Oil Change" && st.EstimatedCost == 35);
        Assert.Contains(serviceTypes, st => st.Type == "Tire Rotation" && st.EstimatedCost == 50);
    }

    [Fact]
    public async Task Can_Update_ServiceType()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedServiceType(context);
        await context.SaveChangesAsync();
        var serviceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        if (serviceType == null)
        {
            throw new Exception("Seeded service type not found.");
        }
        serviceType.EstimatedCost = 40;
        await context.SaveChangesAsync();
        var updatedServiceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        if (updatedServiceType == null)
        {
            throw new Exception("Updated service type not found.");
        }
        Assert.Equal(40, updatedServiceType.EstimatedCost);
    }

    [Fact]
    public async Task Can_Delete_ServiceType()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedServiceType(context);
        await context.SaveChangesAsync();
        var serviceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        if (serviceType == null)
        {
            throw new Exception("Seeded service type not found.");
        }
        context.ServiceTypes.Remove(serviceType);
        await context.SaveChangesAsync();
        var deletedServiceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Oil Change");
        Assert.Null(deletedServiceType);
    }

    [Fact]
    public async Task Can_Retrieve_ServiceTypes()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedServiceTypes(context);
        await context.SaveChangesAsync();
        var serviceTypes = await context.ServiceTypes.ToListAsync();
        Assert.Equal(2, serviceTypes.Count);
    }

    [Fact]
    public async Task Can_Query_ServiceType_By_Type()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedServiceTypes(context);
        await context.SaveChangesAsync();
        var serviceType = await context.ServiceTypes.FirstOrDefaultAsync(st => st.Type == "Tire Rotation");
        Assert.NotNull(serviceType);
        Assert.Equal(50, serviceType.EstimatedCost);
    }

    [Fact]
    public async Task Can_Query_ServiceType_By_EstimatedCost()
    {
        var context = GetInMemoryDbContext();
        TestDataSeeder.SeedServiceTypes(context);
        await context.SaveChangesAsync();
        var serviceTypes = await context.ServiceTypes
            .Where(st => st.EstimatedCost > 40)
            .ToListAsync();
        Assert.Single(serviceTypes);
        Assert.Equal("Tire Rotation", serviceTypes[0].Type);
    }
}
