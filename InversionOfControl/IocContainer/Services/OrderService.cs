namespace IocContainer.Services;

[Injectable(ServiceLifetime.Scoped)]
public class OrderService : IOrderService
{
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;
    private readonly ItemService _item;
    private readonly MonitoringService _monitoringService;

    public OrderService(IProductService productService, 
        ICustomerService customerService, 
        ItemService item, 
        MonitoringService monitoringService)
    {
        _productService = productService;
        _customerService = customerService;
        _item = item;
        _monitoringService = monitoringService;
    }

    public string CreateOrder()
    {
        return $"Order service : {_customerService.AddCustomer()} " +
               $"and {_productService.AddProduct()} " +
               $"with {_item.AddItem()} and service " +
               $"health {_monitoringService.Health()}.";
    }
}
