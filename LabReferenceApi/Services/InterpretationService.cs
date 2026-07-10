using LabReferenceApi.Data;
using LabReferenceApi.Models;
using LabReferenceApi.Models.Dtos;
using LabReferenceApi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace LabReferenceApi.Services;

public class InterpretationService(
    AppDbContext db,
    IUnitConversionService unitConversion,
    ILogger<InterpretationService> logger) : IInterpretationService
{
    public async Task<LabResultResponse> InterpretAsync(LabResultRequest request)
    {
        var biomarker = await db.Biomarkers
            .Include(b => b.ReferenceRanges)
            .FirstOrDefaultAsync(b => b.Name.ToLower() == request.TestName.ToLower());

        if (biomarker is null)
        {
            logger.LogWarning("Biomarker '{TestName}' not found in reference database.", request.TestName);
            return new LabResultResponse
            {
                TestName = request.TestName,
                Value = request.Value,
                Unit = request.Unit,
                Interpretation = "Biomarker not found in reference database."
            };
        }

        var range = SelectRange(biomarker.ReferenceRanges, request.PatientSex, request.PatientAge);

        if (range is null)
        {
            return new LabResultResponse
            {
                TestName = request.TestName,
                Value = request.Value,
                Unit = request.Unit,
                ClinicalContext = biomarker.ClinicalContext,
                Interpretation = "No reference range found for the provided patient demographics."
            };
        }

        var canonicalValue = unitConversion.ConvertToCanonical(request.Value, request.Unit, range);
        var (flag, severity) = ComputeFlag(canonicalValue, range);
        var interpretation = BuildInterpretation(flag, range, request.PatientSex);

        logger.LogInformation(
            "Interpreted {TestName}: value={Value} {Unit} → flag={Flag} (age={Age}, sex={Sex})",
            request.TestName, request.Value, request.Unit, flag, request.PatientAge, request.PatientSex);

        return new LabResultResponse
        {
            TestName = biomarker.DisplayName,
            Value = request.Value,
            Unit = request.Unit,
            ReferenceRange = new ReferenceRangeDto
            {
                Min = range.LowNormal,
                Max = range.HighNormal,
                Unit = range.Unit
            },
            Flag = flag,
            Severity = severity,
            ClinicalContext = biomarker.ClinicalContext,
            Interpretation = interpretation
        };
    }

    public async Task<BatchLabResultResponse> InterpretBatchAsync(BatchLabResultRequest request)
    {
        // Load all relevant biomarkers in one query to avoid N+1
        var testNames = request.Results.Select(r => r.TestName.ToLower()).ToList();

        var biomarkers = await db.Biomarkers
            .Include(b => b.ReferenceRanges)
            .Where(b => testNames.Contains(b.Name.ToLower()))
            .ToListAsync();

        var biomarkerLookup = biomarkers.ToDictionary(
            b => b.Name.ToLower(),
            b => b,
            StringComparer.OrdinalIgnoreCase);

        var results = new List<LabResultResponse>();

        foreach (var item in request.Results)
        {
            var singleRequest = new LabResultRequest
            {
                TestName = item.TestName,
                Value = item.Value,
                Unit = item.Unit,
                PatientSex = request.PatientSex,
                PatientAge = request.PatientAge
            };

            if (!biomarkerLookup.TryGetValue(item.TestName, out var biomarker))
            {
                logger.LogWarning("Batch: biomarker '{TestName}' not found.", item.TestName);
                results.Add(new LabResultResponse
                {
                    TestName = item.TestName,
                    Value = item.Value,
                    Unit = item.Unit,
                    Interpretation = "Biomarker not found in reference database."
                });
                continue;
            }

            var range = SelectRange(biomarker.ReferenceRanges, request.PatientSex, request.PatientAge);

            if (range is null)
            {
                results.Add(new LabResultResponse
                {
                    TestName = item.TestName,
                    Value = item.Value,
                    Unit = item.Unit,
                    ClinicalContext = biomarker.ClinicalContext,
                    Interpretation = "No reference range found for the provided patient demographics."
                });
                continue;
            }

            var canonicalValue = unitConversion.ConvertToCanonical(item.Value, item.Unit, range);
            var (flag, severity) = ComputeFlag(canonicalValue, range);

            results.Add(new LabResultResponse
            {
                TestName = biomarker.DisplayName,
                Value = item.Value,
                Unit = item.Unit,
                ReferenceRange = new ReferenceRangeDto
                {
                    Min = range.LowNormal,
                    Max = range.HighNormal,
                    Unit = range.Unit
                },
                Flag = flag,
                Severity = severity,
                ClinicalContext = biomarker.ClinicalContext,
                Interpretation = BuildInterpretation(flag, range, request.PatientSex)
            });
        }

        return new BatchLabResultResponse
        {
            PatientSex = request.PatientSex,
            PatientAge = request.PatientAge,
            Results = results
        };
    }

    // Most-specific match wins: sex+age > sex-only > age-only > universal
    private static ReferenceRange? SelectRange(
        IEnumerable<ReferenceRange> ranges, string? sex, int? age)
    {
        var candidates = ranges
            .Where(r => r.SexFilter is null || string.Equals(r.SexFilter, sex, StringComparison.OrdinalIgnoreCase))
            .Where(r => r.MinAge is null || age is null || r.MinAge <= age)
            .Where(r => r.MaxAge is null || age is null || r.MaxAge > age)
            .ToList();

        return candidates
            .OrderByDescending(r => (r.SexFilter is not null ? 2 : 0) + (r.MinAge is not null || r.MaxAge is not null ? 1 : 0))
            .FirstOrDefault();
    }

    // Boundary rules: <= / >= for critical thresholds; strict < / > for low/high
    private static (Flag flag, Severity severity) ComputeFlag(decimal value, ReferenceRange range)
    {
        if (range.CriticalLow.HasValue && value <= range.CriticalLow.Value)
            return (Flag.Critical, Severity.Critical);

        if (range.CriticalHigh.HasValue && value >= range.CriticalHigh.Value)
            return (Flag.Critical, Severity.Critical);

        if (value < range.LowNormal)
            return (Flag.Low, Severity.Abnormal);

        if (value > range.HighNormal)
            return (Flag.High, Severity.Abnormal);

        return (Flag.Normal, Severity.Normal);
    }

    private static string BuildInterpretation(Flag flag, ReferenceRange range, string? sex)
    {
        var demographicContext = range.SexFilter is not null && sex is not null
            ? $" for adult {sex}s"
            : string.Empty;

        return flag switch
        {
            Flag.Normal   => $"Value is within the reference range{demographicContext}.",
            Flag.Low      => $"Value is below the reference range{demographicContext}.",
            Flag.High     => $"Value is above the reference range{demographicContext}.",
            Flag.Critical => "Value is at a critically abnormal level. Immediate clinical review is warranted.",
            _             => "Unable to interpret value."
        };
    }
}
