using System.Security.Cryptography.X509Certificates;

namespace Task2;

public sealed class Table
{

    public object Lock { get; } = new();

    public Int32 Size { get; }

    public List<Entity> entities { get; }

    private Random random;

    public Table(Int32 size)
    {
        this.Size = size;
        this.random = new Random(123);
        this.entities = new List<Entity> {
            new Entity(random.Next(0, size), random.Next(0, size), true, this),
            new Entity(random.Next(0, size), random.Next(0, size), true, this),
            new Entity(random.Next(0, size), random.Next(0, size), true, this),
            new Entity(random.Next(0, size), random.Next(0, size), false, this),
        };
    }

    public void Move(Entity entity)
    {
        entity.X += random.Next(-1, 2);
        entity.Y += random.Next(-1, 2);
        entity.X = Math.Max(0, entity.X);
        entity.X = Math.Min(Size - 1, entity.X);
        entity.Y = Math.Max(0, entity.Y);
        entity.Y = Math.Min(Size - 1, entity.Y);
    }

    public void CheckCollisions(int x, int y)
    { 
        List<Entity> cellEntities = entities.Where(entity => entity.X == x && entity.Y == y).ToList();

        if (cellEntities.Count > 1)
        {
            bool areAllSheets = cellEntities.All(entity => entity.IsSheep);

            if (areAllSheets)
            {
                Entity newSheep = new Entity(x, y, true, this);
                entities.Add(newSheep);
                newSheep.MovementThread.Start();
            }
            else
            {
                List<Entity> sheeps = cellEntities.Where(entity => entity.IsSheep).ToList();
                sheeps.ForEach(sheep => sheep.MovementThread.Interrupt());
                sheeps.ForEach(sheep => entities.Remove(sheep));
            }
        }
    }

    public void LogState()
    {
        List<List<char>> state = new List<List<char>>();

        for (int i = 0; i < Size; i++)
        {
            List<char> line = new List<char>();

            for (int j = 0; j < Size; j++)
                line.Add('.');

            state.Add(line);
        }

        foreach (Entity entity in entities)
        {
            if (entity.IsSheep && state[entity.X][entity.Y] == '.')
                state[entity.X][entity.Y] = '1';
            else if (entity.IsSheep && state[entity.X][entity.Y] != '.')
                state[entity.X][entity.Y]++;
            else
                state[entity.X][entity.Y] = 'w';
        }

        Console.WriteLine();
        Console.WriteLine(new String('-', Size + 2));

        foreach (List<char> line in state)
        {
            Console.Write('|');
            Console.Write(String.Join("", line));
            Console.Write('|');
            Console.WriteLine();
        }

        Console.WriteLine(new String('-', Size + 2));
    }

    public void Start()
    {
        entities.ForEach(e => e.MovementThread.Start());
    }

}