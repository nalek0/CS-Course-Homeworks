namespace Task1 {

    class MainClass {

        public static void Main() {
            MyHashTable table = new MyHashTable();

            Console.WriteLine("Add 1: {0}", table.Add(1));
            Console.WriteLine("Add 2: {0}", table.Add(2));
            Console.WriteLine("Add 3: {0}", table.Add(3));
            Console.WriteLine("Contains 1: {0}", table.Contains(1));
            Console.WriteLine("Contains 2: {0}", table.Contains(2));
            Console.WriteLine("Contains 3: {0}", table.Contains(3));
            Console.WriteLine("Contains 4: {0}", table.Contains(4));
            Console.WriteLine("Remove 3: {0}", table.Remove(3));
            Console.WriteLine("Remove 4: {0}", table.Remove(4));
            Console.WriteLine("Remove 3: {0}", table.Remove(3));
            Console.WriteLine("Contains 1: {0}", table.Contains(1));
            Console.WriteLine("Contains 2: {0}", table.Contains(2));
            Console.WriteLine("Contains 3: {0}", table.Contains(3));
            Console.WriteLine("Contains 4: {0}", table.Contains(4));
        }

    }

}