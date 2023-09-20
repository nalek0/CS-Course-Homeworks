namespace Task2
{

    public static class MainClass
    {
        
        public static void Main()
        {
            var tripple = new ImmutableTripple(1, 2, 3);
            var tripple1 = tripple.ChangeFirst(0);
            var tripple2 = tripple.ChangeSecond(0);
            var tripple3 = tripple.ChangeThird(0);
            var tripple000 = tripple.ChangeFirst(0).ChangeSecond(0).ChangeThird(0);

            Console.WriteLine(tripple);
            Console.WriteLine(tripple1);
            Console.WriteLine(tripple2);
            Console.WriteLine(tripple3);
            Console.WriteLine(tripple000);
        }

    }

}