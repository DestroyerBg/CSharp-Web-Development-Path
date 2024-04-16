int[] arr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int n = arr[0];
int m = arr[1];
var firstSet = new HashSet<int>();
var secondSet = new HashSet<int>();
for (int i = 0; i < n; i++)
{
    firstSet.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < m; i++)
{
    secondSet.Add(int.Parse(Console.ReadLine()));
}

foreach (var number in firstSet)
{
    if (secondSet.Contains(number))
    {
        Console.Write($"{number} ");
    }
}


