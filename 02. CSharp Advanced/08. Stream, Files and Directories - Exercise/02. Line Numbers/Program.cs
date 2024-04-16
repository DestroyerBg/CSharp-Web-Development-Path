using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers;

public class LineNumbers
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";
        string outputFilePath = @"..\..\..\output.txt";

        ProcessLines(inputFilePath, outputFilePath);
    }

    public static void ProcessLines(string inputFilePath, string outputFilePath)
    {
        StringBuilder result = new StringBuilder();
        int count = 1;
        string[] lines = File.ReadAllLines(inputFilePath);
        int lettersCount = 0;
        int punktuationCount = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string currRow = lines[i];
            for (int j = 0; j < currRow.Length; j++)
            {
                if (char.IsLetter(currRow[j]))
                {
                    lettersCount++;
                }
                else if (char.IsPunctuation(currRow[j]))
                {
                    punktuationCount++;
                }
            }

            result.AppendLine($"Line {count++}: -{currRow} ({lettersCount})({punktuationCount})");
        }

        File.WriteAllText(outputFilePath, result.ToString());
    }
}