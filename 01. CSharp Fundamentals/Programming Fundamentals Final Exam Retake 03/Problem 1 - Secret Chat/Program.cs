using System.Text;

namespace Problem_1___Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage= Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] arguments = input
                    .Split(":|:")
                    .ToArray();
                string instruction= arguments[0];
                if (instruction== "InsertSpace")
                {
                    int index= int.Parse(arguments[1]);
                    concealedMessage = concealedMessage.Insert(index, " ");
                    Console.WriteLine($"{concealedMessage}");
                }
                else if (instruction == "Reverse")
                {
                    string substring= arguments[1];
                    concealedMessage = ReverseMessage(concealedMessage, substring);
                    
                }
                else if (instruction== "ChangeAll")
                {
                    string substring= arguments[1];
                    string replacement= arguments[2];
                    while (concealedMessage.Contains(substring))
                    {
                        concealedMessage=concealedMessage.Replace(substring, replacement);
                    }
                    Console.WriteLine($"{concealedMessage}");
                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }

        public static string ReverseMessage(string concealedMessage, string substring)
        {
            if (concealedMessage.Contains(substring))
            {
                int index= concealedMessage.IndexOf(substring);
                string removedPart= concealedMessage.Substring(index, substring.Length);
                concealedMessage=concealedMessage.Remove(index, substring.Length);
                StringBuilder sb= new StringBuilder();
                for (int i = removedPart.Length-1; i >= 0; i--)
                {
                    sb.Append(removedPart[i]);
                }
                string reverse= sb.ToString();
                concealedMessage=concealedMessage+reverse;
                Console.WriteLine($"{concealedMessage}");
                return concealedMessage;
            }

            Console.WriteLine($"error");
            return concealedMessage;
        }
    }
}