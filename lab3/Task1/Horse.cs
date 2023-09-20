namespace Task1 {

    public sealed class Horse {

        public HorseBreed Breed { get; }

        public bool Horseshoes { get; }

        public Horse(HorseBreed breed, bool horseshoes)
        {
            this.Breed = breed;
            this.Horseshoes = horseshoes;
        }
        
        public override string ToString() => "Horse[" + Breed.ToString() + ", " + Horseshoes.ToString() + "]";

        public static implicit operator Horse(Car car) {
            switch (car.Type) {
                case CarType.Sedan:
                    return new Horse(HorseBreed.Mustang, car.StuddedTires);
                case CarType.Crossover:
                    return new Horse(HorseBreed.Thoroughbred, car.StuddedTires);
                case CarType.Minivan:
                    return new Horse(HorseBreed.Appaloosa, car.StuddedTires);
                default:
                    throw new Exception("Unexpected horse breed");
            }
        }

    }

}