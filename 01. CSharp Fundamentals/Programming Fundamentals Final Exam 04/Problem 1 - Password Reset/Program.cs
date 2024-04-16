using System.Collections.Specialized;
using System.Text;

namespace Problem_1___Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] arguments = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = arguments[0];
                if (instruction == "TakeOdd")
                {
                    password = TakeOdd(password);
                }
                else if (instruction == "Cut")
                {
                    int index = int.Parse(arguments[1]);
                    int length = int.Parse(arguments[2]);
                    password = Cut(index, length, password);

                }
                else if (instruction == "Substitute")
                {
                    string substring = arguments[1];
                    string substitute = arguments[2];
                    password = Substitute(substring, substitute, password);
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }

        private static string Substitute(string substring, string substitute, string password)
        {
            if (password.Contains(substring))
            {
                while (password.Contains(substring))
                {
                    password = password.Replace(substring, substitute);
                }

                Console.WriteLine(password);
                return password;
            }

            Console.WriteLine($"Nothing to replace!");
            return password;
        }

        private static string Cut(int index, int length, string password)
        {
            string cut = password.Substring(index, length);
            password = password.Remove(index, length);
            Console.WriteLine(password);
            return password;
        }

        private static string TakeOdd(string password)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < password.Length; i += 2)
            {
                sb.Append(password[i]);
            }
            string concat = sb.ToString();
            password = concat;
            Console.WriteLine(password);
            return password;
        }
    }
}