
namespace Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> countCharacters = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                if (currChar == ' ')
                {
                    continue;
                }

                if (!countCharacters.ContainsKey(currChar))
                {
                    countCharacters.Add(currChar, 0);

                }
                countCharacters[currChar]++;
            }

            foreach (var pair in countCharacters)
            {
                char character = pair.Key;
                int count = pair.Value;
                Console.WriteLine($"{character} -> {count}");
            }
        }

    }


}