List<string> numbeList = Console
    .ReadLine()
    .Split(separator: "|", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
List<string> appendedList = new List<string>();
for (int i = numbeList.Count - 1; i >= 0; i--)
{
    List<string> currNumbers = numbeList[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
    for (int k = 0; k < currNumbers.Count; k++)
    {
        appendedList.Add(currNumbers[k]);
    }
}
Console.WriteLine(string.Join(" ", appendedList));





