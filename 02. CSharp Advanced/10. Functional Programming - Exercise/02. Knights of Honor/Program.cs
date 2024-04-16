using System.Threading.Channels;

var names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
Action<string> print = name => Console.WriteLine($"Sir {name}");
names.ForEach(print);
