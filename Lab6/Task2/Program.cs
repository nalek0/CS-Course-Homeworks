namespace Task2;

struct Person
{

    public string name;
    public int age;

}

class NameComparator : Comparer<Person>
{
    public override int Compare(Person x, Person y)
    {
        if (x.name.Length == y.name.Length)
            return Char.ToLower(x.name[0]).CompareTo(Char.ToLower(y.name[0]));
        else
            return x.name.Length.CompareTo(y.name.Length);
    }
}

class AgeComparator : Comparer<Person>
{
    public override int Compare(Person x, Person y)
    {
        return x.age.CompareTo(y.age);
    }
}

public class Program
{

    private static List<string> names = new List<string>()
    {
        "Lexi",
        "Seven",
        "Robin",
        "Reid",
        "Adrianna",
        "Avi",
        "Adalee",
        "Ryland",
        "Renata",
        "Fox",
        "Nyomi",
        "Malachi",
        "Nicole",
        "Santino",
        "Laylani",
        "Travis",
        "Yaretzi",
        "Alfredo",
        "Addisyn",
        "Ayden"
    };
    private const int PEOPLE_AMOUNT = 100;
    private const int SEED = 123;

    public static void Main()
    {
        Random random = new Random(SEED);
        List<Person> people = new List<Person>();

        for (int i = 0; i < PEOPLE_AMOUNT; i++)
        {
            people.Add(new Person { name = names[random.Next(names.Count)], age = random.Next(20, 30) });
        }

        people.Sort(new NameComparator());
        Console.WriteLine("NameComparator:");

        foreach (var person in people)
            Console.WriteLine("  Person[name={0}, age={1}] ", person.name, person.age);

        people.Sort(new AgeComparator());
        Console.WriteLine("AgeComparator:");

        foreach (var person in people)
            Console.WriteLine("  Person[name={0}, age={1}] ", person.name, person.age);
    }

}
