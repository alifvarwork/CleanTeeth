using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;

public class DeleteDentalOfficeCommand : IRequest
{
    public required Guid Id { get; set; }
}
