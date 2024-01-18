namespace Task1;

public class Program
{

    private const Int32 BEES_AMOUNT = 35;

    private const Int32 POT_MAX_SIZE = 10;

    private static Int32 currentPot = 0;

    private static Int32 beesDone = 0;

    private static Random random = new Random(123);

    private static void BearAction()
    {
        Console.WriteLine($"Bear ate all honey (Current pot: {currentPot})");
        currentPot = 0;
    }

    public static void Main()
    {
        Task[] tasks = new Task[BEES_AMOUNT];
        
        for (int beeNumber = 0; beeNumber < BEES_AMOUNT; beeNumber++)
        {
            tasks[beeNumber] = new Task(() => {
                Int32 repeats = random.Next(2, 4);
                
                for (int i = 0; i < repeats; i++)
                {
                    Task.Delay(random.Next(500, 2500)).Wait();
                    Console.WriteLine($"Bee filled the pot, pot size: {++currentPot}");
                    
                    if (currentPot == POT_MAX_SIZE)
                        BearAction();
                }

                beesDone++;

                if (beesDone == BEES_AMOUNT)
                    BearAction();
            });

            tasks[beeNumber].Start();
        }

        Task.WaitAll(tasks);
    }

}
