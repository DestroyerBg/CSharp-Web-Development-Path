namespace Problem_1___World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string busStops=Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] arguments = input.Split(new char[] { ' ', ':' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                string instruction= arguments[0];
                if (instruction == "Add")
                {
                    int index= int.Parse(arguments[2]);
                    string busStop= arguments[3];
                    busStops=AddStops(index, busStop,busStops);
                    Console.WriteLine($"{busStops}");
                }
                else if (instruction=="Remove")
                {
                    int startIndex= int.Parse(arguments[2]);
                    int endIndex= int.Parse(arguments[3]);
                    busStops=RemoveStops(startIndex, endIndex,busStops);
                    Console.WriteLine($"{busStops}");
                }
                else if (instruction=="Switch")
                {
                    string oldStop= arguments[1];
                    string newStop= arguments[2];
                    busStops=SwitchStops(oldStop, newStop,busStops);
                    Console.WriteLine($"{busStops}");
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {busStops}");
        }

        public static string SwitchStops(string oldStop, string newStop, string busStops)
        {
            if (busStops.Contains(oldStop))
            {
               busStops=busStops.Replace(oldStop, newStop);
            }

            return busStops;
        }

        public static string RemoveStops(int startIndex, int endIndex, string busStops)
        {
            if ((startIndex>=0) && (startIndex<busStops.Length) 
                                && (endIndex >= 0) && (endIndex < busStops.Length))
            {
                int lenght = Math.Abs(endIndex - startIndex);
                busStops=busStops.Remove(startIndex, lenght+1);
            }
            return busStops;
        }

        public static string AddStops(int index, string busStop, string busStops)
        {
            if (index>=0 && index<busStops.Length)
            {
                busStops=busStops.Insert(index,busStop);
            }
            return busStops;
        }
    }
}