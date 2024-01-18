namespace Task1;

public class FooBar
{

    private int n;

    public FooBar(int n)
    {
        this.n = n;
    }

    public void Foo(Action printFoo)
    {

        for (int i = 0; i < n; i++)
        {
            printFoo();
        }
    }

    public void Bar(Action printBar)
    {

        for (int i = 0; i < n; i++)
        {
            printBar();
        }
    }

}


public class Program
{

    private static Random random = new Random(222);

    private static AutoResetEvent locker1 = new AutoResetEvent(true);

    private static AutoResetEvent locker2 = new AutoResetEvent(false);

    private static void printFoo()
    {
        locker1.WaitOne();
        Console.Write("foo");
        Thread.Sleep(random.Next(10, 50));
        locker2.Set();
    }

    private static void printBar()
    {
        locker2.WaitOne();
        Console.WriteLine("bar");
        Thread.Sleep(random.Next(10, 50));
        locker1.Set();
    }

    public static void Main()
    {
        FooBar fooBar = new FooBar(5);
        Thread thread1 = new Thread(() => fooBar.Foo(printFoo));
        Thread thread2 = new Thread(() => fooBar.Bar(printBar));

        thread1.Start();
        thread2.Start();
        thread1.Join(1000);
        thread2.Join(1000);
    }

}
