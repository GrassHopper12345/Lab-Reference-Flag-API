using LabReferenceApi.Models.Dtos;
using LabReferenceApi.Validators;

namespace LabReferenceApi.Tests.Validators;

public class BiomarkerRequestValidatorTests
{
    private readonly CreateBiomarkerRequestValidator _validator = new();

    private static CreateBiomarkerRequest Valid() => new()
    {
        Name = "BNP",
        DisplayName = "B-type Natriuretic Peptide (BNP)",
        Panel = "Cardiac",
        ClinicalContext = "BNP is released by ventricular myocytes in response to increased wall stress.",
        InitialRange = new CreateReferenceRangeRequest
        {
            LowNormal = 0m,
            HighNormal = 100m,
            CriticalHigh = 900m,
            Unit = "pg/mL"
        }
    };

    [Fact]
    public void Validate_ValidRequest_Passes()
    {
        var result = _validator.Validate(Valid());
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_MissingName_Fails()
    {
        var request = Valid();
        request.Name = string.Empty;
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "Name");
    }

    [Fact]
    public void Validate_HighNormalLessThanLowNormal_Fails()
    {
        var request = Valid();
        request.InitialRange.LowNormal = 50m;
        request.InitialRange.HighNormal = 20m;
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("HighNormal"));
    }

    [Fact]
    public void Validate_CriticalLowAboveLowNormal_Fails()
    {
        var request = Valid();
        request.InitialRange.LowNormal = 70m;
        request.InitialRange.HighNormal = 99m;
        request.InitialRange.CriticalLow = 80m; // must be < LowNormal
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("CriticalLow"));
    }

    [Fact]
    public void Validate_CriticalHighBelowHighNormal_Fails()
    {
        var request = Valid();
        request.InitialRange.HighNormal = 100m;
        request.InitialRange.CriticalHigh = 80m; // must be > HighNormal
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("CriticalHigh"));
    }

    [Fact]
    public void Validate_InvalidSexFilter_Fails()
    {
        var request = Valid();
        request.InitialRange.SexFilter = "nonbinary";
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("SexFilter"));
    }

    [Fact]
    public void Validate_MaxAgeLessThanMinAge_Fails()
    {
        var request = Valid();
        request.InitialRange.MinAge = 60;
        request.InitialRange.MaxAge = 40;
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("MaxAge"));
    }

    [Fact]
    public void Validate_NullCriticalThresholds_Passes()
    {
        var request = Valid();
        request.InitialRange.CriticalLow = null;
        request.InitialRange.CriticalHigh = null;
        var result = _validator.Validate(request);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_ZeroSiConversionFactor_Fails()
    {
        var request = Valid();
        request.InitialRange.SiConversionFactor = 0m;
        request.InitialRange.SiUnit = "fmol/L";
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName.Contains("SiConversionFactor"));
    }
}
