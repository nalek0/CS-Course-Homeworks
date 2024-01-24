namespace Lab15;

public class Program
{

    private static void Example1()
    {
        MyCache<ExampleObject> cache = new MyCache<ExampleObject>(5, TimeSpan.FromMilliseconds(180));
        cache.Register();

        cache.Add(new ExampleObject("Object#1"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#2"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#3"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#4"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#5"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#6"));

        cache.Unregister();
    }

    private static void Example2()
    {
        MyCache<ExampleObject> cache = new MyCache<ExampleObject>(5, TimeSpan.FromMilliseconds(180));
        cache.Register();

        cache.Add(new ExampleObject("Object#1"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#2"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#3"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#4"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#5"));
        Thread.Sleep(50);

        Console.WriteLine("Accessing " + cache[1].ToString());
        Thread.Sleep(50);

        cache.Add(new ExampleObject("Object#6"));

        cache.Unregister();
    }

    private static void Example3()
    {
        MyCache<ExampleObject> cache = new MyCache<ExampleObject>(5, TimeSpan.FromMilliseconds(180));
        cache.Register();

        cache.Add(new ExampleObject("Object#1"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#2"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#3"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#4"));
        Thread.Sleep(50);
        cache.Add(new ExampleObject("Object#5"));
        Thread.Sleep(50);

        try
        {
            List<byte[]> load = new List<byte[]>();
            bool bAllocate = true;
            int lastCollCount = 0;
            int newCollCount = 0;

            while (true)
            {
                if (bAllocate)
                {
                    load.Add(new byte[1000]);
                    newCollCount = GC.CollectionCount(2);

                    if (newCollCount != lastCollCount)
                    {
                        Console.WriteLine("Gen 2 collection count: {0}", GC.CollectionCount(2).ToString());
                        lastCollCount = newCollCount;
                    }

                    if (newCollCount == 20)
                    {
                        break;
                    }
                }
            }
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Out of memory.");
        }

        cache.Unregister();
    }

    public static void Main()
    {
        // Example1();
        // Example2();
        Example3();
    }

}
