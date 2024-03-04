using Castle.DynamicProxy;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using System.Reflection;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.
            GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        var methodAttributes = type.GetMethod(method.Name).
            GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
        classAttributes.AddRange(methodAttributes);
        //classAttributes.Add(new LogAspect(typeof(MongoDbLogger)));
        
        return classAttributes.OrderBy(x=>x.Priority).ToArray();

    }
}
