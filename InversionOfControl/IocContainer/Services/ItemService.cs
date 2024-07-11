namespace IocContainer.Services;

public class ItemService
{
    public virtual string AddItem()
    {
        return "**Added some item**";
    }

    public string Display()
    {
        return "Hello World!";
    }
}
