using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Repositories;
using CleanTeeth.Persistence.UnitsOfWork;
using CleenTeeth.Application.Contracts.Persistence;
using CleenTeeth.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Persistence;

public static class RegisterPersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CleanTeethDbConnection");
        services.AddDbContext<CleanTeethDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

        services.AddScoped<IDentalOfficeRepository, DentalOfficeRepository>();
        return services;
    }
}
