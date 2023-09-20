namespace Task1 {

    public static class MainClass {

        public static void Main() {
            Horse horse = new Horse(HorseBreed.Mustang, true);
            Console.WriteLine(horse.ToString());
            Car car = horse;
            Console.WriteLine(car.ToString());
            Console.WriteLine("-------------------");
            Car car2 = new Car(CarType.Crossover, false);
            Console.WriteLine(car2.ToString());
            Horse horse2 = (Horse) car2;
            Console.WriteLine(horse2.ToString());
        }

    }

}