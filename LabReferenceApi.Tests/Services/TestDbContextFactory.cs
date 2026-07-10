using LabReferenceApi.Data;
using LabReferenceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LabReferenceApi.Tests.Services;

/// <summary>
/// Creates a seeded in-memory AppDbContext for unit testing.
/// Uses a unique DB name per call to ensure test isolation.
/// </summary>
internal static class TestDbContextFactory
{
    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var db = new AppDbContext(options);
        SeedTestData(db);
        return db;
    }

    private static void SeedTestData(AppDbContext db)
    {
        var biomarkers = new List<Biomarker>
        {
            new() { Id = 1, Name = "WBC", DisplayName = "White Blood Cells (WBC)", Panel = "CBC",
                ClinicalContext = "WBC context." },
            new() { Id = 2, Name = "Hemoglobin", DisplayName = "Hemoglobin (Hgb)", Panel = "CBC",
                ClinicalContext = "Hemoglobin context." },
            new() { Id = 3, Name = "TSH", DisplayName = "Thyroid Stimulating Hormone (TSH)", Panel = "Thyroid",
                ClinicalContext = "TSH context." },
            new() { Id = 4, Name = "Glucose", DisplayName = "Glucose (fasting)", Panel = "CMP",
                ClinicalContext = "Glucose context." },
            new() { Id = 5, Name = "Potassium", DisplayName = "Potassium (K)", Panel = "CMP",
                ClinicalContext = "Potassium context." },
        };

        var ranges = new List<ReferenceRange>
        {
            // WBC — universal
            new() { Id = 1, BiomarkerId = 1,
                LowNormal = 4.5m, HighNormal = 11.0m, CriticalLow = 2.0m, CriticalHigh = 30.0m,
                Unit = "10^3/uL", SiConversionFactor = 1.0m, SiUnit = "10^9/L" },

            // Hemoglobin — sex-specific
            new() { Id = 2, BiomarkerId = 2, SexFilter = "male", MinAge = 18,
                LowNormal = 13.5m, HighNormal = 17.5m, CriticalLow = 7.0m, CriticalHigh = 20.0m,
                Unit = "g/dL", SiConversionFactor = 10.0m, SiUnit = "g/L" },
            new() { Id = 3, BiomarkerId = 2, SexFilter = "female", MinAge = 18,
                LowNormal = 12.0m, HighNormal = 16.0m, CriticalLow = 7.0m, CriticalHigh = 20.0m,
                Unit = "g/dL", SiConversionFactor = 10.0m, SiUnit = "g/L" },

            // TSH — age-stratified
            new() { Id = 4, BiomarkerId = 3, MinAge = 18, MaxAge = 60,
                LowNormal = 0.4m, HighNormal = 4.0m, CriticalLow = 0.1m, CriticalHigh = 10.0m,
                Unit = "mIU/L" },
            new() { Id = 5, BiomarkerId = 3, MinAge = 60,
                LowNormal = 0.4m, HighNormal = 5.5m, CriticalLow = 0.1m, CriticalHigh = 10.0m,
                Unit = "mIU/L" },

            // Glucose — universal, with critical thresholds
            new() { Id = 6, BiomarkerId = 4,
                LowNormal = 70.0m, HighNormal = 99.0m, CriticalLow = 40.0m, CriticalHigh = 500.0m,
                Unit = "mg/dL", SiConversionFactor = 0.05551m, SiUnit = "mmol/L" },

            // Potassium — universal, with critical thresholds
            new() { Id = 7, BiomarkerId = 5,
                LowNormal = 3.5m, HighNormal = 5.1m, CriticalLow = 2.5m, CriticalHigh = 6.5m,
                Unit = "mEq/L", SiConversionFactor = 1.0m, SiUnit = "mmol/L" },
        };

        db.Biomarkers.AddRange(biomarkers);
        db.ReferenceRanges.AddRange(ranges);
        db.SaveChanges();
    }
}
