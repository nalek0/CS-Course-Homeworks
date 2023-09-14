namespace Task3
{

    class MainClass
    {

        public static void Main()
        {
            MyStask stask = new MyStask();

            stask.Add(3);
            Console.WriteLine($"[ 3 ] :         Min = {stask.GetMinValue()}");
            stask.Add(2);
            Console.WriteLine($"[ 3, 2 ] :      Min = {stask.GetMinValue()}");
            stask.Add(1);
            Console.WriteLine($"[ 3, 2, 1 ] :   Min = {stask.GetMinValue()}");
            stask.Pop();
            Console.WriteLine($"[ 3, 2 ] :      Min = {stask.GetMinValue()}");
        }

    }

}