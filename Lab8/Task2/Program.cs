using System.Diagnostics;

namespace Task1;

public class Program
{

    private static List<String> lines1 = new List<string> {
        "Line#0, thread#1",
        "Line#1, thread#1",
        "Line#2, thread#1",
        "Line#3, thread#1",
        "Line#4, thread#1",
        "Line#5, thread#1",
        "Line#6, thread#1",
        "Line#7, thread#1",
        "Line#8, thread#1",
        "Line#9, thread#1",
    };

    private static List<String> lines2 = new List<string> {
        "Line#0, thread#2",
        "Line#1, thread#2",
        "Line#2, thread#2",
        "Line#3, thread#2",
        "Line#4, thread#2",
        "Line#5, thread#2",
        "Line#6, thread#2",
        "Line#7, thread#2",
        "Line#8, thread#2",
        "Line#9, thread#2",
    };

    private static AutoResetEvent? locker1;

    private static AutoResetEvent? locker2;

    private static void Function1()
    {
        Debug.Assert(locker1 != null);
        Debug.Assert(locker2 != null);
        
        foreach (String line in lines1)
        {
            locker1.WaitOne();
            Console.WriteLine(line);
            Thread.Sleep(12);
            locker2.Set();
        }
    }

    private static void Function2()
    {
        Debug.Assert(locker1 != null);
        Debug.Assert(locker2 != null);

        foreach (String line in lines2)
        {
            locker2.WaitOne();
            Console.WriteLine(line);
            Thread.Sleep(21);
            locker1.Set();
        }
    }

    public static void Main()
    {
        locker1 = new AutoResetEvent(true);
        locker2 = new AutoResetEvent(false);
        var thread1 = new Thread(Function1);
        var thread2 = new Thread(Function2);
        thread1.Start();
        thread2.Start();
        thread1.Join(1000);
        thread2.Join(1000);
        locker1.Dispose();
        locker2.Dispose();
    }

}
