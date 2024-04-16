namespace SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> database=new Dictionary<string, string>();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console
                    .ReadLine()
                    .Split(" ")
                    .ToArray();
                string argument= input[0];
                if (argument== "register")
                {
                string username= input[1];
                string licensePlateNumber= input[2];
                   bool checkIfUserIsRegistered= DataBaseCheck(database, username);
                   if (!checkIfUserIsRegistered)
                   {
                        database.Add(username, licensePlateNumber );
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                        continue;
                   }

                   Console.WriteLine($"ERROR: already registered with plate number {database[username]}");
                   
                }
                else if (argument == "unregister")
                {
                    string username= input[1];
                    bool checkIfUserIsRegistered = DataBaseCheck(database, username);
                    if (checkIfUserIsRegistered)
                    {
                        database.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                        continue;
                    }

                    Console.WriteLine($"ERROR: user {username} not found");
                }
            }

            foreach (var pair in database)
            {
                string username= pair.Key;
                string licensePlateNumber= pair.Value;
                Console.WriteLine($"{username} => {licensePlateNumber}");
            }
        }

        public static bool DataBaseCheck(Dictionary<string, string> database, string username)
        {
            var check= database.ContainsKey(username);
            if (check == true)
            {
                return true;
            }
            return false;
        }
    }
}