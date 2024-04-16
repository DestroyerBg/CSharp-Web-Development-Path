int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .OrderByDescending(n=>n)
    .Take(3)
    .ToArray();
Console.WriteLine(string.Join(" ",numbers));