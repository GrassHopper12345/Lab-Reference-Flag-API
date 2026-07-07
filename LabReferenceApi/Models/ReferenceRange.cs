namespace LabReferenceApi.Models;

public class ReferenceRange
{
    public int Id { get; set; }
    public int BiomarkerId { get; set; }
    public Biomarker Biomarker { get; set; } = null!;

    // Null = applies to all
    public string? SexFilter { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }

    public decimal LowNormal { get; set; }
    public decimal HighNormal { get; set; }
    public decimal? CriticalLow { get; set; }
    public decimal? CriticalHigh { get; set; }
    public string Unit { get; set; } = string.Empty;

    public decimal? SiConversionFactor { get; set; }
    public string? SiUnit { get; set; }
}
