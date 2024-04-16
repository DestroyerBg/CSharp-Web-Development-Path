using System.Security.Cryptography.X509Certificates;

Func<List<int>, int, List<int>> removeAndReverse = (numbers, divider) =>
{
    var newCollection = new List<int>();
    for (int i = 0; i < numbers.Count; i++)
    {
        if (numbers[i] % divider != 0)
        {
            newCollection.Add(numbers[i]);
        }
    }
    numbers = newCollection;
    numbers.Reverse();
    return numbers;
};
var numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();
int divider = int.Parse(Console.ReadLine());
Console.WriteLine(string.Join(" ",removeAndReverse(numbers,divider)));

