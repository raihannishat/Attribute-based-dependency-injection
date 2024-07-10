namespace IocContainer.Services;

[Injectable(ServiceLifetime.Scoped)]
public class ProductService : IProductService
{
    public string AddProduct()
    {
        return $"Product service added product";
    }
}
