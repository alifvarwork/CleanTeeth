using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;

public class CreateDentalOfficeCommand : IRequest<Guid>
{
    public required string Name { get; set; }
}
