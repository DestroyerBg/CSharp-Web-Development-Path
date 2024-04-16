using System.Threading.Channels;

var numCollection = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();
Func<List<int>,string, List<int>> appliedArithmetic = (numCollection, condition) =>
{
    var newCollection = numCollection;
    if (condition == "add")
    {
        for (int i = 0; i < numCollection.Count; i++)
        {
            newCollection[i]++;
        }
    }
    else if (condition == "multiply")
    {
        for (int i = 0; i < numCollection.Count; i++)
        {
            newCollection[i]*=2;
        }
    }
    else if (condition == "subtract")
    {
        for (int i = 0; i < numCollection.Count; i++)
        {
            newCollection[i]--;
        }
    }
    else if (condition == "print")
    {
        string print = string.Join(" ", numCollection);
        Console.WriteLine(print);
    }

    numCollection = newCollection;
    return numCollection;
};
string input = string.Empty;
while ((input = Console.ReadLine()) != "end")
{
    appliedArithmetic(numCollection, input);
}