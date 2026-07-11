using FluentValidation;
using LabReferenceApi.Models.Dtos;

namespace LabReferenceApi.Validators;

public class CreateBiomarkerRequestValidator : AbstractValidator<CreateBiomarkerRequest>
{
    private static readonly HashSet<string> ValidSexValues =
        new(StringComparer.OrdinalIgnoreCase) { "male", "female" };

    public CreateBiomarkerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.DisplayName)
            .NotEmpty().WithMessage("DisplayName is required.")
            .MaximumLength(150).WithMessage("DisplayName must not exceed 150 characters.");

        RuleFor(x => x.Panel)
            .NotEmpty().WithMessage("Panel is required.")
            .MaximumLength(100).WithMessage("Panel must not exceed 100 characters.");

        RuleFor(x => x.ClinicalContext)
            .NotEmpty().WithMessage("ClinicalContext is required.")
            .MaximumLength(2000).WithMessage("ClinicalContext must not exceed 2000 characters.");

        RuleFor(x => x.InitialRange).SetValidator(new ReferenceRangeRequestValidator());
    }
}

public class ReferenceRangeRequestValidator : AbstractValidator<CreateReferenceRangeRequest>
{
    private static readonly HashSet<string> ValidSexValues =
        new(StringComparer.OrdinalIgnoreCase) { "male", "female" };

    public ReferenceRangeRequestValidator()
    {
        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("Unit is required.")
            .MaximumLength(50).WithMessage("Unit must not exceed 50 characters.");

        RuleFor(x => x.LowNormal)
            .GreaterThanOrEqualTo(0).WithMessage("LowNormal must be non-negative.");

        RuleFor(x => x.HighNormal)
            .GreaterThan(x => x.LowNormal)
            .WithMessage("HighNormal must be greater than LowNormal.");

        RuleFor(x => x.CriticalLow)
            .LessThan(x => x.LowNormal)
            .When(x => x.CriticalLow.HasValue)
            .WithMessage("CriticalLow must be less than LowNormal.");

        RuleFor(x => x.CriticalHigh)
            .GreaterThan(x => x.HighNormal)
            .When(x => x.CriticalHigh.HasValue)
            .WithMessage("CriticalHigh must be greater than HighNormal.");

        RuleFor(x => x.SexFilter)
            .Must(s => s == null || ValidSexValues.Contains(s))
            .WithMessage("SexFilter must be 'male' or 'female' if provided.");

        RuleFor(x => x.MinAge)
            .InclusiveBetween(0, 120)
            .When(x => x.MinAge.HasValue)
            .WithMessage("MinAge must be between 0 and 120.");

        RuleFor(x => x.MaxAge)
            .InclusiveBetween(0, 120)
            .When(x => x.MaxAge.HasValue)
            .WithMessage("MaxAge must be between 0 and 120.");

        RuleFor(x => x.MaxAge)
            .GreaterThan(x => x.MinAge)
            .When(x => x.MinAge.HasValue && x.MaxAge.HasValue)
            .WithMessage("MaxAge must be greater than MinAge.");

        RuleFor(x => x.SiConversionFactor)
            .GreaterThan(0)
            .When(x => x.SiConversionFactor.HasValue)
            .WithMessage("SiConversionFactor must be greater than 0.");
    }
}
