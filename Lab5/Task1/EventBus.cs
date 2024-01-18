namespace Task1;

public class EventBus
{

    private Dictionary<String, List<Subscriber>> _events;

    private static EventBus? _instance = null;

    private EventBus() {
        this._events = new Dictionary<string, List<Subscriber>>();
    }

    public void AddPublisher(Publisher publisher)
    {
        _events.Add(publisher.Id, new List<Subscriber>());
    }

    public void RemovePublisher(Publisher publisher)
    {
        _events.Remove(publisher.Id);
    }

    public void Subscribe(String eventId, Subscriber subscriber)
    {
        List<Subscriber> subscribers;

        if (_events.TryGetValue(eventId, out subscribers))
        {
            subscribers.Add(subscriber);
        }
    }

    public void Unsubscribe(String eventId, Subscriber subscriber)
    {
        List<Subscriber> subscribers;

        if (_events.TryGetValue(eventId, out subscribers))
        {
            subscribers.Remove(subscriber);
        }
    }

    public void OnEvent(String eventId, String message)
    {
        List<Subscriber> subscribers;

        if (_events.TryGetValue(eventId, out subscribers))
        {
            subscribers.ForEach(subscriber => subscriber.OnEvent(message));
        }
    }

    public static EventBus GetInstance()
    {
        if (_instance == null)
            _instance = new EventBus();

        return _instance;
    }

}
