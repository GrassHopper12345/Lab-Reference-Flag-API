using LabReferenceApi.Models.Dtos;
using LabReferenceApi.Models.Enums;
using LabReferenceApi.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace LabReferenceApi.Tests.Services;

public class InterpretationServiceTests
{
    private static InterpretationService CreateService()
    {
        var db = TestDbContextFactory.Create();
        var unitConversion = new UnitConversionService(NullLogger<UnitConversionService>.Instance);
        return new InterpretationService(db, unitConversion, NullLogger<InterpretationService>.Instance);
    }

    // ── Flag computation ────────────────────────────────────────────────────

    [Fact]
    public async Task Interpret_NormalWbc_ReturnsFlagNormal()
    {
        var service = CreateService();
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "WBC", Value = 7.0m, Unit = "10^3/uL"
        });

        Assert.Equal(Flag.Normal, result.Flag);
        Assert.Equal(Severity.Normal, result.Severity);
    }

    [Fact]
    public async Task Interpret_ElevatedWbc_ReturnsFlagHigh()
    {
        var service = CreateService();
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "WBC", Value = 13.5m, Unit = "10^3/uL"
        });

        Assert.Equal(Flag.High, result.Flag);
        Assert.Equal(Severity.Abnormal, result.Severity);
    }

    [Fact]
    public async Task Interpret_CriticallyElevatedWbc_ReturnsFlagCritical()
    {
        var service = CreateService();
        // 30.0 is exactly at CriticalHigh — should be Critical (>=)
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "WBC", Value = 30.0m, Unit = "10^3/uL"
        });

        Assert.Equal(Flag.Critical, result.Flag);
        Assert.Equal(Severity.Critical, result.Severity);
    }

    [Fact]
    public async Task Interpret_CriticallyLowGlucose_ReturnsFlagCritical()
    {
        var service = CreateService();
        // 40.0 is exactly at CriticalLow — should be Critical (<=)
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Glucose", Value = 40.0m, Unit = "mg/dL"
        });

        Assert.Equal(Flag.Critical, result.Flag);
        Assert.Equal(Severity.Critical, result.Severity);
    }

    [Fact]
    public async Task Interpret_ValueExactlyAtLowNormal_ReturnsFlagNormal()
    {
        var service = CreateService();
        // 70.0 is exactly LowNormal for Glucose — strict < means this is Normal
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Glucose", Value = 70.0m, Unit = "mg/dL"
        });

        Assert.Equal(Flag.Normal, result.Flag);
    }

    [Fact]
    public async Task Interpret_ValueJustBelowLowNormal_ReturnsFlagLow()
    {
        var service = CreateService();
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Glucose", Value = 69.9m, Unit = "mg/dL"
        });

        Assert.Equal(Flag.Low, result.Flag);
        Assert.Equal(Severity.Abnormal, result.Severity);
    }

    // ── Sex-specific range selection ─────────────────────────────────────────

    [Fact]
    public async Task Interpret_LowHemoglobin_Female_ReturnsFlagLow()
    {
        var service = CreateService();
        // 10.2 is below female LowNormal (12.0)
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Hemoglobin", Value = 10.2m, Unit = "g/dL",
            PatientSex = "female", PatientAge = 34
        });

        Assert.Equal(Flag.Low, result.Flag);
        Assert.Equal(Severity.Abnormal, result.Severity);
        Assert.Contains("females", result.Interpretation);
    }

    [Fact]
    public async Task Interpret_Hemoglobin_MaleRangeUsedForMale()
    {
        var service = CreateService();
        // 13.5 is exactly LowNormal for males — should be Normal
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Hemoglobin", Value = 13.5m, Unit = "g/dL",
            PatientSex = "male", PatientAge = 30
        });

        Assert.Equal(Flag.Normal, result.Flag);
    }

    [Fact]
    public async Task Interpret_Hemoglobin_FemaleRangeUsedForFemale()
    {
        var service = CreateService();
        // 13.0 is above female HighNormal (16.0)? No — 13.0 is above female LowNormal (12.0)
        // and below HighNormal (16.0) → Normal for female, but 13.0 < male LowNormal (13.5)
        // This confirms the correct female range was selected
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Hemoglobin", Value = 13.0m, Unit = "g/dL",
            PatientSex = "female", PatientAge = 30
        });

        Assert.Equal(Flag.Normal, result.Flag);
    }

    [Fact]
    public async Task Interpret_Hemoglobin_NoDemographics_ReturnsNullFlag()
    {
        var service = CreateService();
        // Hemoglobin has no universal range — sex is required
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Hemoglobin", Value = 14.0m, Unit = "g/dL"
        });

        Assert.Null(result.Flag);
        Assert.Contains("demographics", result.Interpretation);
    }

    // ── Age-stratified range selection ───────────────────────────────────────

    [Fact]
    public async Task Interpret_Tsh_Age30_UsesYoungerAdultRange()
    {
        var service = CreateService();
        // 4.5 is above HighNormal for age 18-60 (4.0) but within 60+ range (5.5)
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "TSH", Value = 4.5m, Unit = "mIU/L", PatientAge = 30
        });

        Assert.Equal(Flag.High, result.Flag);
    }

    [Fact]
    public async Task Interpret_Tsh_Age70_UsesOlderAdultRange()
    {
        var service = CreateService();
        // Same value — 4.5 should be Normal for a 70-year-old
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "TSH", Value = 4.5m, Unit = "mIU/L", PatientAge = 70
        });

        Assert.Equal(Flag.Normal, result.Flag);
    }

    [Fact]
    public async Task Interpret_Tsh_AgeExactly60_UsesOlderAdultRange()
    {
        var service = CreateService();
        // MaxAge = 60 uses exclusive upper bound (r.MaxAge > age), so age=60 falls in the 60+ range
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "TSH", Value = 4.5m, Unit = "mIU/L", PatientAge = 60
        });

        Assert.Equal(Flag.Normal, result.Flag);
    }

    // ── Unknown biomarker ────────────────────────────────────────────────────

    [Fact]
    public async Task Interpret_UnknownBiomarker_ReturnsNullFlagWithMessage()
    {
        var service = CreateService();
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "ProBNP", Value = 500m, Unit = "pg/mL"
        });

        Assert.Null(result.Flag);
        Assert.Null(result.Severity);
        Assert.Contains("not found", result.Interpretation);
    }

    // ── Unit conversion ──────────────────────────────────────────────────────

    [Fact]
    public async Task Interpret_HemoglobinInSiUnit_ConvertsCorrectly()
    {
        var service = CreateService();
        // 102 g/L is the SI equivalent of 10.2 g/dL → should be Low for female
        var result = await service.InterpretAsync(new LabResultRequest
        {
            TestName = "Hemoglobin", Value = 102m, Unit = "g/L",
            PatientSex = "female", PatientAge = 34
        });

        Assert.Equal(Flag.Low, result.Flag);
    }

    // ── Batch interpretation ─────────────────────────────────────────────────

    [Fact]
    public async Task InterpretBatch_MixedResults_ReturnsAllItems()
    {
        var service = CreateService();
        var request = new BatchLabResultRequest
        {
            PatientSex = "male",
            PatientAge = 45,
            Results =
            [
                new LabResultItem { TestName = "WBC", Value = 11.2m, Unit = "10^3/uL" },
                new LabResultItem { TestName = "Hemoglobin", Value = 14.5m, Unit = "g/dL" },
                new LabResultItem { TestName = "ProBNP", Value = 500m, Unit = "pg/mL" },   // unknown
            ]
        };

        var response = await service.InterpretBatchAsync(request);
        var results = response.Results.ToList();

        Assert.Equal(3, results.Count);
        Assert.Equal(Flag.High, results[0].Flag);    // WBC 11.2 > 11.0
        Assert.Equal(Flag.Normal, results[1].Flag);  // Hgb 14.5 normal for male
        Assert.Null(results[2].Flag);                // ProBNP unknown
    }

    [Fact]
    public async Task InterpretBatch_CriticalPotassium_FlaggedCorrectly()
    {
        var service = CreateService();
        var request = new BatchLabResultRequest
        {
            Results =
            [
                new LabResultItem { TestName = "Potassium", Value = 6.5m, Unit = "mEq/L" },
            ]
        };

        var response = await service.InterpretBatchAsync(request);
        var result = response.Results.First();

        Assert.Equal(Flag.Critical, result.Flag);
        Assert.Equal(Severity.Critical, result.Severity);
    }
}
