int numberOfInputs = int.Parse(Console.ReadLine());
var periodicTable = new SortedSet<string>();
for (int i = 0; i < numberOfInputs; i++)
{
    string[] data = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    for (int j = 0; j < data.Length; j++)
    {
        periodicTable.Add(data[j]);
    }
}

Console.WriteLine(string.Join(" ",periodicTable));