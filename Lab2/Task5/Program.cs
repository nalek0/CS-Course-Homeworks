namespace Task5
{

    public static class MainClass
    {

        public static void Main()
        {
            HeightsList heightsList = new HeightsList(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            Console.WriteLine(
                "Heights: [{0}]. Water collected: {1}",
                String.Join(", ", heightsList.Heights),
                heightsList.GetWaterAmount());
            
            HeightsList heightsList2 = new HeightsList(new int[] { 4, 2, 0, 3, 2, 5 });
            Console.WriteLine(
                "Heights: [{0}]. Water collected: {1}",
                String.Join(", ", heightsList2.Heights),
                heightsList2.GetWaterAmount());
        }

    }

}