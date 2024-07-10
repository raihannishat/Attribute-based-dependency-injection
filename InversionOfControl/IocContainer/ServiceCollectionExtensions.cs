namespace IocContainer;

public static class ServiceCollectionExtensions
{
    public static void AddIoC(this IServiceCollection services)
    {
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

            if (interfaces.Length == 0)
            {
                // Self-binding class
                _ = attribute!.Lifetime switch
                {
                    ServiceLifetime.Singleton => services.AddSingleton(type),
                    ServiceLifetime.Scoped => services.AddScoped(type),
                    ServiceLifetime.Transient or _ => services.AddTransient(type)
                };
            }
            else
            {
                // Interface-based class
                foreach (var @interface in interfaces)
                {
                    _ = attribute!.Lifetime switch
                    {
                        ServiceLifetime.Singleton => services.AddSingleton(@interface, type),
                        ServiceLifetime.Scoped => services.AddScoped(@interface, type),
                        ServiceLifetime.Transient or _ => services.AddTransient(@interface, type)
                    };
                }
            }
        }
    }
}
