namespace DataModelLibrary.Models;

public class ServiceRecord
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public string ServiceType { get; set; } = string.Empty;
    public DateTime DateLastServiced { get; set; }
    public int MileageLastService { get; set; }
    public string? RecommendedInterval { get; set; }
    public string? NextDueMileage { get; set; }
    public DateTime NextDueDate { get; set; }
    public decimal CostLastService { get; set; }
    public string? ShopName { get; set; }
    public string? Notes { get; set; }
}
