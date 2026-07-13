using LabReferenceApi.Data;
using LabReferenceApi.Models;
using LabReferenceApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabReferenceApi.Controllers;

[ApiController]
[Route("api/biomarkers")]
public class BiomarkersController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    [EndpointSummary("List all supported biomarkers")]
    [EndpointDescription("Returns all biomarkers in the reference database, grouped by panel.")]
    [ProducesResponseType(typeof(IEnumerable<Biomarker>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var biomarkers = await db.Biomarkers
            .Include(b => b.ReferenceRanges)
            .OrderBy(b => b.Panel)
            .ThenBy(b => b.Name)
            .ToListAsync();

        return Ok(biomarkers);
    }

    [HttpGet("{name}")]
    [EndpointSummary("Get a single biomarker by name")]
    [EndpointDescription("Returns the reference range(s) and clinical context for the specified biomarker. Lookup is case-insensitive.")]
    [ProducesResponseType(typeof(Biomarker), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByName(string name)
    {
        var biomarker = await db.Biomarkers
            .Include(b => b.ReferenceRanges)
            .FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());

        if (biomarker is null)
            return NotFound(new ProblemDetails
            {
                Title = "Biomarker not found.",
                Detail = $"'{name}' is not in the reference database.",
                Status = StatusCodes.Status404NotFound
            });

        return Ok(biomarker);
    }

    [HttpPost]
    [EndpointSummary("Add a new biomarker (admin)")]
    [EndpointDescription("Creates a new biomarker entry with an initial reference range. Authentication not yet implemented — see roadmap.")]
    [ProducesResponseType(typeof(Biomarker), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create(CreateBiomarkerRequest request)
    {
        var exists = await db.Biomarkers.AnyAsync(b => b.Name.ToLower() == request.Name.ToLower());
        if (exists)
            return Conflict(new ProblemDetails
            {
                Title = "Biomarker already exists.",
                Detail = $"A biomarker named '{request.Name}' already exists.",
                Status = StatusCodes.Status409Conflict
            });

        var biomarker = new Biomarker
        {
            Name = request.Name,
            DisplayName = request.DisplayName,
            Panel = request.Panel,
            ClinicalContext = request.ClinicalContext,
            ReferenceRanges =
            [
                new ReferenceRange
                {
                    LowNormal = request.InitialRange.LowNormal,
                    HighNormal = request.InitialRange.HighNormal,
                    CriticalLow = request.InitialRange.CriticalLow,
                    CriticalHigh = request.InitialRange.CriticalHigh,
                    Unit = request.InitialRange.Unit,
                    SexFilter = request.InitialRange.SexFilter,
                    MinAge = request.InitialRange.MinAge,
                    MaxAge = request.InitialRange.MaxAge,
                    SiConversionFactor = request.InitialRange.SiConversionFactor,
                    SiUnit = request.InitialRange.SiUnit
                }
            ]
        };

        db.Biomarkers.Add(biomarker);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetByName), new { name = biomarker.Name }, biomarker);
    }

    [HttpPut("{id:int}")]
    [EndpointSummary("Update a biomarker (admin)")]
    [EndpointDescription("Updates the display name and/or clinical context for an existing biomarker. Authentication not yet implemented — see roadmap.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, UpdateBiomarkerRequest request)
    {
        var biomarker = await db.Biomarkers.FindAsync(id);

        if (biomarker is null)
            return NotFound(new ProblemDetails
            {
                Title = "Biomarker not found.",
                Detail = $"No biomarker with id {id} exists.",
                Status = StatusCodes.Status404NotFound
            });

        if (request.DisplayName is not null)
            biomarker.DisplayName = request.DisplayName;

        if (request.ClinicalContext is not null)
            biomarker.ClinicalContext = request.ClinicalContext;

        await db.SaveChangesAsync();
        return NoContent();
    }
}
