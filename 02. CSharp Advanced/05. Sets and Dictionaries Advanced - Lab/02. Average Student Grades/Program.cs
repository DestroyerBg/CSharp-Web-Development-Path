int numberOfStudents = int.Parse(Console.ReadLine());
var studentsInformation = new Dictionary<string, List<decimal>>();
for (int i = 0; i < numberOfStudents; i++)
{
    string[] data = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string name = data[0];
    decimal grade = decimal.Parse(data[1]);
    if (!studentsInformation.ContainsKey(name))
    {
        studentsInformation.Add(name, new List<decimal>());
    }
    studentsInformation[name].Add(grade);
}

foreach (var student in studentsInformation)
{
    Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(g=>$"{g:F2}"))} (avg: {student.Value.Average():f2})");
}