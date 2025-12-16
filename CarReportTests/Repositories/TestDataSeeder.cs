using DataModelLibrary.Models;
using EntityFrameworkAccess.Contexts;

namespace CarReportTests.Repositories;

public class TestDataSeeder
{
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
