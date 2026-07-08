using LabReferenceApi.Models.Enums;

namespace LabReferenceApi.Models.Dtos;

public class LabResultResponse
{
    public string TestName { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public ReferenceRangeDto? ReferenceRange { get; set; }
    public Flag? Flag { get; set; }
    public Severity? Severity { get; set; }
    public string? ClinicalContext { get; set; }
    public string Interpretation { get; set; } = string.Empty;
}

public class BatchLabResultResponse
{
    public string? PatientSex { get; set; }
    public int? PatientAge { get; set; }
    public IEnumerable<LabResultResponse> Results { get; set; } = [];
}

public class ReferenceRangeDto
{
    public decimal Min { get; set; }
    public decimal Max { get; set; }
    public string Unit { get; set; } = string.Empty;
}
