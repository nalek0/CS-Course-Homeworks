using System;
using System.Threading;

namespace Task1
{

    public class ZeroEvenOdd
    {
        private int n;

        private AutoResetEvent _zeroEvent;

        private AutoResetEvent _evenEvent;
        
        private AutoResetEvent _oddEvent;

        public ZeroEvenOdd(int n)
        {
            this.n = n;
            this._zeroEvent = new AutoResetEvent(true);
            this._evenEvent = new AutoResetEvent(false);
            this._oddEvent = new AutoResetEvent(false);
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i++)
            {
                _zeroEvent.WaitOne();

                printNumber(0);

                if (i % 2 == 0)
                {
                    _evenEvent.Set();
                } else
                {
                    _oddEvent.Set();
                }
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i += 2)
            {
                _evenEvent.WaitOne();

                printNumber(i);

                _zeroEvent.Set();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                _oddEvent.WaitOne();

                printNumber(i);

                _zeroEvent.Set();
            }
        }

    }

    internal class MainClass
    {

        public static void Main(string[] args)
        {
            Console.Write("Write integer: ");

            int n = int.Parse(Console.ReadLine());
            Action<int> printNumber = Console.Write;
            ZeroEvenOdd zeroEvenOdd = new ZeroEvenOdd(n);
            Thread zeroThread = new Thread(obj => ((ZeroEvenOdd)obj).Zero(printNumber));
            Thread evenThread = new Thread(obj => ((ZeroEvenOdd)obj).Even(printNumber));
            Thread oddThread = new Thread(obj => ((ZeroEvenOdd)obj).Odd(printNumber));

            zeroThread.Start(zeroEvenOdd);
            evenThread.Start(zeroEvenOdd);
            oddThread.Start(zeroEvenOdd);

            zeroThread.Join();
            evenThread.Join();
            oddThread.Join();
        }

    }

}
