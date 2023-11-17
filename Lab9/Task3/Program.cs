using System.Diagnostics;

namespace Task3
{

    internal class SleepSortArgs
    {

        public string? Value { get; init; }

        public List<string>? ResultList { get; init; }

        public Mutex? ResultMutex { get; init; }

    }

    internal class Program
    {

        public static void SleepSort(object? obj)
        {
            Debug.Assert(obj != null);

            SleepSortArgs sleepSortArgs = (SleepSortArgs)obj;

            Debug.Assert(sleepSortArgs.Value != null);
            Debug.Assert(sleepSortArgs.ResultList != null);
            Debug.Assert(sleepSortArgs.ResultMutex != null);

            Thread.Sleep(sleepSortArgs.Value.Length * 10);

            // Case a) when we should instantly print to the console:
            // Console.WriteLine(sleepSortArgs.Value);
            
            // Case b) when we should collect result to the separate list:
            sleepSortArgs.ResultMutex.WaitOne();
            sleepSortArgs.ResultList.Add(sleepSortArgs.Value);
            sleepSortArgs.ResultMutex.ReleaseMutex();
        }

        public static void Main()
        {
            List<string> args = new List<string>();

            Console.WriteLine("Input sorting string or empty line, if input is completed:");

            while (true)
            {
                string? st = Console.ReadLine();

                if (st == null || st.Length == 0)
                {
                    break;
                }
                else
                {
                    args.Add(st);
                }
            }

            List<string> result = new List<string>(args.Count);
            List<Thread> threads = new List<Thread>(args.Count);
            Mutex resultMutex = new Mutex();

            foreach (var arg in args)
            {
                Thread thread = new Thread(SleepSort);
                threads.Add(thread);
                SleepSortArgs sleepSortArgs = new SleepSortArgs { Value = arg, ResultList = result, ResultMutex = resultMutex };
                thread.Start(sleepSortArgs);
            }

            threads.ForEach(thread => thread.Join());
            result.ForEach(Console.WriteLine);
        }

    }

}
