namespace IocContainer.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class InjectableAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; }

    public InjectableAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        Lifetime = lifetime;
    }
}
