int numberOfUsernames = int.Parse(Console.ReadLine());
var uniqueUsernames = new HashSet<string>();
for (int i = 0; i < numberOfUsernames; i++)
{
    string input = Console.ReadLine();
    uniqueUsernames.Add(input);
}

Console.WriteLine(string.Join($"{Environment.NewLine}",uniqueUsernames));
