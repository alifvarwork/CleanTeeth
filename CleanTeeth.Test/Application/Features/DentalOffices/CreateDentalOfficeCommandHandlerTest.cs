using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace CleanTeeth.Test.Application.Features.DentalOffices;

[TestClass]
public class CreateDentalOfficeCommandHandlerTest
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private IDentalOfficeRepository repository;
    private IUnitOfWork unitOfWork;
    private CreateDentalOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        unitOfWork = Substitute.For<IUnitOfWork>();
        handler = Substitute.For<CreateDentalOfficeCommandHandler>(repository, unitOfWork);
    }

    [TestMethod]
    public async Task Handle_ValidCommand_ReturnsDentalOfficeId()
    {
        var command = new CreateDentalOfficeCommand { Name = "Dental Office A" };

        var dentalOffice = new DentalOffice("Dental Office A");
        repository.Add(Arg.Any<DentalOffice>()).Returns(dentalOffice);

        var result = await handler.Handle(command);

        await repository.Received(1).Add(Arg.Any<DentalOffice>());
        await unitOfWork.Received(1).Commit();
        Assert.AreEqual(dentalOffice.Id, result);
    }

    [TestMethod]
    public async Task Handle_WhenThereIsAnError_WeRollback()
    {
        var command = new CreateDentalOfficeCommand { Name = "Dental Office A" };
        
        repository.Add(Arg.Any<DentalOffice>()).Throws<Exception>();

        await Assert.ThrowsAsync<Exception>(() => handler.Handle(command)); 

        await unitOfWork.Received(1).Rollback();
    }

}
