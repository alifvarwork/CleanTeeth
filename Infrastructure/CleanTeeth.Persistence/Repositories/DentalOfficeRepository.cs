using CleanTeeth.Domain.Entities;
using CleenTeeth.Application.Contracts.Repositories;

namespace CleanTeeth.Persistence.Repositories;

public class DentalOfficeRepository(CleanTeethDbContext dbContext) : Repository<DentalOffice>(dbContext), IDentalOfficeRepository
{

}
