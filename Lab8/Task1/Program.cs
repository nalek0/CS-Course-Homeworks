namespace Task1;

public class Program
{

    private static Object lock1 = new();

    private static Object lock2 = new();

    private static void Function1()
    {
        lock (lock1)
        {
            Console.WriteLine($"{DateTime.Now}..{DateTime.Now.Millisecond}: Function1 lock1 enter");

            Thread.Sleep(100);

            Console.WriteLine($"{DateTime.Now}..{DateTime.Now.Millisecond}: Function1 after a small sleep");

            lock (lock2)
            {
                Console.WriteLine($"{DateTime.Now}..{DateTime.Now.Millisecond}: Function1 lock2 enter");
            }
        }
    }

    private static void Function2()
    {
        lock (lock2)
        {
            Console.WriteLine($"{DateTime.Now}..{DateTime.Now.Millisecond}: Function2 lock2 enter");

            Thread.Sleep(100);

            Console.WriteLine($"{DateTime.Now}..{DateTime.Now.Millisecond}: Function2 after a small sleep");

            lock (lock1)
            {
                Console.WriteLine($"{DateTime.Now}..{DateTime.Now.Millisecond}: Function2 lock1 enter");
            }
        }
    }

    public static void Main()
    {
        var thread1 = new Thread(Function1);
        var thread2 = new Thread(Function2);

        thread1.Start();
        thread2.Start();

        if (!thread1.Join(1000) && !thread2.Join(1000))
        {
            Console.WriteLine($"{DateTime.Now}..{DateTime.Now.Millisecond}: Interrupting");

            thread1.Interrupt();
            thread2.Interrupt();
        }
    }

}
