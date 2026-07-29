using CleenTeeth.Application.Contracts.Repositories;
using CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleenTeeth.Application.Utilities;

namespace CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

public class GetDentalOfficesListQueryHandler(IDentalOfficeRepository repository) :
    IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>
{
    public async Task<List<DentalOfficesListDTO>> Handle(GetDentalOfficesListQuery request)
    {
        var dentalOffices = await repository.GetAll();
        return [.. dentalOffices.Select(d => d.ToDTO())];
    }
}
