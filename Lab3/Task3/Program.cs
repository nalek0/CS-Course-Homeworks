using System.Text.RegularExpressions;

namespace Taks3
{

    public static class MainClass
    {

        private static int GCD(int number1, int number2)
        {
            if (number1 == 0)
            {
                return number2;
            }
            else 
            {
                return GCD(number2 % number1, number1);
            }
        }

        public static string Simplify(String arg)
        {
            string pattern = "(?<numerator>\\d+)/(?<denominator>\\d+)";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(arg);

            if (!match.Success)
            {
                throw new ArgumentException("Cannot parse the provided argument");
            }

            int numerator = int.Parse(match.Groups["numerator"].Value);
            int denominator = int.Parse(match.Groups["denominator"].Value);
            int gcd = GCD(numerator, denominator);
            int simplifiedNumerator = numerator / gcd;
            int simplifiedDenominator = denominator / gcd;

            if (simplifiedDenominator == 1)
            {
                return simplifiedNumerator.ToString();
            }
            else
            {
                return simplifiedNumerator.ToString() + "/" + simplifiedDenominator.ToString();
            }
        }

        public static void Main()
        {
            Console.WriteLine("4/6     --> {0}", Simplify("4/6"));
            Console.WriteLine("10/11   --> {0}", Simplify("10/11"));
            Console.WriteLine("100/400 --> {0}", Simplify("100/400"));
            Console.WriteLine("8/4     --> {0}", Simplify("8/4"));
        }

    }

}
