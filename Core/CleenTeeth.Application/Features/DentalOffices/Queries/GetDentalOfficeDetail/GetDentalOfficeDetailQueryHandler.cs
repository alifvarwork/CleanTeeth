
using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Exceptions;
using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public class GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository repository) : IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>
{
    public async Task<DentalOfficeDetailDTO> Handle(GetDentalOfficeDetailQuery request)
    {
        var dentalOffice = await repository.GetById(request.Id) ?? throw new NotFoundException("Dental office not found");
        return dentalOffice.ToDTO();
    }
}
