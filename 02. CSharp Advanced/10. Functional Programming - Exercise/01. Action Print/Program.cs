using System.Threading.Channels;

string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
Action<string> print = c => Console.WriteLine(c.ToString());
for (int i = 0; i < input.Length; i++)
{
    print(input[i]);
}
