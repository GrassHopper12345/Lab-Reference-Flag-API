using LabReferenceApi.Models;

namespace LabReferenceApi.Data.Seed;

// SiConversionFactor: divide the SI value by this factor to get the canonical (US) value
//   e.g. Hemoglobin: g/L (SI) / 10 = g/dL (canonical)
//   e.g. Glucose:    mmol/L (SI) / 0.05551 ≈ mg/dL (canonical)
//   e.g. Creatinine: umol/L (SI) / 88.4 = mg/dL (canonical)
//
// ID Registry
// CBC:               1–12
// CMP:               13–29
// Lipid Panel:       30–35
// Thyroid:           36–39
// Inflammatory:      40–44
// Vitamins/Minerals: 45–52

public static class ReferenceRangeSeedData
{
    public static ReferenceRange[] GetReferenceRanges() =>
    [
        // ── CBC ─────────────────────────────────────────────────────────────

        // WBC — universal
        new ReferenceRange
        {
            Id = 1, BiomarkerId = 1,
            LowNormal = 4.5m, HighNormal = 11.0m, CriticalLow = 2.0m, CriticalHigh = 30.0m,
            Unit = "10^3/uL", SiConversionFactor = 1.0m, SiUnit = "10^9/L"
        },

        // RBC — sex-specific
        new ReferenceRange
        {
            Id = 2, BiomarkerId = 2, SexFilter = "male", MinAge = 18,
            LowNormal = 4.5m, HighNormal = 5.9m, CriticalLow = 2.5m, CriticalHigh = 7.0m,
            Unit = "10^6/uL", SiConversionFactor = 1.0m, SiUnit = "10^12/L"
        },
        new ReferenceRange
        {
            Id = 3, BiomarkerId = 2, SexFilter = "female", MinAge = 18,
            LowNormal = 4.0m, HighNormal = 5.2m, CriticalLow = 2.5m, CriticalHigh = 7.0m,
            Unit = "10^6/uL", SiConversionFactor = 1.0m, SiUnit = "10^12/L"
        },

        // Hemoglobin — sex-specific
        new ReferenceRange
        {
            Id = 4, BiomarkerId = 3, SexFilter = "male", MinAge = 18,
            LowNormal = 13.5m, HighNormal = 17.5m, CriticalLow = 7.0m, CriticalHigh = 20.0m,
            Unit = "g/dL", SiConversionFactor = 10.0m, SiUnit = "g/L"
        },
        new ReferenceRange
        {
            Id = 5, BiomarkerId = 3, SexFilter = "female", MinAge = 18,
            LowNormal = 12.0m, HighNormal = 16.0m, CriticalLow = 7.0m, CriticalHigh = 20.0m,
            Unit = "g/dL", SiConversionFactor = 10.0m, SiUnit = "g/L"
        },

        // Hematocrit — sex-specific
        new ReferenceRange
        {
            Id = 6, BiomarkerId = 4, SexFilter = "male", MinAge = 18,
            LowNormal = 41.0m, HighNormal = 53.0m, CriticalLow = 21.0m, CriticalHigh = 60.0m,
            Unit = "%"
        },
        new ReferenceRange
        {
            Id = 7, BiomarkerId = 4, SexFilter = "female", MinAge = 18,
            LowNormal = 36.0m, HighNormal = 46.0m, CriticalLow = 21.0m, CriticalHigh = 60.0m,
            Unit = "%"
        },

        // Platelets — universal
        new ReferenceRange
        {
            Id = 8, BiomarkerId = 5,
            LowNormal = 150.0m, HighNormal = 400.0m, CriticalLow = 50.0m, CriticalHigh = 1000.0m,
            Unit = "10^3/uL", SiConversionFactor = 1.0m, SiUnit = "10^9/L"
        },

        // MCV — universal
        new ReferenceRange
        {
            Id = 9, BiomarkerId = 6,
            LowNormal = 80.0m, HighNormal = 100.0m,
            Unit = "fL"
        },

        // MCH — universal
        new ReferenceRange
        {
            Id = 10, BiomarkerId = 7,
            LowNormal = 27.0m, HighNormal = 33.0m,
            Unit = "pg"
        },

        // MCHC — universal
        new ReferenceRange
        {
            Id = 11, BiomarkerId = 8,
            LowNormal = 32.0m, HighNormal = 36.0m, CriticalHigh = 38.0m,
            Unit = "g/dL"
        },

        // RDW — universal
        new ReferenceRange
        {
            Id = 12, BiomarkerId = 9,
            LowNormal = 11.5m, HighNormal = 14.5m,
            Unit = "%"
        },

        // ── CMP ─────────────────────────────────────────────────────────────

        // Sodium — universal
        new ReferenceRange
        {
            Id = 13, BiomarkerId = 10,
            LowNormal = 136.0m, HighNormal = 145.0m, CriticalLow = 120.0m, CriticalHigh = 160.0m,
            Unit = "mEq/L", SiConversionFactor = 1.0m, SiUnit = "mmol/L"
        },

        // Potassium — universal
        new ReferenceRange
        {
            Id = 14, BiomarkerId = 11,
            LowNormal = 3.5m, HighNormal = 5.1m, CriticalLow = 2.5m, CriticalHigh = 6.5m,
            Unit = "mEq/L", SiConversionFactor = 1.0m, SiUnit = "mmol/L"
        },

        // Chloride — universal
        new ReferenceRange
        {
            Id = 15, BiomarkerId = 12,
            LowNormal = 98.0m, HighNormal = 107.0m, CriticalLow = 80.0m, CriticalHigh = 120.0m,
            Unit = "mEq/L", SiConversionFactor = 1.0m, SiUnit = "mmol/L"
        },

        // CO2 / Bicarbonate — universal
        new ReferenceRange
        {
            Id = 16, BiomarkerId = 13,
            LowNormal = 22.0m, HighNormal = 29.0m, CriticalLow = 10.0m, CriticalHigh = 40.0m,
            Unit = "mEq/L", SiConversionFactor = 1.0m, SiUnit = "mmol/L"
        },

        // Calcium — universal
        new ReferenceRange
        {
            Id = 17, BiomarkerId = 14,
            LowNormal = 8.5m, HighNormal = 10.5m, CriticalLow = 7.0m, CriticalHigh = 13.0m,
            Unit = "mg/dL", SiConversionFactor = 0.25m, SiUnit = "mmol/L"
        },

        // BUN — universal
        new ReferenceRange
        {
            Id = 18, BiomarkerId = 15,
            LowNormal = 7.0m, HighNormal = 20.0m, CriticalHigh = 100.0m,
            Unit = "mg/dL", SiConversionFactor = 0.357m, SiUnit = "mmol/L"
        },

        // Creatinine — sex-specific
        new ReferenceRange
        {
            Id = 19, BiomarkerId = 16, SexFilter = "male", MinAge = 18,
            LowNormal = 0.7m, HighNormal = 1.3m, CriticalHigh = 10.0m,
            Unit = "mg/dL", SiConversionFactor = 88.4m, SiUnit = "umol/L"
        },
        new ReferenceRange
        {
            Id = 20, BiomarkerId = 16, SexFilter = "female", MinAge = 18,
            LowNormal = 0.5m, HighNormal = 1.1m, CriticalHigh = 10.0m,
            Unit = "mg/dL", SiConversionFactor = 88.4m, SiUnit = "umol/L"
        },

        // eGFR — universal (lower is worse; HighNormal is a practical ceiling)
        new ReferenceRange
        {
            Id = 21, BiomarkerId = 17,
            LowNormal = 60.0m, HighNormal = 200.0m, CriticalLow = 15.0m,
            Unit = "mL/min/1.73m2"
        },

        // Glucose (fasting) — universal
        new ReferenceRange
        {
            Id = 22, BiomarkerId = 18,
            LowNormal = 70.0m, HighNormal = 99.0m, CriticalLow = 40.0m, CriticalHigh = 500.0m,
            Unit = "mg/dL", SiConversionFactor = 0.05551m, SiUnit = "mmol/L"
        },

        // AST — universal
        new ReferenceRange
        {
            Id = 23, BiomarkerId = 19,
            LowNormal = 10.0m, HighNormal = 40.0m, CriticalHigh = 1000.0m,
            Unit = "U/L"
        },

        // ALT — sex-specific
        new ReferenceRange
        {
            Id = 24, BiomarkerId = 20, SexFilter = "male",
            LowNormal = 7.0m, HighNormal = 56.0m, CriticalHigh = 1000.0m,
            Unit = "U/L"
        },
        new ReferenceRange
        {
            Id = 25, BiomarkerId = 20, SexFilter = "female",
            LowNormal = 7.0m, HighNormal = 45.0m, CriticalHigh = 1000.0m,
            Unit = "U/L"
        },

        // ALP — universal
        new ReferenceRange
        {
            Id = 26, BiomarkerId = 21,
            LowNormal = 44.0m, HighNormal = 147.0m,
            Unit = "U/L"
        },

        // Total Bilirubin — universal
        new ReferenceRange
        {
            Id = 27, BiomarkerId = 22,
            LowNormal = 0.1m, HighNormal = 1.2m, CriticalHigh = 15.0m,
            Unit = "mg/dL", SiConversionFactor = 17.1m, SiUnit = "umol/L"
        },

        // Total Protein — universal
        new ReferenceRange
        {
            Id = 28, BiomarkerId = 23,
            LowNormal = 6.3m, HighNormal = 8.2m,
            Unit = "g/dL", SiConversionFactor = 10.0m, SiUnit = "g/L"
        },

        // Albumin — universal
        new ReferenceRange
        {
            Id = 29, BiomarkerId = 24,
            LowNormal = 3.5m, HighNormal = 5.0m, CriticalLow = 2.0m,
            Unit = "g/dL", SiConversionFactor = 10.0m, SiUnit = "g/L"
        },

        // ── Lipid Panel ──────────────────────────────────────────────────────

        // Total Cholesterol — universal (desirable <200, borderline 200–239, high ≥240)
        new ReferenceRange
        {
            Id = 30, BiomarkerId = 25,
            LowNormal = 0.0m, HighNormal = 200.0m, CriticalHigh = 300.0m,
            Unit = "mg/dL", SiConversionFactor = 0.02586m, SiUnit = "mmol/L"
        },

        // LDL — universal (optimal <100, near optimal 100–129, borderline 130–159, high ≥160)
        new ReferenceRange
        {
            Id = 31, BiomarkerId = 26,
            LowNormal = 0.0m, HighNormal = 130.0m, CriticalHigh = 190.0m,
            Unit = "mg/dL", SiConversionFactor = 0.02586m, SiUnit = "mmol/L"
        },

        // HDL — sex-specific (low HDL is the risk; no critical high)
        new ReferenceRange
        {
            Id = 32, BiomarkerId = 27, SexFilter = "male",
            LowNormal = 40.0m, HighNormal = 200.0m, CriticalLow = 25.0m,
            Unit = "mg/dL", SiConversionFactor = 0.02586m, SiUnit = "mmol/L"
        },
        new ReferenceRange
        {
            Id = 33, BiomarkerId = 27, SexFilter = "female",
            LowNormal = 50.0m, HighNormal = 200.0m, CriticalLow = 25.0m,
            Unit = "mg/dL", SiConversionFactor = 0.02586m, SiUnit = "mmol/L"
        },

        // Triglycerides — universal (normal <150, borderline 150–199, high 200–499, very high ≥500)
        new ReferenceRange
        {
            Id = 34, BiomarkerId = 28,
            LowNormal = 0.0m, HighNormal = 150.0m, CriticalHigh = 500.0m,
            Unit = "mg/dL", SiConversionFactor = 0.01129m, SiUnit = "mmol/L"
        },

        // Non-HDL Cholesterol — universal (desirable <130)
        new ReferenceRange
        {
            Id = 35, BiomarkerId = 29,
            LowNormal = 0.0m, HighNormal = 130.0m,
            Unit = "mg/dL", SiConversionFactor = 0.02586m, SiUnit = "mmol/L"
        },

        // ── Thyroid ──────────────────────────────────────────────────────────

        // TSH — age-stratified (upper limit rises modestly in adults ≥60)
        new ReferenceRange
        {
            Id = 36, BiomarkerId = 30, MinAge = 18, MaxAge = 60,
            LowNormal = 0.4m, HighNormal = 4.0m, CriticalLow = 0.1m, CriticalHigh = 10.0m,
            Unit = "mIU/L"
        },
        new ReferenceRange
        {
            Id = 37, BiomarkerId = 30, MinAge = 60,
            LowNormal = 0.4m, HighNormal = 5.5m, CriticalLow = 0.1m, CriticalHigh = 10.0m,
            Unit = "mIU/L"
        },

        // Free T3 — universal
        new ReferenceRange
        {
            Id = 38, BiomarkerId = 31,
            LowNormal = 2.3m, HighNormal = 4.2m,
            Unit = "pg/mL", SiConversionFactor = 1.536m, SiUnit = "pmol/L"
        },

        // Free T4 — universal
        new ReferenceRange
        {
            Id = 39, BiomarkerId = 32,
            LowNormal = 0.8m, HighNormal = 1.8m,
            Unit = "ng/dL", SiConversionFactor = 12.87m, SiUnit = "pmol/L"
        },

        // ── Inflammatory Markers ─────────────────────────────────────────────

        // CRP (high-sensitivity) — universal
        new ReferenceRange
        {
            Id = 40, BiomarkerId = 33,
            LowNormal = 0.0m, HighNormal = 1.0m, CriticalHigh = 100.0m,
            Unit = "mg/L"
        },

        // ESR — sex-specific (Westergren method)
        new ReferenceRange
        {
            Id = 41, BiomarkerId = 34, SexFilter = "male",
            LowNormal = 0.0m, HighNormal = 15.0m,
            Unit = "mm/hr"
        },
        new ReferenceRange
        {
            Id = 42, BiomarkerId = 34, SexFilter = "female",
            LowNormal = 0.0m, HighNormal = 20.0m,
            Unit = "mm/hr"
        },

        // Ferritin — sex-specific
        new ReferenceRange
        {
            Id = 43, BiomarkerId = 35, SexFilter = "male",
            LowNormal = 24.0m, HighNormal = 336.0m, CriticalLow = 10.0m,
            Unit = "ng/mL"
        },
        new ReferenceRange
        {
            Id = 44, BiomarkerId = 35, SexFilter = "female",
            LowNormal = 11.0m, HighNormal = 307.0m, CriticalLow = 10.0m,
            Unit = "ng/mL"
        },

        // ── Vitamins & Minerals ──────────────────────────────────────────────

        // Vitamin D (25-OH) — universal
        new ReferenceRange
        {
            Id = 45, BiomarkerId = 36,
            LowNormal = 30.0m, HighNormal = 100.0m, CriticalLow = 10.0m, CriticalHigh = 150.0m,
            Unit = "ng/mL", SiConversionFactor = 0.4m, SiUnit = "nmol/L"
        },

        // Vitamin B12 — universal
        new ReferenceRange
        {
            Id = 46, BiomarkerId = 37,
            LowNormal = 200.0m, HighNormal = 900.0m, CriticalLow = 100.0m,
            Unit = "pg/mL", SiConversionFactor = 0.7378m, SiUnit = "pmol/L"
        },

        // Folate — universal
        new ReferenceRange
        {
            Id = 47, BiomarkerId = 38,
            LowNormal = 2.7m, HighNormal = 17.0m, CriticalLow = 2.0m,
            Unit = "ng/mL", SiConversionFactor = 0.4413m, SiUnit = "nmol/L"
        },

        // Iron (serum) — sex-specific
        new ReferenceRange
        {
            Id = 48, BiomarkerId = 39, SexFilter = "male",
            LowNormal = 60.0m, HighNormal = 170.0m, CriticalLow = 20.0m,
            Unit = "mcg/dL", SiConversionFactor = 0.179m, SiUnit = "umol/L"
        },
        new ReferenceRange
        {
            Id = 49, BiomarkerId = 39, SexFilter = "female",
            LowNormal = 37.0m, HighNormal = 145.0m, CriticalLow = 20.0m,
            Unit = "mcg/dL", SiConversionFactor = 0.179m, SiUnit = "umol/L"
        },

        // TIBC — universal
        new ReferenceRange
        {
            Id = 50, BiomarkerId = 40,
            LowNormal = 250.0m, HighNormal = 370.0m,
            Unit = "mcg/dL", SiConversionFactor = 0.179m, SiUnit = "umol/L"
        },

        // Magnesium — universal
        new ReferenceRange
        {
            Id = 51, BiomarkerId = 41,
            LowNormal = 1.7m, HighNormal = 2.2m, CriticalLow = 1.2m, CriticalHigh = 3.5m,
            Unit = "mg/dL", SiConversionFactor = 0.4114m, SiUnit = "mmol/L"
        },

        // Zinc — universal
        new ReferenceRange
        {
            Id = 52, BiomarkerId = 42,
            LowNormal = 60.0m, HighNormal = 120.0m, CriticalLow = 30.0m,
            Unit = "mcg/dL", SiConversionFactor = 0.153m, SiUnit = "umol/L"
        },
    ];
}
