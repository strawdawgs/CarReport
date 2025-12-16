namespace DataModelLibrary.Models;
public class TireRecord
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public DateTime DateLastServiced { get; set; }
    public int MileageLastServiced { get; set; }
    public string Position { get; set; } = "All"; // FL/FR/RL/RR/All/etc.
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? TireSize { get; set; }
    public decimal? TreadDepth32nds { get; set; } // e.g. 9.0, 4.0
    public decimal? PressurePsi { get; set; }
    public decimal? CostPerTire { get; set; }
    public string? ShopName { get; set; }
    public string? Notes { get; set; }
}
