using LabReferenceApi.Models;
using LabReferenceApi.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace LabReferenceApi.Tests.Services;

public class UnitConversionServiceTests
{
    private static UnitConversionService CreateService() =>
        new(NullLogger<UnitConversionService>.Instance);

    private static ReferenceRange HemoglobinRange() => new()
    {
        Unit = "g/dL", SiUnit = "g/L", SiConversionFactor = 10.0m,
        LowNormal = 12.0m, HighNormal = 16.0m
    };

    private static ReferenceRange GlucoseRange() => new()
    {
        Unit = "mg/dL", SiUnit = "mmol/L", SiConversionFactor = 0.05551m,
        LowNormal = 70.0m, HighNormal = 99.0m
    };

    private static ReferenceRange WbcRange() => new()
    {
        Unit = "10^3/uL", SiUnit = "10^9/L", SiConversionFactor = 1.0m,
        LowNormal = 4.5m, HighNormal = 11.0m
    };

    // ── Canonical unit passthrough ───────────────────────────────────────────

    [Fact]
    public void ConvertToCanonical_CanonicalUnit_ReturnsValueUnchanged()
    {
        var service = CreateService();
        var result = service.ConvertToCanonical(14.5m, "g/dL", HemoglobinRange());
        Assert.Equal(14.5m, result);
    }

    [Fact]
    public void ConvertToCanonical_CanonicalUnit_CaseInsensitive()
    {
        var service = CreateService();
        var result = service.ConvertToCanonical(14.5m, "G/DL", HemoglobinRange());
        Assert.Equal(14.5m, result);
    }

    // ── SI unit conversion ───────────────────────────────────────────────────

    [Fact]
    public void ConvertToCanonical_SiUnit_DividesByFactor()
    {
        var service = CreateService();
        // 145 g/L → 145 / 10 = 14.5 g/dL
        var result = service.ConvertToCanonical(145m, "g/L", HemoglobinRange());
        Assert.Equal(14.5m, result);
    }

    [Fact]
    public void ConvertToCanonical_GlucoseSiUnit_ConvertsCorrectly()
    {
        var service = CreateService();
        // 5.0 mmol/L → 5.0 / 0.05551 ≈ 90.1 mg/dL
        var result = service.ConvertToCanonical(5.0m, "mmol/L", GlucoseRange());
        Assert.True(result > 89m && result < 91m, $"Expected ~90 mg/dL but got {result}");
    }

    // ── Unit alias resolution ────────────────────────────────────────────────

    [Fact]
    public void ConvertToCanonical_KnownAlias_ReturnsValueUnchanged()
    {
        var service = CreateService();
        // "K/uL" is an alias for "10^3/uL"
        var result = service.ConvertToCanonical(7.5m, "K/uL", WbcRange());
        Assert.Equal(7.5m, result);
    }

    [Fact]
    public void IsCompatibleUnit_CanonicalUnit_ReturnsTrue()
    {
        var service = CreateService();
        Assert.True(service.IsCompatibleUnit("g/dL", HemoglobinRange()));
    }

    [Fact]
    public void IsCompatibleUnit_SiUnit_ReturnsTrue()
    {
        var service = CreateService();
        Assert.True(service.IsCompatibleUnit("g/L", HemoglobinRange()));
    }

    [Fact]
    public void IsCompatibleUnit_KnownAlias_ReturnsTrue()
    {
        var service = CreateService();
        Assert.True(service.IsCompatibleUnit("K/uL", WbcRange()));
    }

    [Fact]
    public void IsCompatibleUnit_UnknownUnit_ReturnsFalse()
    {
        var service = CreateService();
        Assert.False(service.IsCompatibleUnit("stones", HemoglobinRange()));
    }

    // ── Unrecognized unit fallback ───────────────────────────────────────────

    [Fact]
    public void ConvertToCanonical_UnknownUnit_ReturnsValueAsIs()
    {
        var service = CreateService();
        // Unknown unit — should return value unchanged (and log a warning)
        var result = service.ConvertToCanonical(14.5m, "furlong/fortnight", HemoglobinRange());
        Assert.Equal(14.5m, result);
    }
}
