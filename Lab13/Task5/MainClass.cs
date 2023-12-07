using System.Diagnostics;
using System.Dynamic;
using System.Xml.XPath;

namespace Task2
{

    internal class MainClass
    {

        public static string Rational(int a, int b)
        {
            Debug.Assert(0 < a && a < b);

            if (a == 0)
            {
                return "0";
            } else
            {
                string result = "0.";
                int state = a;
                int position = 0;
                Dictionary<int, int> positions = new Dictionary<int, int>();

                while (true)
                {
                    state *= 10;

                    if (state == 0)
                        break;
                    else if (positions.ContainsKey(state))
                    {
                        int periodPosition = positions.GetValueOrDefault(state);

                        return result.Substring(0, periodPosition + 2) + "(" + result.Substring(periodPosition + 2) + ")";
                    }
                    
                    positions.Add(state, position);
                    result += (state / b).ToString();
                    state %= b;
                    position++;
                }

                return result;
            }
        }

        public static void Main()
        {
            Console.WriteLine(Rational(2, 5));
            Console.WriteLine(Rational(1, 6));
            Console.WriteLine(Rational(1, 3));
            Console.WriteLine(Rational(1, 7));
            Console.WriteLine(Rational(1, 77));
            Console.WriteLine(Rational(1, 777));
            Console.WriteLine(Rational(1, 7777));
            Console.WriteLine(Rational(1, 100000));
            Console.WriteLine(Rational(1, 999999));
        }
        
    }

}
