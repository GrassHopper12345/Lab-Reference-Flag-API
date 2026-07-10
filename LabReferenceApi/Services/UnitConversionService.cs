using LabReferenceApi.Models;

namespace LabReferenceApi.Services;

public class UnitConversionService(ILogger<UnitConversionService> logger) : IUnitConversionService
{
    // Maps canonical units to their known alternate spellings and abbreviations.
    // All keys and values should be lowercase for case-insensitive lookup.
    private static readonly Dictionary<string, string[]> UnitAliases = new(StringComparer.OrdinalIgnoreCase)
    {
        ["g/dL"]          = ["g/dl", "g/100ml", "gm/dl"],
        ["10^3/uL"]       = ["10^3/ul", "k/ul", "k/µl", "thou/µl", "×10³/µl", "x10^3/ul", "10³/µl"],
        ["10^6/uL"]       = ["10^6/ul", "m/ul", "×10⁶/µl", "10⁶/µl"],
        ["mg/dL"]         = ["mg/dl", "mg/100ml"],
        ["mEq/L"]         = ["meq/l", "mmol/l"],   // Na/K/Cl/CO2/Ca mEq/L = mmol/L numerically
        ["mIU/L"]         = ["miu/l", "miu/ml", "µiu/ml", "uiu/ml", "mcu/l"],
        ["pg/mL"]         = ["pg/ml"],
        ["ng/dL"]         = ["ng/dl"],
        ["ng/mL"]         = ["ng/ml", "ug/l"],
        ["mcg/dL"]        = ["mcg/dl", "µg/dl", "ug/dl"],
        ["mL/min/1.73m2"] = ["ml/min/1.73m2", "ml/min/1.73 m2", "ml/min"],
        ["mm/hr"]         = ["mm/h"],
        ["%"]             = ["percent"],
        ["fL"]            = ["fl"],
        ["pg"]            = [],
        ["U/L"]           = ["u/l", "iu/l", "units/l"],
        ["mg/L"]          = ["mg/l"],
    };

    public bool IsCompatibleUnit(string unit, ReferenceRange range)
    {
        if (IsMatch(unit, range.Unit)) return true;
        if (range.SiUnit != null && IsMatch(unit, range.SiUnit)) return true;
        if (IsAlias(unit, range.Unit)) return true;
        return false;
    }

    public decimal ConvertToCanonical(decimal value, string fromUnit, ReferenceRange range)
    {
        // Already in canonical unit
        if (IsMatch(fromUnit, range.Unit) || IsAlias(fromUnit, range.Unit))
            return value;

        // Submitted in SI unit — convert using stored factor
        if (range.SiUnit != null && range.SiConversionFactor.HasValue)
        {
            if (IsMatch(fromUnit, range.SiUnit))
            {
                return value / range.SiConversionFactor.Value;
            }
        }

        // Unit not recognized — log and return as-is
        logger.LogWarning(
            "Unit '{FromUnit}' is not recognized for biomarker with canonical unit '{CanonicalUnit}'. " +
            "Interpreting value as-is.", fromUnit, range.Unit);

        return value;
    }

    private static bool IsMatch(string a, string b) =>
        string.Equals(a, b, StringComparison.OrdinalIgnoreCase);

    private static bool IsAlias(string unit, string canonicalUnit)
    {
        if (!UnitAliases.TryGetValue(canonicalUnit, out var aliases))
            return false;

        return aliases.Any(alias => string.Equals(unit, alias, StringComparison.OrdinalIgnoreCase));
    }
}
