using _06.EqualityLogic;

int numberOfInputs = int.Parse(Console.ReadLine());
var sortedSet = new SortedSet<Person>();
var hashSet = new HashSet<Person>();
for (int i = 0; i < numberOfInputs; i++)
{
    string[] data = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string name = data[0];
    int age = int.Parse(data[1]);
    sortedSet.Add(new Person(name, age));
    hashSet.Add(new Person(name, age));
}

Console.WriteLine(sortedSet.Count);
Console.WriteLine(hashSet.Count);