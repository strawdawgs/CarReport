namespace DataModelLibrary.Models;

public class ServiceType
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public int? RecommendedIntervalInMilesMinimum { get; set; }
    public int? RecommendedIntervalInMilesMaximum { get; set; }
    public int? RecommendedIntervalInYears { get; set; }
    public ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();
}
