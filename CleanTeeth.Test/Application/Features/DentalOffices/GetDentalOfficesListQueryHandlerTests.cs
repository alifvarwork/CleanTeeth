
using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using NSubstitute;

namespace CleanTeeth.Test.Application.Features.DentalOffices;

[TestClass]
public class GetDentalOfficesListQueryHandlerTests
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private IDentalOfficeRepository repository;
    private GetDentalOfficesListQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    [TestInitialize]
    public void Setup()
    {
        repository = Substitute.For<IDentalOfficeRepository>();
        handler = new GetDentalOfficesListQueryHandler(repository);
    }

    [TestMethod]
    public async Task Handle_DentalOfficeNotFound_ThrowsNotFoundException()
    {
        var dentalOfficeId = Guid.NewGuid();
        repository.GetAll().Returns([]);

        var result = await handler.Handle(new GetDentalOfficesListQuery());

        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [TestMethod]
    public async Task Handle_ValidQuery_ReturnsDentalOfficesListDTO()
    {
        var dentalOffices = new List<DentalOffice>
        {
            new("Dental Office A"),
            new("Dental Office B")
        };

        var query = new GetDentalOfficesListQuery();

        repository.GetAll().Returns(dentalOffices);

        var result = await handler.Handle(query);

        Assert.IsNotNull(result);
        Assert.AreEqual(dentalOffices[0].Id, result[0].Id);
        Assert.AreEqual(dentalOffices[0].Name, result[0].Name);
        Assert.AreEqual(dentalOffices[1].Id, result[1].Id);
        Assert.AreEqual(dentalOffices[1].Name, result[1].Name);
    }
}
