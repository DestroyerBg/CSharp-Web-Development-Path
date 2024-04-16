using System.Text.RegularExpressions;

namespace Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string emailPattern = @"[^\-\.\-_]\b(?![\._\-])[A-Za-z0-9]+[\.\-_]*[A-Za-z0-9]+\@[^\-\.\-_](?:[A-Za-z\.\-]+\.)+[A-Za-z]+";
            MatchCollection matchEmails = Regex.Matches(input, emailPattern);
            for (int i = 0; i < matchEmails.Count; i++)
            {
                Console.WriteLine($"{matchEmails[i].Value.Trim(',', ' ', '\n')}");
            }

        }
    }
}