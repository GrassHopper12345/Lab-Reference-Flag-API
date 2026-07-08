namespace LabReferenceApi.Models.Dtos;

public class LabResultRequest
{
    public string TestName { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string? PatientSex { get; set; }
    public int? PatientAge { get; set; }
}

public class BatchLabResultRequest
{
    public string? PatientSex { get; set; }
    public int? PatientAge { get; set; }
    public IEnumerable<LabResultItem> Results { get; set; } = [];
}

public class LabResultItem
{
    public string TestName { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Unit { get; set; } = string.Empty;
}
