using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EvenLines
{
    using System;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder result = new StringBuilder();
            int count = 0;
            using (var reader = new StreamReader(inputFilePath))
            {
                string currRow = string.Empty;
                char[] replace = new char[] { '-', ',', '.', '!', '?' };
                while ((currRow = reader.ReadLine()) != null)
                {
                    if (count % 2 == 0)
                    {
                        for (int i = 0; i < currRow.Length; i++)
                        {
                            char currChar = currRow[i];
                            if (replace.Contains(currChar))
                            {
                                currRow = currRow.Replace(currChar, '@');
                            }
                        }

                        string[] allWordsInCurrRow = currRow
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                        var reversedRow = new List<string>();
                        for (int i = allWordsInCurrRow.Length - 1; i >= 0; i--)
                        {
                            reversedRow.Add(allWordsInCurrRow[i]);
                        }
                        string buildReversedRow = string.Join(" ", reversedRow);
                        result.AppendLine(buildReversedRow);
                    }
                    count++;
                }
            }
            return result.ToString();

        }
        }
    }

