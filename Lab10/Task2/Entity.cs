using System.Linq.Expressions;

namespace Task2;

public sealed class Entity
{

    public int X { get; set; }

    public int Y { get; set; }

    public bool IsSheep { get; }

    public Thread MovementThread { get; }

    private Table table;

    private int delay;

    public Entity(int x, int y, bool isSheep, Table table)
    {
        this.X = x;
        this.Y = y;
        this.IsSheep = isSheep;
        this.MovementThread = new Thread(MovementCycle);
        this.table = table;
        this.delay = new Random().Next(250, 500);
    }

    private void MovementCycle()
    {
        while (true)
        {
            try
            {
                Thread.Sleep(delay);
            }
            catch (ThreadInterruptedException)
            {
                break;
            }


            lock (table.Lock)
            {
                table.Move(this);
                table.CheckCollisions(X, Y);
                table.LogState();
            }
        }
    }

}