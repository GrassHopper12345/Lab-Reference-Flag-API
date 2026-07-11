using LabReferenceApi.Models.Dtos;
using LabReferenceApi.Validators;

namespace LabReferenceApi.Tests.Validators;

public class BatchLabResultRequestValidatorTests
{
    private readonly BatchLabResultRequestValidator _validator = new();

    private static BatchLabResultRequest Valid() => new()
    {
        PatientSex = "male",
        PatientAge = 45,
        Results =
        [
            new LabResultItem { TestName = "WBC", Value = 7.0m, Unit = "10^3/uL" },
            new LabResultItem { TestName = "Hemoglobin", Value = 14.5m, Unit = "g/dL" },
        ]
    };

    [Fact]
    public void Validate_ValidRequest_Passes()
    {
        var result = _validator.Validate(Valid());
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_EmptyResults_Fails()
    {
        var request = Valid();
        request.Results = [];
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "Results");
    }

    [Fact]
    public void Validate_Over100Items_Fails()
    {
        var request = Valid();
        request.Results = Enumerable.Range(0, 101)
            .Select(i => new LabResultItem { TestName = $"Test{i}", Value = 1m, Unit = "U/L" });
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "Results");
    }

    [Fact]
    public void Validate_ItemWithMissingTestName_Fails()
    {
        var request = Valid();
        request.Results =
        [
            new LabResultItem { TestName = "", Value = 7.0m, Unit = "10^3/uL" }
        ];
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_ItemWithNegativeValue_Fails()
    {
        var request = Valid();
        request.Results =
        [
            new LabResultItem { TestName = "WBC", Value = -5m, Unit = "10^3/uL" }
        ];
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Validate_InvalidSex_Fails()
    {
        var request = Valid();
        request.PatientSex = "other";
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "PatientSex");
    }

    [Fact]
    public void Validate_NullSexAndAge_Passes()
    {
        var request = Valid();
        request.PatientSex = null;
        request.PatientAge = null;
        var result = _validator.Validate(request);
        Assert.True(result.IsValid);
    }
}
