using CleanTeeth.Domain.Entities;

namespace CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;

public static class MapperExtensions
{
    public static DentalOfficesListDTO ToDTO(this DentalOffice dentalOffice)
    {
        return new DentalOfficesListDTO
        {
            Id = dentalOffice.Id,
            Name = dentalOffice.Name
        };
    }
}
