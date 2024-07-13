namespace IocContainer.Services.InterfaceExamples;

[Injectable(ServiceLifetime.Scoped)]
public class CustomerService : ICustomerService
{
    public string AddCustomer()
    {
        return $"Customer service added customer";
    }
}