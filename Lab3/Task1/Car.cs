namespace Task1
{

    public sealed class Car
    {

        public CarType Type { get; }

        public bool StuddedTires { get; }

        public Car(CarType breed, bool studdedЕires)
        {
            this.Type = breed;
            this.StuddedTires = studdedЕires;
        }

        public override string ToString() => "Car[" + Type.ToString() + ", " + StuddedTires.ToString() + "]";

        public static implicit operator Car(Horse horse)
        {
            switch (horse.Breed) {
                case HorseBreed.Mustang:
                    return new Car(CarType.Sedan, horse.Horseshoes);
                case HorseBreed.Thoroughbred:
                    return new Car(CarType.Crossover, horse.Horseshoes);
                case HorseBreed.Appaloosa:
                    return new Car(CarType.Minivan, horse.Horseshoes);
                default:
                    throw new Exception("Unexpected horse breed");
            }
        }

    }

}
