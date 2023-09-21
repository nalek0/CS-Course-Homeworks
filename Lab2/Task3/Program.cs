namespace Task3
{

    public static class MainClass
    {
        
        public static void Main()
        {
            var entity = new BuffedEntity();
            entity.Eat(1);
            entity.Move(1, 0);

            Console.WriteLine("Entity: x={0}, y={1}, satiety={2}", entity.X, entity.Y, entity.Satiety);
        }

    }

}