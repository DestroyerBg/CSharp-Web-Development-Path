using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);
            StringBuilder result = new StringBuilder();
            string currRow = string.Empty;
            using (reader)
            {
                int count = 1;
                while (currRow!=null)
                {
                    currRow = reader.ReadLine();
                    result.AppendLine($"{count++} {currRow}");
                }
            }

            using (writer)
            {
                writer.WriteLine(result.ToString());
            }
        }
    }
}

