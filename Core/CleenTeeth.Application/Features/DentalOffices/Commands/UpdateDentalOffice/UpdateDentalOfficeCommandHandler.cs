using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;

public class UpdateDentalOfficeCommandHandler(IDentalOfficeRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateDentalOfficeCommand>
{
    public async Task Handle(UpdateDentalOfficeCommand command)
    {

        var dentalOffice = await repository.GetById(command.Id) 
                            ?? throw new InvalidOperationException("Dental office not found.");
        dentalOffice.UpdateName(command.Name);

        try
        {
            await repository.Update(dentalOffice);
            await unitOfWork.Commit();
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }

    }
}
