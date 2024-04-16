using System.Text;

Predicate<string> checkIfUpper = Word => char.IsUpper(Word[0]);
string[] data = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
StringBuilder result = new StringBuilder();
for (int i = 0; i < data.Length; i++)
{
    if (checkIfUpper(data[i]))
    {
        result.AppendLine(data[i]);
    }
}

Console.WriteLine(result.ToString());


