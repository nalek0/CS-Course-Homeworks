using System.Reflection;
using System.Text.RegularExpressions;

namespace Task1
{

    public class BlackBox
    {
        private int innerValue;

        private BlackBox(int innerValue)
        {
            this.innerValue = innerValue; // Changed this line because it looked like a mistake
        }

        private BlackBox()
        {
            this.innerValue = 0; // Changed this line because it looked like a mistake
        }

        private void Add(int addend)
        {
            this.innerValue += addend;
        }

        private void Subtract(int subtrahend)
        {
            this.innerValue -= subtrahend;
        }

        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }

        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }

    }

    public class Class
    {

        private static object? InitialiseBox()
        {
            Type type = typeof(BlackBox);
            ConstructorInfo? constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, new Type[0]);

            if (constructorInfo == null)
            {
                return null;
            }
            else
            {
                return constructorInfo.Invoke(new object[0]);
            }
        }

        private static void PrintState(object instance)
        {
            Type type = typeof(BlackBox);
            FieldInfo? fieldInfo = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (fieldInfo == null)
            {
                Console.WriteLine("Cannot file field 'innerValue'");
            }
            else
            {
                Console.WriteLine(fieldInfo?.GetValue(instance));
            }
        }

        private static void InvokeMethod(object instance, string method, string attributes)
        {
            Type type = typeof(BlackBox);
            MethodInfo? methodInfo = type.GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (methodInfo == null)
            {
                Console.WriteLine($"No method '{method}' found");
            }
            else
            {
                methodInfo.Invoke(instance, new object[] { int.Parse(attributes) });

                PrintState(instance);
            }
        }

        private static void IterateInput(object instance)
        {
            string linePattern = @"(?<method>\w+)\((?<attributes>.*)\)";

            while (true)
            {
                string? line = Console.ReadLine();

                if (line == null || line.Trim().Equals(":q"))
                {
                    break;
                }
                else
                {
                    Match match = Regex.Match(line, linePattern);

                    if (match.Success)
                    {
                        string method = match.Groups.GetValueOrDefault("method")?.Value ?? "";
                        string attributes = match.Groups.GetValueOrDefault("attributes")?.Value ?? "";

                        InvokeMethod(instance, method, attributes);
                    }
                    else
                    {
                        Console.WriteLine("Invalid line.");
                    }
                }
            }
        }

        public static void Main()
        {
            object? instance = InitialiseBox();

            if (instance == null)
            {
                Console.WriteLine("Cannot find type constructor.");
                Environment.Exit(1);
            }
            else
            {
                IterateInput(instance);
            }
        }

    }

}
