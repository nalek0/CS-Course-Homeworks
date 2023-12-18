using System.Reflection.Metadata;

namespace Task4
{

    internal struct Hamster
    {

        public const int MIN_COLOR = 0;
        public const int MAX_COLOR = 5;
        public const int MIN_WOOL = 0;
        public const int MAX_WOOL = 5;
        public const int MIN_WEIGHT = 1;
        public const int MAX_WEIGHT = 200;
        public const int MIN_HEIGHT = 1;
        public const int MAX_HEIGHT = 50;
        public const int MIN_AGE = 0;
        public const int MAX_AGE = 7;

        public int color;   // More color --- better
        public int wool;    // More wool number --- better
        public int weight;  // Closer weight to average(100g) --- better
        public int height;  // Closer height to average(20sm) --- better
        public int age;     // Less age --- better

    }

    public class Program
    {

        private const int HAMSTER_AMOUNT = 500;
        private const int SEED = 123;

        public static void Main()
        {
            Random random = new Random(SEED);
            List<Hamster> hamsters = new List<Hamster>();

            for (int i = 0; i < HAMSTER_AMOUNT; i++)
            {
                var hamster = new Hamster
                {
                    color = random.Next(Hamster.MIN_COLOR, Hamster.MAX_COLOR),
                    wool = random.Next(Hamster.MIN_WOOL, Hamster.MAX_WOOL),
                    weight = random.Next(Hamster.MIN_WEIGHT, Hamster.MAX_WEIGHT),
                    height = random.Next(Hamster.MIN_HEIGHT, Hamster.MAX_HEIGHT),
                    age = random.Next(Hamster.MIN_AGE, Hamster.MAX_AGE)
                };
                hamsters.Add(hamster);
            }

            var sortedHamsters = hamsters
                .OrderBy(h => h.color)
                .ThenBy(h => h.wool)
                .ThenBy(h => -Math.Abs(h.weight - 100))
                .ThenBy(h => -Math.Abs(h.height - 20))
                .ThenBy(h => -h.age)
                .ToList();

            foreach(var hamster in sortedHamsters)
            {
                Console.WriteLine("color={0} wool={1} weight={2} height={3} age={4}", hamster.color, hamster.wool, hamster.weight, hamster.height, hamster.age);
            }
        }

    }

}
