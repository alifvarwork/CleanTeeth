
using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Exceptions;
using CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CleanTeeth.Test.Application.Features.DentalOffices;

[TestClass]
public class GetDentalOfficeQueryHandlerTests
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private IDentalOfficeRepository repository;
    private GetDentalOfficeDetailQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        handler = new GetDentalOfficeDetailQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_DentalOfficeNotFound_ThrowsNotFoundException()
    {
        var dentalOfficeId = Guid.NewGuid();
        repository.GetById(dentalOfficeId).ReturnsNull<DentalOffice>();

        var query = new GetDentalOfficeDetailQuery { Id = dentalOfficeId };

        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query));
    }

    [TestMethod]
    public async Task Handle_ValidQuery_ReturnsDentalOfficeDetailDTO()
    {
        var dentalOffice = new DentalOffice("Dental Office A");
        var dentalOfficeId = dentalOffice.Id;

        var query = new GetDentalOfficeDetailQuery { Id = dentalOfficeId };

        repository.GetById(dentalOfficeId).Returns(dentalOffice);

        var result = await handler.Handle(query);

        Assert.IsNotNull(result);
        Assert.AreEqual(dentalOffice.Id, result.Id);
        Assert.AreEqual(dentalOffice.Name, result.Name);
    }
}
