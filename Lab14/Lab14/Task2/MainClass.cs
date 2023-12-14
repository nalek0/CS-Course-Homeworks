
using System.Reflection;

namespace Task2
{

    class CustomAttribute : Attribute
    {

        public string[] Values { get; }

        public CustomAttribute(params string[] values)
        {
            this.Values = values;
        }

    }

    [Custom("Joe", "2", "Class to work with health data.", "Arnold", "Bernard")]
    public class HealthScore
    {

        [Custom("Andrew", "3", "Method to collect health data.", "Sam", "Alex")]
        public static long CalcScoreData()
        {
            return 123;
        }

    }

    public class MainClass
    {

        public static void Main()
        {
            Type classType = typeof(HealthScore);

            Console.WriteLine("HealthScore data:");
            PrintAttributes(classType.GetCustomAttributes(false));

            MemberInfo[] members = classType.GetMethods();

            foreach (MemberInfo memberInfo in members)
            {
                Console.WriteLine("{0} data:", memberInfo.Name);
                PrintAttributes(memberInfo.GetCustomAttributes(false));
            }
        }

        private static void PrintAttributes(object[] attributes)
        {
            bool containsData = false;

            foreach (Attribute attr in attributes)
            {
                if (attr is CustomAttribute customAttribute)
                {
                    containsData = true;

                    foreach (string value in customAttribute.Values)
                    {
                        Console.WriteLine("| {0}", value);
                    }
                }
            }

            if (!containsData)
            {
                Console.WriteLine("| No data");
            }
        }
    }

}
