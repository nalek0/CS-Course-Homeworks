using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task5
{

    public class CMyBarrier : IDisposable
    {

        private int _participantCount;

        private int _state;

        private object _lock;

        private List<AutoResetEvent> _events;

        public CMyBarrier(int participantCount)
        {
            this._participantCount = participantCount;
            this._state = participantCount;
            this._lock = new object();
            this._events = new List<AutoResetEvent>(participantCount - 1);

            for (int i = 0; i < participantCount - 1; i++)
            {
                this._events.Add(new AutoResetEvent(false));
            }
        }

        public bool SignalAndWait(TimeSpan timeout)
        {
            AutoResetEvent currentEvent;

            lock (_lock)
            {
                if (_state == 0)
                {
                    throw new InvalidOperationException("Invalid barrier usage");
                }

                _state--;
                
                if (_state == 0)
                {
                    _events.ForEach(e => { e.Set(); });

                    return true;
                } else
                {
                    currentEvent = _events[_participantCount - _state - 1];
                }
            }

            return currentEvent.WaitOne(timeout);
        }

        public void Dispose()
        {
            _events.ForEach(_mutex => { _mutex.Dispose(); });
        }
    }

    internal class MainClass
    {
        
        private static Random random = new Random(123);

        private static CMyBarrier _barrier = new CMyBarrier(5);

        private static void threadStart()
        {
            Thread.Sleep(random.Next() % 1000);
            Console.WriteLine("Running #" + Thread.CurrentThread.ManagedThreadId);

            bool barrierResult = _barrier.SignalAndWait(TimeSpan.FromSeconds(2));

            Console.WriteLine("After the barrier: #" + Thread.CurrentThread.ManagedThreadId + " with result " + barrierResult);
        }

        public static void MainNotEnoughThreads()
        {

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                threads.Add(new Thread(threadStart));
            }

            threads.ForEach(thread => { thread.Start(); });
            threads.ForEach(thread => { thread.Join(); });
        }

        public static void MainInvalidUsage()
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 6; i++)
            {
                threads.Add(new Thread(threadStart));
            }

            threads.ForEach(thread => { thread.Start(); });
            threads.ForEach(thread => { thread.Join(); });
        }

        public static void MainSuccess()
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 5; i++)
            {
                threads.Add(new Thread(threadStart));
            }

            threads.ForEach(thread => { thread.Start(); });
            threads.ForEach(thread => { thread.Join(); });
        }

        public static void Main(string[] args)
        {
            MainSuccess();
            // MainInvalidUsage();
            // MainNotEnoughThreads();
        }

    }

}
