namespace Task3;

public class Program
{

    private static void PrintList<T>(IEnumerable<T> list)
    {
        foreach (var item in list)
            Console.Write("{0} -> ", item);
        Console.WriteLine("|");
    }

    public static void Main()
    {
        var list = new MyLinkedList<int> { 1, 2, 3, 4 };

        PrintList(list);

        list.Add(5);
        list.Add(1);
        list.Add(1);

        PrintList(list);

        list.Remove(1);

        PrintList(list);

        list.Remove(1);

        PrintList(list);
    }

}
