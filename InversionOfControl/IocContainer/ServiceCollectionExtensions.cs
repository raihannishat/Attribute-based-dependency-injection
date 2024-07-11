namespace IocContainer;

public static class ServiceCollectionExtensions
{
    public static void AddIoC(this IServiceCollection services)
    {
        //services.AddScoped<ItemService, ForeignItemService>();
        //services.AddScoped<ICustomerService, CustomerService>();
        //services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<IOrderService, OrderService>();
        RegisterServices(services, Assembly.GetExecutingAssembly());
    }

    private static void RegisterServices(IServiceCollection services, Assembly assembly)
    {
        var typesWithInjectableAttribute = assembly.GetTypes()
            .Where(t => t.GetCustomAttribute<InjectableAttribute>() != null);

        foreach (var type in typesWithInjectableAttribute)
        {
            var attribute = type.GetCustomAttribute<InjectableAttribute>();
            var interfaces = type.GetInterfaces();
            var baseType = type.BaseType;

            // Register the service itself
            if (interfaces.Length == 0 && (baseType == null || baseType == typeof(object)))
            {
                RegisterServiceWithSelf(services, attribute!.Lifetime, type);
            }

            // Register the base class if it has the InjectableAttribute
            if (baseType != null && !baseType.FullName!.Equals("System.Object"))
            {
                RegisterServiceWithBase(services, attribute!.Lifetime, baseType, type);
            }

            // Register interfaces
            if (interfaces.Length > 0)
            {
                foreach (var @interface in interfaces)
                {
                    RegisterServiceWithBase(services, attribute!.Lifetime, @interface, type);
                }
            }
        }
    }

    private static void RegisterServiceWithSelf(IServiceCollection services, ServiceLifetime lifetime, Type implementationType)
    {
        _ = lifetime switch
        {
            ServiceLifetime.Singleton => services.AddSingleton(implementationType),
            ServiceLifetime.Scoped => services.AddScoped(implementationType),
            ServiceLifetime.Transient or _ => services.AddTransient(implementationType)
        };
    }

    private static void RegisterServiceWithBase(IServiceCollection services, ServiceLifetime lifetime, Type serviceType, Type implementationType)
    {
        _ = lifetime switch
        {
            ServiceLifetime.Singleton => services.AddSingleton(serviceType, implementationType),
            ServiceLifetime.Scoped => services.AddScoped(serviceType, implementationType),
            ServiceLifetime.Transient or _ => services.AddTransient(serviceType, implementationType)
        };
    }
}
