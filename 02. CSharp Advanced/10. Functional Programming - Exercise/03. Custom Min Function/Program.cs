int[] numbers = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Func<int[],int> minNumber = numbers => numbers.Min();
Console.WriteLine(minNumber(numbers));