namespace IocContainer.Controllers;

[ApiController]
[Route("[controller]")]
public class IoCController : ControllerBase
{
    private readonly IOrderService _orderService;

    public IoCController([Importable(typeof(OrderService))] IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet(Name = "GetIoC")]
    public string Get()
    {
        return _orderService.CreateOrder();
    }
}
