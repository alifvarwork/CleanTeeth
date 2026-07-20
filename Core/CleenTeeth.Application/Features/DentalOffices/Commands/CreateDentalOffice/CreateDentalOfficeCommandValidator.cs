using FluentValidation;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

internal class CreateDentalOfficeCommandValidator:AbstractValidator<CreateDentalOfficeCommand>
{
    public CreateDentalOfficeCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required");
    }
}
