namespace IocContainer.Services.InterfaceExamples;

[Injectable(ServiceLifetime.Scoped)]
public class OrderService : IOrderService
{
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;
    //private readonly ItemService _item;
    //private readonly MonitoringService _monitoringService;

    public OrderService(
        [Importable(typeof(ProductService))] IProductService productService,
        [Importable(typeof(CustomerService))] ICustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public string CreateOrder()
    {
        return $"Order service : {_customerService.AddCustomer()} " +
               $"and {_productService.AddProduct()} ";
        //$"with {_item.AddItem()} and service " +
        //$"health {_monitoringService.Health()}.";
    }
}
