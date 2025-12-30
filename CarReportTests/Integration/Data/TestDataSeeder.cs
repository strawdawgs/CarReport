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
}
