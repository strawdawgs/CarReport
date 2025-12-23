namespace DataModelLibrary.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public int? Year { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Vin { get; set; }
    public string? Notes { get; set; }
    public int? CurrentMileage { get; set; }
    public ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();
    public ICollection<TireRecord> TireRecords { get; set; } = new List<TireRecord>();
}
