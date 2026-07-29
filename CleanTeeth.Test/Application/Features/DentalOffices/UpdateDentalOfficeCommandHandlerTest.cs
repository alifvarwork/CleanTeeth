using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Exceptions;
using CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Test.Application.Features.DentalOffices;

[TestClass]
public class UpdateDentalOfficeCommandHandlerTest
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private IDentalOfficeRepository repository;
    private IUnitOfWork unitOfWork;
    private UpdateDentalOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = new UpdateDentalOfficeCommandHandler(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeExists_EntityIsUpdatedAndPersisted()
    {

        var dentalOffice = new DentalOffice("Dental Office A");
        var id = dentalOffice.Id;
        
        var command = new UpdateDentalOfficeCommand { Id = id, Name = "Dental Office A" };
        
        repository.GetById(id).Returns(dentalOffice);

        await handler.Handle(command);

        await repository.Received(1).Update(dentalOffice);
        await unitOfWork.Received(1).Commit();
    }

    [TestMethod]
    public async Task Handle_WhenDentalOfficeDoesNotExist_ThrowsNotFoundException()
    {
        var command = new UpdateDentalOfficeCommand { Id = Guid.NewGuid(), Name = "Dental Office A" };

        repository.GetById(command.Id).ReturnsNull<DentalOffice>();

        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command));
    }

    [TestMethod]
    public async Task Handle_WhenThereIsAnError_WeRollback()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        var id = dentalOffice.Id;

        var command = new UpdateDentalOfficeCommand { Id = id, Name = "Dental Office A" };

        repository.GetById(id).Returns(dentalOffice);
        repository.Update(dentalOffice).Throws(new InvalidOperationException("Exception occurred"));

        await Assert.ThrowsAsync<Exception>(() => handler.Handle(command)); 

        await unitOfWork.Received(1).Rollback();
    }

}
