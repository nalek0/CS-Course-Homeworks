namespace Task4
{

    public static class MainClass
    {

        private static Int32 diceRoll(Int32 cubes, Int32 result)
        {
            if (cubes == 0)
            {
                return result == 0 ? 1 : 0;
            }
            else if (result < 0)
            {
                return 0;
            }

            Int32 res = 0;

            for (Int32 i = 1; i <= 6; i++)
            {
                res += diceRoll(cubes - 1, result - i);
            }

            return res;
        }

        private static void logRoll(Int32 cubes, Int32 result)
        {
            Console.WriteLine("diceRoll({0}, {1}) = {2}", cubes, result, diceRoll(cubes, result));
        }

        public static void Main()
        {
            logRoll(2, 6);
            logRoll(2, 2);
            logRoll(1, 3);
            logRoll(2, 5);
            logRoll(3, 4);
            logRoll(4, 18);
            logRoll(6, 20);
            Console.WriteLine("---------------------");
            logRoll(20, 19);
            logRoll(1, 50);
        }

    }

}