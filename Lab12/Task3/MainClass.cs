using System;
using System.Collections.Generic;
using System.Threading;

namespace Task3
{
    public class H2O
    {
        private Semaphore _hEvent;

        private AutoResetEvent _oEvent;

        private object _stateLock;

        private int _state = 0;
    
        public H2O()
        {
            this._hEvent = new Semaphore(2, 2);
            this._oEvent = new AutoResetEvent(true);
            this._stateLock = new object();
        }

        public void Hydrogen(Action releaseHydrogen)
        {
            _hEvent.WaitOne();

            // releaseHydrogen() outputs "H". Do not change or remove this line.
            releaseHydrogen();

            lock (_stateLock)
            {
                if (++_state == 3)
                {
                    _hEvent.Release();
                    _hEvent.Release();
                    _oEvent.Set();
                    _state = 0;
                }
            }
        }

        public void Oxygen(Action releaseOxygen)
        {
            _oEvent.WaitOne();
         
            // releaseOxygen() outputs "O". Do not change or remove this line.
            releaseOxygen();

            lock (_stateLock)
            {
                if (++_state == 3)
                {
                    _hEvent.Release();
                    _hEvent.Release();
                    _oEvent.Set();
                    _state = 0;
                }
            }
        }

    }


    internal class MainClass
    {

        public static void Main(string[] args)
        {
            Action releaseHydrogen = () => { Console.Write("H"); };
            Action releaseOxygen = () => { Console.Write("O"); };
            H2O h2o = new H2O();
            List<Thread> threads = new List<Thread>();
            ParameterizedThreadStart hThread = obj => ((H2O) obj).Hydrogen(releaseHydrogen);
            ParameterizedThreadStart oThread = obj => ((H2O) obj).Oxygen(releaseOxygen);

            Console.WriteLine("Write a string: ");
            string input = Console.ReadLine();

            foreach (char c in input)
            {
                if (c == 'H')
                {
                    threads.Add(new Thread(hThread));
                }
                else if (c == 'O')
                {
                    threads.Add(new Thread(oThread));
                }
            }

            threads.ForEach(t => t.Start(h2o));
            threads.ForEach(t => t.Join());
            Console.WriteLine();
        }

    }

}
