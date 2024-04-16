using System.Text;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer  = new StreamWriter(outputFilePath);
            int count = 0;
            StringBuilder result = new StringBuilder();
            string currRow = string.Empty;
            using (reader)
            {
                while (currRow!=null)
                {
                    currRow = reader.ReadLine();
                    if (count % 2  == 1)
                    {
                        result.AppendLine(currRow);
                    }

                    count++;
                }
            }

            using (writer)
            {
                writer.WriteLine(result.ToString());
            }
        }
    }
}