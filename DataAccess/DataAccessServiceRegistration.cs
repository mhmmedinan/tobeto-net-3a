using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using DataAccess.Concretes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>
            (options => options.UseSqlServer(configuration.
            GetConnectionString("TobetoNet3AConnectionString")));

        //services.AddScoped<IBrandRepository, BrandRepository>();
        //services.AddScoped<IModelRepository, ModelRepository>();
        //services.AddScoped<ICarRepository, CarRepository>();


        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).
            Where(t => t.ServiceType.Name.EndsWith("Repository"));

        return services;
    }

    public static IServiceCollection RegisterAssemblyTypes
        (this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
        foreach (Type? type in types)
        {
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, type);
            }
        }
        return services;
    }
}
