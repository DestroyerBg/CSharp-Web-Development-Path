var uniqueNames = new HashSet<string>();
int numberOfNames = int.Parse(Console.ReadLine());
for (int i = 0; i < numberOfNames; i++)
{
    uniqueNames.Add(Console.ReadLine());
}

foreach (var name in uniqueNames)
{
    Console.WriteLine(name);
}