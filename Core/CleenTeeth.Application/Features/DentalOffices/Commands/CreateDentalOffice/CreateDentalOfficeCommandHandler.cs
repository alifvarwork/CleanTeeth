using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommandHandler(IDentalOfficeRepository repository,
    IUnitOfWork unitOfWork):IRequestHandler<CreateDentalOfficeCommand, Guid>
{
    public async Task<Guid> Handle(CreateDentalOfficeCommand command)
    {

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
