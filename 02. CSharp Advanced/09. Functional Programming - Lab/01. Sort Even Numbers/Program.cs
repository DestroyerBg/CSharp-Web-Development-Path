int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .Where(n => n % 2 == 0)
    .ToArray();
Console.WriteLine(string.Join(", ", numbers.OrderBy(x=>x)));
  
