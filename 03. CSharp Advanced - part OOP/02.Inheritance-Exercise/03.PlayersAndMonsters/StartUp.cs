using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());
            DarkKnight darkKnight = new DarkKnight(username, level);
            Console.WriteLine(darkKnight.ToString());
        }
    }
}