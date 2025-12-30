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
}
