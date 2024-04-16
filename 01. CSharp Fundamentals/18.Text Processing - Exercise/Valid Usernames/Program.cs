namespace Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console
                .ReadLine()
                .Split(", ")
                .ToArray();
            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i].Length<3 || usernames[i].Length>16)
                {
                    continue;
                }

                bool usernameCheck = usernames[i].All(x => char.IsLetterOrDigit(x) || x.Equals('_') || x.Equals('-'));
                if (usernameCheck==true)
                {
                    Console.WriteLine($"{usernames[i]}");
                }
            }
        }
    }
}