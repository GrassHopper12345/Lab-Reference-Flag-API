using LabReferenceApi.Models;

namespace LabReferenceApi.Services;

public interface IUnitConversionService
{
    /// <summary>
    /// Converts a submitted value to the canonical unit stored in the reference range.
    /// Returns the original value if the unit is already canonical or cannot be converted.
    /// </summary>
    decimal ConvertToCanonical(decimal value, string fromUnit, ReferenceRange range);

    /// <summary>
    /// Returns true if the submitted unit is recognized as compatible with the range
    /// (canonical, SI equivalent, or a known alias).
    /// </summary>
    bool IsCompatibleUnit(string unit, ReferenceRange range);
}
