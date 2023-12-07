using System;
using System.IO;
using System.Text;

namespace Task1
{
    
    internal class MainClass
    {

        private const int NUMBERS = 10_000_000;

        private const int NUMBER_LIMIT = 100_000_000;

        private const int NUMBER_LENGTH = 8;

        private const int SEED = 123;

        public static void Main(string[] args)
        {
            using (FileStream fileStream = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                Random random = new Random(SEED);

                for (int i = 0; i < NUMBERS; i++)
                {
                    string line = random.Next(NUMBER_LIMIT).ToString();
                    string zeroes = new string('0', NUMBER_LENGTH - line.Length);
                    line = zeroes + line + '\n';
                    byte[] bytes = Encoding.Default.GetBytes(line);
                    fileStream.Write(bytes, 0, bytes.Length);
                }

                Console.WriteLine("Output file: " + fileStream.Name);
            }
        }

    }

}
