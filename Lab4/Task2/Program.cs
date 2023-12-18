namespace Task2
{

    internal interface Student
    {

        public void Rest(int seconds);

    }

    internal interface Worker
    {

        public void Rest(int seconds);

    }

    internal abstract class Average20YearOldMan
    {

        public abstract void Rest(int seconds);

    }

    internal class JohnDoe : Average20YearOldMan, Worker, Student
    {

        public override void Rest(int seconds)
        {
            Console.WriteLine($"Resting in a bar for {seconds} seconds");
        }

        void Worker.Rest(int seconds)
        {
            Console.WriteLine($"Watching tv for {seconds} seconds");
        }

        void Student.Rest(int seconds)
        {
            Console.WriteLine($"Sleeping for {seconds} seconds");
        }

    }

    public class Program
    {

        public static void Main()
        {
            JohnDoe john = new JohnDoe();
            Student asStudent = john;
            Worker asWorker = john;
            john.Rest(10);
            asStudent.Rest(11);
            asWorker.Rest(12);
        }

    }

}
