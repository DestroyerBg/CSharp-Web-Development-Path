int n = int.Parse(Console.ReadLine());
var persons = new List<Person>();
for (int i = 0; i < n; i++)
{
    string[] data = Console.ReadLine().Split(", ").ToArray();
    string name = data[0];
    int age = int.Parse(data[1]);
    Person person = new Person(name, age);
    persons.Add(person);
}
string olderOrYounger = Console.ReadLine();
int ageThreshold = int.Parse(Console.ReadLine());
string[] infoForPeople = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
Func<Person, bool> filter = CreateFilter(olderOrYounger, ageThreshold);

Func<Person, bool> CreateFilter(string olderOrYounger, int ageThreshold)
{
    if (olderOrYounger == "older")
    {
        return x=>x.Age >=ageThreshold;
    }
    else if (olderOrYounger == "younger")
    {
        return x => x.Age < ageThreshold;
    }

    return null;
}

Action<Person> printer = CreatePrinter(infoForPeople);

Action<Person> CreatePrinter(string[] infoForPeople)
{
    if (infoForPeople.Length == 2)
    {
        return x=> Console.WriteLine($"{x.Name} - {x.Age}");
    }
    else if (infoForPeople.Length == 1)
    {
        if (infoForPeople[0]=="name")
        {
            return x => Console.WriteLine(x.Name);
        }
        else if (infoForPeople[0] == "age")
        {
            return x => Console.WriteLine(x.Age);
        }
    }

    return null;
}

PrintFilteredPeople(persons, filter, printer);

void PrintFilteredPeople(List<Person> persons, Func<Person, bool> filter, Action<Person> printer)
{
    var filtered = persons.Where(person => filter(person)).ToList();
    foreach (var person in filtered)
    {
        printer(person);
    }
}

class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }

    public int Age { get; set; }
}








