using CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using FluentValidation;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;

internal class UpdateDentalOfficeCommandValidator : AbstractValidator<UpdateDentalOfficeCommand>
{
    public UpdateDentalOfficeCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required");
        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty).WithMessage("The field {PropertyName} is required");
    }
}
