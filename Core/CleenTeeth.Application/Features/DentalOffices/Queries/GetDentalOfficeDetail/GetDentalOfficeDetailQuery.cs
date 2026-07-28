using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQuery : IRequest<DentalOfficeDetailDTO>
{
    public required Guid Id { get; set; }
}
