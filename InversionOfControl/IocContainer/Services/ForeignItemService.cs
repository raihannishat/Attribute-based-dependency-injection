namespace IocContainer.Services;

[Injectable(ServiceLifetime.Scoped)]
public class ForeignItemService : ItemService
{
    public override string AddItem()
    {
        return "[Added some item from ForeignItemService]";
    }
}
