using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Task3
{

    public class Program
    {

        public delegate double IntegrateFunction(double x);

        public const int RANGES = 10000;


        private static double NonSmoothFunction(double x)
        {
            if (0 <= x && x <= 1)
            {
                return x;
            }
            else if (-1 <= x && x < 0)
            {
                return x + 1;
            }
            else
            {
                return 0;
            }

        }

        public static double Integrate(IntegrateFunction function, double a, double b)
        {
            Debug.Assert(a <= b);

            double length = b - a;
            double rangeLength = length / RANGES;
            List<double> xs = new List<double> { a };
            double current = a;

            for (int i = 0; i < RANGES; i++)
            {
                current += rangeLength;
                xs.Add(current);
            }

            List<double> ys = new List<double>();

            foreach(double x in xs)
            {
                double y = function.Invoke(x);
                ys.Add(y);
            }

            double result = 0;

            for (int i = 0; i < RANGES; i++)
            {
                double prevX = xs[i];
                double prevY = ys[i];
                double nextX = xs[i + 1];
                double nextY = ys[i + 1];
                double area = (nextX - prevX) * (nextY + prevY) / 2;
                result += area;
            }

            return result;
        }

        public static void Main()
        {

            IntegrateFunction linear = x => x;
            IntegrateFunction sin = Math.Sin;
            IntegrateFunction custom = NonSmoothFunction;

            Console.WriteLine("linear function on [0, 1]:   {0}", Math.Round(Integrate(linear, 0, 1),  2));
            Console.WriteLine("sin function on [0, 1]:      {0}", Math.Round(Integrate(sin, 0, 1),     2));
            Console.WriteLine("custom function on [0, 1]:   {0}", Math.Round(Integrate(custom, 0, 1),  2));
            Console.WriteLine("linear function on [-1, 1]:  {0}", Math.Round(Integrate(linear, -1, 1), 2));
            Console.WriteLine("sin function on [-1, 1]:     {0}", Math.Round(Integrate(sin, -1, 1),    2));
            Console.WriteLine("custom function on [-1, 1]:  {0}", Math.Round(Integrate(custom, -1, 1), 2));
        }

    }

}
