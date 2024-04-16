using System.ComponentModel;
using System.Text;

namespace Problem_1___Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] arguments = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = arguments[0];
                if (instruction == "Contains")
                {
                    string substring = arguments[1];
                    Contains(rawKey, substring);
                }
                else if (instruction == "Flip")
                {
                    string flipInstruction = arguments[1];
                    int startIndex = int.Parse(arguments[2]);
                    int endIndex = int.Parse(arguments[3]);
                    rawKey = Flip(rawKey, flipInstruction, startIndex, endIndex);
                }
                else if (instruction == "Slice")
                {
                    int startIndex = int.Parse(arguments[1]);
                    int endIndex = int.Parse(arguments[2]);
                    rawKey = Slice(rawKey, startIndex, endIndex);
                }
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }

        private static string Slice(string rawKey, int startIndex, int endIndex)
        {
            rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
            Console.WriteLine(rawKey);
            return rawKey;
        }

        private static string Flip(string rawKey, string flipInstruction, int startIndex, int endIndex)
        {
            StringBuilder sb= new StringBuilder();
            if (flipInstruction == "Upper")
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    char currChar = rawKey[i];
                    if (char.IsLetter(currChar))
                    {
                        char flipped = char.ToUpper(currChar);
                       sb.Append(flipped);
                    }
                    else
                    {
                        sb.Append(currChar);
                    }
                    
                }
                rawKey= rawKey.Remove(startIndex, endIndex - startIndex);
                rawKey = rawKey.Insert(startIndex, sb.ToString());

            }
            else if (flipInstruction == "Lower")
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    char currChar = rawKey[i];
                    if (char.IsLetter(currChar))
                    {
                        char flipped = char.ToLower(currChar);
                        sb.Append(flipped);
                    }

                    else
                    {
                        sb.Append(currChar);
                    }
                }
                rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                rawKey = rawKey.Insert(startIndex, sb.ToString());
            }
            Console.WriteLine(rawKey);
            return rawKey;
        }

        private static void Contains(string rawKey, string substring)
        {
            if (rawKey.Contains(substring))
            {
                Console.WriteLine($"{rawKey} contains {substring}");
            }
            else
            {
                Console.WriteLine($"Substring not found!");
            }
        }
    }
}