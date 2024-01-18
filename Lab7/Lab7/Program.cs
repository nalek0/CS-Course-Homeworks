using System.Text.RegularExpressions;

namespace Lab7;

public class Program
{

    private struct Person
    {
        public String Name;
    }

    public static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
    }

    private static void Task1()
    {
        String delimeter = ", ";

        List<Person> people = new List<Person>
        {
            new Person { Name = "Hayden" },
            new Person { Name = "Marc" },
            new Person { Name = "Dominique" },
            new Person { Name = "Hugo" },
            new Person { Name = "Elisa" },
            new Person { Name = "Azul" },
            new Person { Name = "Monserrat" },
            new Person { Name = "Brent" },
            new Person { Name = "Londyn" },
            new Person { Name = "Lia" },
            new Person { Name = "Juan" },
            new Person { Name = "Janessa" },
        };

        Console.WriteLine("  TASK#1");
        Console.WriteLine(
            people
                .Skip(3)
                .Select(person => person.Name)
                .Aggregate((a, b) => a + delimeter + b)
        );
    }

    private static void Task2()
    {
        String delimeter = ", ";

        List<Person> people = new List<Person>
        {
            new Person { Name = "Hayden" },
            new Person { Name = "Marc" },
            new Person { Name = "Dominique" },
            new Person { Name = "Hugo" },
            new Person { Name = "Elisa" },
            new Person { Name = "Azul" },
            new Person { Name = "Monserrat" },
            new Person { Name = "Brent" },
            new Person { Name = "Londyn" },
            new Person { Name = "Lia" },
            new Person { Name = "Juan" },
            new Person { Name = "Janessa" },
        };

        Console.WriteLine("  TASK#2");
        Console.WriteLine(
            people
                .Where((Person person, Int32 index) => person.Name.Count() > index)
                .Select(person => person.Name)
                .Aggregate((a, b) => a + delimeter + b)
        );
    }

    private static void Task3()
    {
        String paragraphBig = @"It was a special pleasure to see things eaten, to see things blackened and
changed. With the brass nozzle in his fists, with this great python spitting its
venomous kerosene upon the world, the blood pounded in his head, and his hands
were the hands of some amazing conductor playing all the symphonies of blazing
and burning to bring down the tatters and charcoal ruins of history. With his
symbolic helmet numbered 451 on his stolid head, and his eyes all orange flame
with the thought of what came next, he flicked the igniter and the house jumped
up in a gorging fire that burned the evening sky red and yellow and black. He
strode in a swarm of fireflies. He wanted above all, like the old joke, to shove a
marshmallow on a stick in the furnace, while the flapping pigeon-winged books
died on the porch and lawn of the house. While the books went up in sparkling
whirls and blew away on a wind turned dark with burning.";
        String paragraph1 = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
        String pattern = @"\w+";

        Console.WriteLine("  TASK#3");
        Console.WriteLine(" Paragraph#1");
        Console.WriteLine(Regex
            .Matches(paragraph1, pattern)
            .Select(match => match.Value)
            .GroupBy(word => word.Count())
            .OrderBy(grouping => -grouping.Count())
            .Select(grouping => "Length: " + grouping.Key.ToString() + ", words amount: " + grouping.Count())
            .Aggregate((aggregator, description) => aggregator + "\n" + description));
        Console.WriteLine(" Paragraph#Big");
        Console.WriteLine(Regex
            .Matches(paragraphBig, pattern)
            .Select(match => match.Value)
            .GroupBy(word => word.Count())
            .OrderBy(grouping => -grouping.Count())
            .Select(grouping => "Length: " + grouping.Key.ToString() + ", words amount: " + grouping.Count())
            .Aggregate((aggregator, description) => aggregator + "\n" + description));
    }

    private static void Task4()
    {
        Int32 chunkSize = 3;
        Dictionary<String, String> dictionary = new Dictionary<string, string> {
            { "this",       "этот" },
            { "dog",        "собака" },
            { "eats",       "ест" },
            { "too",        "слишком" },
            { "much",       "много" },
            { "vegetables", "овощи" },
            { "after",      "после" },
            { "lunch",      "обед" },
        };
        String paragraph = @"This dog eats too much vegetables after lunch";
        String pattern = @"\w+";

        Console.WriteLine("  TASK#4");
        Console.WriteLine(Regex
            .Matches(paragraph, pattern)
            .Select(match => match.Value)
            .Select(word => dictionary.GetValueOrDefault(word.ToLower(), "nan"))
            .Select(word => word.ToUpper())
            .Chunk(chunkSize)
            .Select(chunk => String.Join(" ", chunk))
            .Aggregate((a, s) => a + "\n" + s));
    }

    private static List<String> Bucketize(String phrase, Int32 size)
    {
        List<String> result = new List<string>();
        Int32 current = 0;

        while (current < phrase.Length)
        {
            Int32 whitespaceSize = phrase
                .Skip(current)
                .TakeWhile(Char.IsWhiteSpace)
                .Count();
            Int32 bucketStart = current + whitespaceSize;

            Int32 bucketLength = phrase
                .Skip(bucketStart)
                .TakeWhile(Char.IsLetter)
                .Count();

            if (bucketLength == 0)
                break;

            while (true)
            {
                Int32 whitespaceLength  = phrase.Skip(bucketStart + bucketLength).TakeWhile(Char.IsWhiteSpace).Count();
                Int32 wordLength        = phrase.Skip(bucketStart + bucketLength + whitespaceLength).TakeWhile(Char.IsLetter).Count();
                Int32 newBucketLength   = bucketLength + whitespaceLength + wordLength;

                if (wordLength == 0)
                    break;
                if (newBucketLength > size)
                    break;

                bucketLength = newBucketLength;
            }

            result.Add(phrase.Substring(bucketStart, bucketLength));
            current = bucketStart + bucketLength;
        }

        return result;
    }

    private static void Task5()
    {
        Console.WriteLine("  TASK#5");
        Console.WriteLine(String.Join("|", Bucketize("она продает морские раковины у моря", 16)));
        Console.WriteLine(String.Join("|", Bucketize("мышь прыгнула через сыр", 8)));
        Console.WriteLine(String.Join("|", Bucketize("волшебная пыль покрыла воздух", 15)));
        Console.WriteLine(String.Join("|", Bucketize("a b c d e ", 2)));
    }

}
