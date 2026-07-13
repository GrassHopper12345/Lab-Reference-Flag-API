using LabReferenceApi.Models.Dtos;
using LabReferenceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabReferenceApi.Controllers;

[ApiController]
[Route("api/results")]
public class ResultsController(IInterpretationService interpretationService) : ControllerBase
{
    [HttpPost("interpret")]
    [EndpointSummary("Interpret a single lab result")]
    [EndpointDescription(
        "Accepts a test name, numeric value, and unit. Returns the standard reference range, " +
        "a flag (Low/Normal/High/Critical), severity, and clinical context. " +
        "PatientSex and PatientAge are optional but required for sex- or age-specific reference ranges.")]
    [ProducesResponseType(typeof(LabResultResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Interpret(LabResultRequest request)
    {
        var result = await interpretationService.InterpretAsync(request);

        if (result.Flag is null && result.ReferenceRange is null)
        {
            if (result.Interpretation.Contains("not found"))
                return NotFound(new ProblemDetails
                {
                    Title = "Biomarker not found.",
                    Detail = $"'{request.TestName}' is not in the reference database.",
                    Status = StatusCodes.Status404NotFound
                });

            // Biomarker exists but no range matched the demographics
            return Ok(result);
        }

        return Ok(result);
    }

    [HttpPost("interpret/batch")]
    [EndpointSummary("Interpret a full lab panel")]
    [EndpointDescription(
        "Accepts multiple lab results in a single request. PatientSex and PatientAge apply to all items. " +
        "Always returns 200 — unknown biomarkers within the batch receive a null flag rather than failing the whole request.")]
    [ProducesResponseType(typeof(BatchLabResultResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InterpretBatch(BatchLabResultRequest request)
    {
        var result = await interpretationService.InterpretBatchAsync(request);
        return Ok(result);
    }
}
