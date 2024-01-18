namespace Task1;

public class Program
{

    private class UserSubscriber : Subscriber
    {

        public String? Name { get; init; }

        public void OnEvent(string message)
        {
            Console.WriteLine($"User({Name}) got message: '{message}'");
        }

    }

    private class ServerSubscriber : Subscriber
    {

        public void OnEvent(string message)
        {
            Console.WriteLine($"Server got message: '{message}'");
        }

    }

    public static void Main()
    {
        var basePublisher = new Publisher("base");
        var innerPublisher = new Publisher("inner");
        EventBus.GetInstance().AddPublisher(basePublisher);
        EventBus.GetInstance().AddPublisher(innerPublisher);

        var user1 = new UserSubscriber { Name="abc" };
        var user2 = new UserSubscriber { Name="qqq" };
        var server = new ServerSubscriber();
        EventBus.GetInstance().Subscribe("base", server);
        EventBus.GetInstance().Subscribe("base", user1);
        EventBus.GetInstance().Subscribe("base", user2);
        EventBus.GetInstance().Subscribe("inner", server);

        basePublisher.Post("Global message");
        innerPublisher.Post("Debug message #1");
        innerPublisher.Post("Debug message #2");
    }

}
