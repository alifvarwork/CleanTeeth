using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Exceptions;
using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;

public class DeleteDentalOfficeCommandHandler(IDentalOfficeRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDentalOfficeCommand>
{
    public async Task Handle(DeleteDentalOfficeCommand command)
    {

        var dentalOffice = await repository.GetById(command.Id) 
                            ?? throw new NotFoundException("Dental office not found.");

        try
        {
            await repository.Delete(dentalOffice);
            await unitOfWork.Commit();
        }
        catch (Exception)
        {
            await unitOfWork.Rollback();
            throw;
        }

    }
}
