using System.Text;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var findWordReader = new StreamReader(wordsFilePath);
            string currWord = findWordReader.ReadToEnd();
            string[] allWords = currWord.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var rowReader = new StreamReader(textFilePath);
            string currRow = string.Empty;
            var counter = new Dictionary<string, int>();
            using (rowReader)
            {
                currRow = rowReader.ReadToEnd();
                char[] separators = new[] {' ', ',','.', '!', '-','?' };
                string[] data = currRow.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < data.Length; i++)
                {
                    string curr = data[i].ToLower().Trim().TrimEnd(' ', ',', '.', '!','-').TrimStart(' ', ',', '.', '!','-');
                    if (allWords.Contains(curr))
                    {
                        if (!counter.ContainsKey(curr))
                        {
                            counter.Add(curr, 0);
                        }
                        counter[curr]++;
                    }
                }
            }
            var sortedDictionary = counter.OrderByDescending(x => x.Value);
            StringBuilder result = new StringBuilder();
            foreach (var word in sortedDictionary)
            {
                result.AppendLine($"{word.Key} - {word.Value}");
            }

            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                writer.Write(result.ToString().Trim());
            }
        }
    }
}