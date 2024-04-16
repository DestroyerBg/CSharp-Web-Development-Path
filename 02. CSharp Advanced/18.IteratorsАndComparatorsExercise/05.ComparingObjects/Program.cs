using _05.ComparingObjects;

var persons = new List<Person>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "END")
{
    string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string name = data[0];
    int age = int.Parse(data[1]);
    string town = data[2];
    persons.Add(new Person(name,age,town));
}

int equalPeople = 0;
Person personToCompare = persons[int.Parse(Console.ReadLine())-1];
foreach (var person in persons)
{
    if (person.CompareTo(personToCompare)==0)
    {
        equalPeople++;
    }
}

if (equalPeople>1)
{
    Console.WriteLine($"{equalPeople} {persons.Count-equalPeople} {persons.Count}");
}
else
{
    Console.WriteLine($"No matches");
}
