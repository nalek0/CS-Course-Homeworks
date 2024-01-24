namespace Lab15;

class CacheData<T>
{

    public DateTime EditTime { get; set; }

    public T Data { get; init; }

}

public class MyCache<T> where T : IDisposable
{

    public Int32 Size { get; }

    public TimeSpan SaveDuration { get; }

    public Int32 Count { get => _data.Count; }

    private List<CacheData<T>> _data;

    private Boolean _checkForNotify;

    private Boolean _finalExit;

    private Thread? _notificationsThread;

    public MyCache(Int32 size, TimeSpan saveDuration)
    {
        this.Size = size;
        this.SaveDuration = saveDuration;
        this._data = new List<CacheData<T>>();

        this._checkForNotify = false;
        this._finalExit = true;
        this._notificationsThread = null;
    }

    public void Register()
    {
        GC.RegisterForFullGCNotification(1, 1);
        Console.WriteLine("Registered for GC notification.");
        _checkForNotify = true;
        _finalExit = false;

        _notificationsThread = new Thread(WaitForFullGCProc);
        _notificationsThread.Start();
    }

    public void Unregister()
    {
        _checkForNotify = false;
        _finalExit = true;
        GC.CancelFullGCNotification();
        _notificationsThread?.Join();
    }

    public void Add(T value)
    {
        if (_data.Count >= Size)
            Clear();

        _data.Add(new CacheData<T> { EditTime = DateTime.Now, Data = value });
    }

    public void Clear()
    {
        Console.WriteLine("Clearing cache at " + DateTime.Now);
        DateTime now = DateTime.Now;
        int index = 0;

        while (index < _data.Count)
        {
            CacheData<T> data = _data[index];
            TimeSpan deltaTime = now - data.EditTime;

            if (deltaTime > SaveDuration)
            {
                Console.WriteLine("> Removing object " + data.Data.ToString());
                data.Data.Dispose();
                _data.RemoveAt(index);
            }
            else
                index++;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index >= _data.Count || index < 0)
                throw new ArgumentOutOfRangeException();

            _data[index].EditTime = DateTime.Now;

            return _data[index].Data;
        }
    }

    private void WaitForFullGCProc()
    {
        while (true)
        {
            while (_checkForNotify)
            {
                Console.WriteLine("WaitForFullGCApproach");
                GCNotificationStatus s = GC.WaitForFullGCApproach();

                if (s == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("GC Notification raised.");
                    Clear();
                    GC.Collect();
                }
                else if (s == GCNotificationStatus.Canceled)
                {
                    Console.WriteLine("GC Notification cancelled.");
                    break;
                }
                else
                {
                    Console.WriteLine("GC Notification not applicable.");
                    break;
                }

                GCNotificationStatus status = GC.WaitForFullGCComplete();

                if (status == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("GC Notification raised.");
                }
                else if (status == GCNotificationStatus.Canceled)
                {
                    Console.WriteLine("GC Notification cancelled.");
                    break;
                }
                else
                {
                    Console.WriteLine("GC Notification not applicable.");
                    break;
                }
            }

            Thread.Sleep(500);

            if (_finalExit)
            {
                break;
            }
        }
    }

}
