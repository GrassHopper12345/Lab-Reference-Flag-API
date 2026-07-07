namespace LabReferenceApi.Models;

public class Biomarker
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Panel { get; set; } = string.Empty;
    public string ClinicalContext { get; set; } = string.Empty;
    public ICollection<ReferenceRange> ReferenceRanges { get; set; } = [];
}
