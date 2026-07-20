using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Exceptions;
using CleenTeeth.Application.Utilities;
using FluentValidation;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository,
    IUnitOfWork unitOfWork,
    IValidator<CreateDentalOfficeCommand> validator):IRequestHandler<CreateDentalOfficeCommand, Guid>
{
    public async Task<Guid> Handle(CreateDentalOfficeCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new CustomValidationException(validationResult);
        }

        var dentalOffice = new DentalOffice(command.Name);

        try
        {
            var result = await repository.Add(dentalOffice);
            await unitOfWork.Commit();
            return result.Id;
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }

    }
}
