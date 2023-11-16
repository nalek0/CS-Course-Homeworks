using System.Diagnostics;

namespace Task2
{

    public class Foo
    {
        public AutoResetEvent First { get; } = new AutoResetEvent(true);

        public AutoResetEvent Second { get; } = new AutoResetEvent(false);

        public AutoResetEvent Third { get; } = new AutoResetEvent(false);

        public void first() => Console.WriteLine("first");
        public void second() => Console.WriteLine("second");
        public void third() => Console.WriteLine("third");
    }

    internal class MainClass
    {

        public static void A(object foo)
        {
            Foo instance = (Foo)foo;
            instance.First.WaitOne();
            instance.first();
            instance.First.Close();
            instance.Second.Set();
        }

        public static void B(object foo)
        {
            Foo instance = (Foo)foo;
            instance.Second.WaitOne();
            instance.second();
            instance.Second.Close();
            instance.Third.Set();
        }

        public static void C(object foo)
        {
            Foo instance = (Foo)foo;
            instance.Third.WaitOne();
            instance.third();
            instance.Third.Close();
        }

        public static void Main(string[] args)
        {
            int arg1, arg2, arg3;
            Foo instance = new Foo();

            Debug.Assert(args.Length == 3);
            Debug.Assert(int.TryParse(args[0], out arg1));
            Debug.Assert(int.TryParse(args[1], out arg2));
            Debug.Assert(int.TryParse(args[2], out arg3));

            List<Thread> threads = new List<Thread>
            {
                new Thread(A),
                new Thread(B),
                new Thread(C)
            };

            threads[arg1 - 1].Start(instance);
            threads[arg2 - 1].Start(instance);
            threads[arg3 - 1].Start(instance);

            threads.ForEach(t => t.Join());
        }

    }

}
