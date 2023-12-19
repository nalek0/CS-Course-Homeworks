namespace Task1;


public class Program
{

    private static void PrintLake(int size)
    {
        Console.WriteLine("Lake for {0}: ", size);
        
        foreach (int value in new Lake(size))
        {
            Console.Write("{0} ", value);
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        PrintLake(5);
        PrintLake(6);
        PrintLake(7);
        PrintLake(8);
    }

}
