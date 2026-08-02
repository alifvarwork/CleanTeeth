using CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleenTeeth.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace CleenTeeth.Application;

public static class RegisterApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services here
        services.AddTransient<IMediator, SimpleMediator>();

        services.Scan(scan => scan.FromAssembliesOf(typeof(RegisterApplicationServices))
                                  .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
                                  .AsImplementedInterfaces()
                                  .WithScopedLifetime());

        //services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, CreateDentalOfficeCommandHandler>();
        //services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>, GetDentalOfficeDetailQueryHandler>();
        //services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>, GetDentalOfficesListQueryHandler>();
        //services.AddScoped<IRequestHandler<UpdateDentalOfficeCommand>, UpdateDentalOfficeCommandHandler>();
        //services.AddScoped<IRequestHandler<DeleteDentalOfficeCommand>, DeleteDentalOfficeCommandHandler>();
        return services;
    }
}
