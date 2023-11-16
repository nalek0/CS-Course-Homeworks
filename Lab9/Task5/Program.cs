using Task5;

MyCountdownEvent countdownEvent = new MyCountdownEvent(5);

void PrintThreadName()
{
    Console.WriteLine(Thread.CurrentThread.Name);
    countdownEvent.Signal();
}

List<Thread> initialThreads = new List<Thread>(5)
{
    new Thread(PrintThreadName),
    new Thread(PrintThreadName),
    new Thread(PrintThreadName),
    new Thread(PrintThreadName),
    new Thread(PrintThreadName)
};

for (int i = 0; i < 5; i++) {
    initialThreads[i].Name = "InitialThread#" + i;
}

initialThreads.ForEach(thread => thread.Start());
countdownEvent.Wait(TimeSpan.FromSeconds(1));
Console.WriteLine("End");