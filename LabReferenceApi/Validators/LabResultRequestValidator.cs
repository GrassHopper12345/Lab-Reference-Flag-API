using FluentValidation;
using LabReferenceApi.Models.Dtos;

namespace LabReferenceApi.Validators;

public class LabResultRequestValidator : AbstractValidator<LabResultRequest>
{
    private static readonly HashSet<string> ValidSexValues =
        new(StringComparer.OrdinalIgnoreCase) { "male", "female" };

    public LabResultRequestValidator()
    {
        RuleFor(x => x.TestName)
            .NotEmpty().WithMessage("TestName is required.")
            .MaximumLength(100).WithMessage("TestName must not exceed 100 characters.");

        RuleFor(x => x.Value)
            .GreaterThanOrEqualTo(0).WithMessage("Value must be non-negative.");

        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("Unit is required.")
            .MaximumLength(50).WithMessage("Unit must not exceed 50 characters.");

        RuleFor(x => x.PatientSex)
            .Must(s => s == null || ValidSexValues.Contains(s))
            .WithMessage("PatientSex must be 'male' or 'female' if provided.");

        RuleFor(x => x.PatientAge)
            .InclusiveBetween(0, 120)
            .When(x => x.PatientAge.HasValue)
            .WithMessage("PatientAge must be between 0 and 120.");
    }
}
