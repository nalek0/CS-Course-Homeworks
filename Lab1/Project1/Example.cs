namespace Lab1
{

    class RunClass
    {

        public static void Main()
        {
            MyHashTable table = new MyHashTable();

            Console.WriteLine($"Add 1:      {table.Add(1)}");
            Console.WriteLine($"Add 2:      {table.Add(2)}");
            Console.WriteLine($"Add 3:      {table.Add(3)}");
            Console.WriteLine($"Add 1:      {table.Add(1)}");
            Console.WriteLine($"Remove 4:   {table.Remove(4)}");
            Console.WriteLine($"Remove 1:   {table.Remove(1)}");
            Console.WriteLine($"Contains 1: {table.Contains(1)}");
            Console.WriteLine($"Contains 2: {table.Contains(2)}");
            Console.WriteLine($"Contains 3: {table.Contains(3)}");
            Console.WriteLine($"Contains 4: {table.Contains(4)}");
        }

    }

}
