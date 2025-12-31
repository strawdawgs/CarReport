using DataModelLibrary.Models;
using EntityFrameworkAccess.Contexts;

namespace CarReportTests.Integration.Data;

public class TestDataSeeder
{
    public static void SeedVehicle(CarMaintenanceDbContext context) 
    {
        context.Vehicles.Add(
            new Vehicle 
            {
                DisplayName = "Brandons Car",
                Year = 2015,
                Make = "Honda",
                Model = "Civic"
            }
        );
    }

    public static void SeedVehicles(CarMaintenanceDbContext context) 
    {
        context.Vehicles.AddRange(
            new Vehicle 
            {
                DisplayName = "Brandons Car",
                Year = 2015,
                Make = "Honda",
                Model = "Civic"
            },
            new Vehicle
            {
                DisplayName = "Mallorys Car",
                Year = 2019,
                Make = "Honda",
                Model = "Civic"
            }
        );
    }

    public static void SeedServiceType(CarMaintenanceDbContext context) 
    {
        context.ServiceTypes.Add(
            new ServiceType 
            {
                Type = "Oil Change",
                EstimatedCost = 35
            }
        );
    }

    public static void SeedServiceTypes(CarMaintenanceDbContext context) 
    {
        context.ServiceTypes.AddRange(
            new ServiceType 
            {
                Type = "Oil Change",
                EstimatedCost = 35
            },
            new ServiceType 
            {
                Type = "Tire Rotation",
                EstimatedCost = 50
            }
        );
    }

    public static void SeedServiceRecord(CarMaintenanceDbContext context, int vehicleId, int serviceTypeId) 
    {
        context.ServiceRecords.Add(
            new ServiceRecord 
            {
                VehicleId = vehicleId,
                ServiceTypeId = serviceTypeId,
                DateLastServiced = DateTime.UtcNow,
                MileageLastService = 15000,
                CostLastService = 40,
                ShopName = "Quick Lube",
                Notes = "Changed oil and filter"
            }
        );
    }

    public static void SeedServiceRecords(CarMaintenanceDbContext context, int vehicleId, int serviceTypeId1, int serviceTypeId2) 
    {
        context.ServiceRecords.AddRange(
            new ServiceRecord 
            {
                VehicleId = vehicleId,
                ServiceTypeId = serviceTypeId1,
                DateLastServiced = DateTime.UtcNow.AddMonths(-3),
                MileageLastService = 15000,
                CostLastService = 40,
                ShopName = "Quick Lube",
                Notes = "Changed oil and filter"
            },
            new ServiceRecord 
            {
                VehicleId = vehicleId,
                ServiceTypeId = serviceTypeId2,
                DateLastServiced = DateTime.UtcNow.AddMonths(-1),
                MileageLastService = 15500,
                CostLastService = 55,
                ShopName = "Tire Shop",
                Notes = "Rotated tires"
            }
        );
    }
}
