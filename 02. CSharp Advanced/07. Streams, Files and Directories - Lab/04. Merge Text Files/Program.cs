using System.Net.Http.Headers;
using System.Text;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var firstFileReader = new StreamReader(firstInputFilePath);
            var secondFileReader = new StreamReader(secondInputFilePath);
            var outputFileWriter = new StreamWriter(outputFilePath);
            while (!firstFileReader.EndOfStream || !secondFileReader.EndOfStream)
            {
                if (!firstFileReader.EndOfStream)
                {
                    string currRow = firstFileReader.ReadLine();
                    outputFileWriter.WriteLine(currRow);
                }

                if (!secondFileReader.EndOfStream)
                {
                    string currRow = secondFileReader.ReadLine();
                    outputFileWriter.WriteLine(currRow);
                }
            }
        }
    }
}