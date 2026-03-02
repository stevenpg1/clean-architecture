using CleanTeeth.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;


namespace CleanTeeth.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(RegisterApplicationServices))
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                );

            //Automatically registered by Scrutor NuGet package.
            //services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, CreateDentalOfficeCommandHandler>();
            //services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>, GetDentalOfficeDetailQueryHandler>();
            //services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, DentalOfficesListDTO>, GetDentalOfficesListQueryHandler>();
            //services.AddScoped<IRequestHandler<UpdateDentalOfficeCommand>, UpdateDentalOfficeCommandHandler>();
            //services.AddScoped<IRequestHandler<DeleteDentalOfficeCommand>, DeleteDentalOfficeCommandHandler>();

            return services;
        }
    }
}
