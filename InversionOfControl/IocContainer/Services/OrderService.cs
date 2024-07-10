namespace IocContainer.Services;

[Injectable(ServiceLifetime.Scoped)]
public class OrderService : IOrderService
{
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;

    public OrderService(IProductService productService, ICustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public string CreateOrder()
    {
        return $"Order service : {_customerService.AddCustomer()} and {_productService.AddProduct()}";
    }
}
