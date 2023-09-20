using System.Runtime.InteropServices;

namespace Task1
{

    public sealed class Horse
    {

        public HorseBreed Breed { get; }

        public bool Horseshoes { get; }

        public Int32 Age { get; }

        public Int32 Height { get; }

        public Horse(HorseBreed breed, bool horseshoes, Int32 age, Int32 height)
        {
            this.Breed = breed;
            this.Horseshoes = horseshoes;
            this.Age = age;
            this.Height = height;
        }

        public override string ToString() =>
            "Horse["
                + "Breed=" + Breed.ToString()
                + ", "
                + "Horseshoes=" + Horseshoes.ToString()
                + ", "
                + "Age=" + Age.ToString()
                + ", "
                + "Height=" + Height.ToString()
                + "]";

        public static implicit operator Horse(Car car)
        {
            switch (car.Type)
            {
                case CarType.Sedan:
                    return new Horse(HorseBreed.Mustang, car.StuddedTires, 0, 0);
                case CarType.Crossover:
                    return new Horse(HorseBreed.Thoroughbred, car.StuddedTires, 0, 0);
                case CarType.Minivan:
                    return new Horse(HorseBreed.Appaloosa, car.StuddedTires, 0, 0);
                default:
                    throw new Exception("Unexpected horse breed");
            }
        }

        public static bool operator ==(Horse first, Horse second) =>
            first.Age == second.Age && first.Height == second.Height;

        public static bool operator !=(Horse first, Horse second) =>
            first.Age != second.Age || first.Height != second.Height;

        public static bool operator >(Horse first, Horse second) =>
            first.Age > second.Age || first.Age == second.Age && first.Height > second.Height;

        public static bool operator <(Horse first, Horse second) =>
            first.Age < second.Age || first.Age == second.Age && first.Height < second.Height;

    }

}