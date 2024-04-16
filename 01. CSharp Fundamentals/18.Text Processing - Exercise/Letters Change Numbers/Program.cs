namespace Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var englishAlphabetDictionary = new Dictionary<char, int>();
            int position = 1;
            for (char i = 'a'; i <='z'; i++)
            {
                englishAlphabetDictionary.Add(i, position);
                position++;
            }
            string input = Console.ReadLine();
            string [] texts = input
                .Split(new string[]{ " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            decimal totalSum = 0;

            foreach (string word in texts)
            {
                decimal result = 0;
                char letterBefore = word[0];
                char letterAfter = word[word.Length-1];
                ulong number = ulong.Parse(word.Substring(1, word.Length - 2));
                if (char.IsUpper(letterBefore)==true)
                {
                    decimal positionAtAlphabet= englishAlphabetDictionary[char.ToLower(letterBefore)];
                    result = number / positionAtAlphabet;
                    totalSum += result;
                }
                else if (char.IsLower(letterBefore)==true)
                {
                    decimal positionAtAlphabet = englishAlphabetDictionary[char.ToLower(letterBefore)];
                    result = number * positionAtAlphabet;
                    totalSum += result;
                }

                if (char.IsUpper(letterAfter) == true)
                {
                    decimal positionAtAlphabet = englishAlphabetDictionary[char.ToLower(letterAfter)];
                    
                    totalSum -= positionAtAlphabet;
                }
                else if (char.IsLower(letterAfter) == true)
                {
                    decimal positionAtAlphabet = englishAlphabetDictionary[char.ToLower(letterAfter)];
                    
                    totalSum += positionAtAlphabet;
                }

            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}