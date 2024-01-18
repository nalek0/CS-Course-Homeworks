using System.Diagnostics.Contracts;

namespace Task2;

public class Program
{

    public static void Main()
    {
        List<Int32> list = new List<int>(3);
        list.Push(1);
        list.Push(2);
        list.Push(3);
        list.Push(4);
        list.Push(5);
        list.Push(6);
        list.Push(7);
        PrintList(list);
        
        Console.WriteLine($"Pop: {list.Pop()}");
        PrintList(list);
        Console.WriteLine($"Pop: {list.Pop()}");
        PrintList(list);
        Console.WriteLine($"Pop: {list.Pop()}");
        PrintList(list);
        Console.WriteLine($"Pop: {list.Pop()}");
        PrintList(list);
        Console.WriteLine($"Pop: {list.Pop()}");
        PrintList(list);
    }

    private static void PrintList<T>(List<T> list)
    {
        Console.WriteLine("--------");

        foreach (Stack<T> stack in list.GetSubstacks())
        {
            foreach (T value in stack)
            {
                Console.Write(value);
                Console.Write(" ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("--------");
    }

}
