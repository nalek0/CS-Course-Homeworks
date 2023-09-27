namespace Task1
{

    public static class MainClass
    {

        private static void TestCasting()
        {
            Horse horse1 = new Horse(HorseBreed.Mustang, true, 5, 100);
            Console.WriteLine("Horse#1: " + horse1.ToString());
            Car car1 = horse1;
            Console.WriteLine("Car#1:   " + car1.ToString());            
            Car car2 = new Car(CarType.Crossover, false);
            Console.WriteLine("Car#2:   " + car2.ToString());
            Horse horse2 = (Horse) car2;
            Console.WriteLine("Horse#2: " + horse2.ToString());
            Console.WriteLine("-------------------------------");
        }

        private static void TestComparison()
        {
            Horse horse1 = new Horse(HorseBreed.Mustang, true, 5, 100);
            Horse horse2 = new Horse(HorseBreed.Appaloosa, true, 5, 101);
            Horse horse3 = new Horse(HorseBreed.Thoroughbred, true, 6, 100);

            Console.WriteLine(horse1.ToString());
            Console.WriteLine(horse2.ToString());
            Console.WriteLine(horse3.ToString());
            Console.WriteLine("horse1 < horse2: " + (horse1 < horse2).ToString());
            Console.WriteLine("horse2 < horse3: " + (horse2 < horse3).ToString());
            Console.WriteLine("horse3 > horse1: " + (horse3 > horse1).ToString());
        }

        public static void Main()
        {
            TestCasting();
            TestComparison();
        }

    }

}
