int[] numbers = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int[] results = new int[numbers.Length - 1];
for (int i = numbers.Length - 1; i >= 1; i--)
{
    for (int j = 0; j < i; j++)
    {
        results[j] = numbers[j] + numbers[j + 1];
        
    }
    numbers = results;
}
Console.WriteLine(numbers[0]);



