namespace Task1;

public class Publisher
{

    public String Id;

    public Publisher(String id)
    {
        this.Id = id;
    }

    public void Post(String message)
    {
        PostAction();
        EventBus.GetInstance().OnEvent(Id, message);
    }

    protected virtual void PostAction()
    {
        Console.WriteLine($"Default post action for {Id} publisher");
    }

}
