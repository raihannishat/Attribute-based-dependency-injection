namespace IocContainer.Services;

[Injectable(ServiceLifetime.Scoped)]
public class MonitoringService
{
    public string Health() => "100%";
}
