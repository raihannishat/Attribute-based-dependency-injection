namespace IocContainer.Attributes;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public class ImportableAttribute : FromKeyedServicesAttribute
{
    public ImportableAttribute(object key) : base(key) { }
}
