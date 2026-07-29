using CleanTeeth.Domain.Entities;

namespace CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;

public static class MapperExtensions
{
    public static DentalOfficeDetailDTO ToDTO(this DentalOffice dentalOffice)
    {
        return new DentalOfficeDetailDTO
        {
            Id = dentalOffice.Id,
            Name = dentalOffice.Name
        };
    }
}
