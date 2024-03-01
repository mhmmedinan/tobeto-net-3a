using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.CrossCuttingConcerns.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddScoped<IBrandService, BrandManager>();
        services.AddScoped<IModelService, ModelManager>();
        services.AddScoped<ICarService, CarManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType
        (this IServiceCollection services,Assembly assembly,
        Type type,Func<IServiceCollection,Type,IServiceCollection>? addWithLifeCycle=null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach(Type? item in types)
        {
            if (addWithLifeCycle == null) { services.AddScoped(item); }
            else { addWithLifeCycle(services, type); } 
        }
        return services;
    }
}
