namespace LabReferenceApi.Models.Dtos;

public class CreateBiomarkerRequest
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Panel { get; set; } = string.Empty;
    public string ClinicalContext { get; set; } = string.Empty;
    public CreateReferenceRangeRequest InitialRange { get; set; } = new();
}

public class UpdateBiomarkerRequest
{
    public string? DisplayName { get; set; }
    public string? ClinicalContext { get; set; }
}

public class CreateReferenceRangeRequest
{
    public decimal LowNormal { get; set; }
    public decimal HighNormal { get; set; }
    public decimal? CriticalLow { get; set; }
    public decimal? CriticalHigh { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string? SexFilter { get; set; }
    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }
    public decimal? SiConversionFactor { get; set; }
    public string? SiUnit { get; set; }
}
