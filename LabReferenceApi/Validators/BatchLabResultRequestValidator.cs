using FluentValidation;
using LabReferenceApi.Models.Dtos;

namespace LabReferenceApi.Validators;

public class BatchLabResultRequestValidator : AbstractValidator<BatchLabResultRequest>
{
    private static readonly HashSet<string> ValidSexValues =
        new(StringComparer.OrdinalIgnoreCase) { "male", "female" };

    public BatchLabResultRequestValidator()
    {
        RuleFor(x => x.PatientSex)
            .Must(s => s == null || ValidSexValues.Contains(s))
            .WithMessage("PatientSex must be 'male' or 'female' if provided.");

        RuleFor(x => x.PatientAge)
            .InclusiveBetween(0, 120)
            .When(x => x.PatientAge.HasValue)
            .WithMessage("PatientAge must be between 0 and 120.");

        RuleFor(x => x.Results)
            .NotNull().WithMessage("Results are required.")
            .Must(r => r.Any()).WithMessage("Results must contain at least one item.")
            .Must(r => r.Count() <= 100).WithMessage("Batch must not exceed 100 items.");

        RuleForEach(x => x.Results).ChildRules(item =>
        {
            item.RuleFor(r => r.TestName)
                .NotEmpty().WithMessage("TestName is required.")
                .MaximumLength(100).WithMessage("TestName must not exceed 100 characters.");

            item.RuleFor(r => r.Value)
                .GreaterThanOrEqualTo(0).WithMessage("Value must be non-negative.");

            item.RuleFor(r => r.Unit)
                .NotEmpty().WithMessage("Unit is required.")
                .MaximumLength(50).WithMessage("Unit must not exceed 50 characters.");
        });
    }
}
