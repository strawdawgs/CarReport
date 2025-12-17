namespace DataModelLibrary.Models;

public class ServiceType
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string? RecommendedIntervalInMiles { get; set; }
    public string? RecommendedIntervalInYears { get; set; }
    public ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();
}
