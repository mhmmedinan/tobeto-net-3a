using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IBrandService, BrandManager>();
        services.AddScoped<IModelService, ModelManager>();
        services.AddScoped<ICarService, CarManager>();
        return services;
    }
}
