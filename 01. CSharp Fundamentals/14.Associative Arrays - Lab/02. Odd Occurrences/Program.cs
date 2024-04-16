namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console
                .ReadLine()
                .Split(" ")
                .ToArray();
            var countOddWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string currWordInLower = word.ToLower();
                if (!countOddWords.ContainsKey(currWordInLower))
                {
                    countOddWords.Add(currWordInLower, 0);
                }
                countOddWords[currWordInLower]++;
            }

            foreach (var word in countOddWords)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}