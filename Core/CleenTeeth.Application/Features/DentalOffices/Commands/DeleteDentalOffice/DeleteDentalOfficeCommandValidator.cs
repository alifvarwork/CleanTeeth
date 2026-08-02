using CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using FluentValidation;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;

internal class DeleteDentalOfficeCommandValidator : AbstractValidator<DeleteDentalOfficeCommand>
{
    public DeleteDentalOfficeCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty).WithMessage("The field {PropertyName} is required");
    }
}
