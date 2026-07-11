using LabReferenceApi.Models.Dtos;
using LabReferenceApi.Validators;

namespace LabReferenceApi.Tests.Validators;

public class LabResultRequestValidatorTests
{
    private readonly LabResultRequestValidator _validator = new();

    private static LabResultRequest Valid() => new()
    {
        TestName = "Hemoglobin",
        Value = 14.0m,
        Unit = "g/dL",
        PatientSex = "female",
        PatientAge = 34
    };

    [Fact]
    public void Validate_ValidRequest_Passes()
    {
        var result = _validator.Validate(Valid());
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_MissingTestName_Fails()
    {
        var request = Valid();
        request.TestName = string.Empty;
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "TestName");
    }

    [Fact]
    public void Validate_NegativeValue_Fails()
    {
        var request = Valid();
        request.Value = -1m;
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "Value");
    }

    [Fact]
    public void Validate_MissingUnit_Fails()
    {
        var request = Valid();
        request.Unit = string.Empty;
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "Unit");
    }

    [Fact]
    public void Validate_InvalidSex_Fails()
    {
        var request = Valid();
        request.PatientSex = "unknown";
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "PatientSex");
    }

    [Fact]
    public void Validate_NullSex_Passes()
    {
        var request = Valid();
        request.PatientSex = null;
        var result = _validator.Validate(request);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_AgeTooHigh_Fails()
    {
        var request = Valid();
        request.PatientAge = 150;
        var result = _validator.Validate(request);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "PatientAge");
    }

    [Fact]
    public void Validate_NullAge_Passes()
    {
        var request = Valid();
        request.PatientAge = null;
        var result = _validator.Validate(request);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_ZeroValue_Passes()
    {
        var request = Valid();
        request.Value = 0m;
        var result = _validator.Validate(request);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_SexCaseInsensitive_Passes()
    {
        var request = Valid();
        request.PatientSex = "Male";
        var result = _validator.Validate(request);
        Assert.True(result.IsValid);
    }
}
