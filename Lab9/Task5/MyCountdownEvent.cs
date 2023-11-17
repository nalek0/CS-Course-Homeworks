namespace Task5
{

    internal class MyCountdownEvent : IDisposable
    {

        private int _counter;

        private object _counterLocker;

        private ManualResetEvent _manualResetEvent;

        public MyCountdownEvent(int initialCount)
        {
            _counter = initialCount;
            _counterLocker = new();
            _manualResetEvent = new ManualResetEvent(false);
        }

        public void Signal() => Signal(1);

        public void Signal(int signalCount)
        {
            lock (_counterLocker)
            {
                if (_counter > signalCount)
                {
                    _counter -= signalCount;
                }
                else if (_counter == signalCount)
                {
                    _counter = 0;
                    _manualResetEvent.Set();
                }
                else
                {
                    throw new ArgumentException("signalCount more that current counter value");
                }
            }
        }

        public bool Wait(TimeSpan timeout)
        {
            return _manualResetEvent.WaitOne(timeout);
        }

        public void Dispose()
        {
            _manualResetEvent.Dispose();
        }
        
    }

}
