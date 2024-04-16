int end = int.Parse(Console.ReadLine());
var allDividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int start = 1;
Func<int, int, List<int>> generateRange = (start, end) => 
{
    var range = new List<int>();
    for (int i = start; i <= end; i++)
    {
        range.Add(i);
    }
    return range;
};
Func<List<int>, int[], List<int>> getAllNumbers  = (range, allDividers) =>
{
    var newCollection = new List<int>();
    for (int i = 0; i < range.Count; i++)
    {
        bool isDivisible = false;
        for (int j = 0; j < allDividers.Length; j++)
        {
            if (range[i] % allDividers[j]== 0)
            {
                isDivisible = true;
                continue;
            }

            isDivisible = false;
            break;
        }

        if (isDivisible == true)
        {
            newCollection.Add(range[i]);
        }
    }
    return newCollection;
};
var range = generateRange(start, end);
Console.WriteLine(string.Join(" ", getAllNumbers(range,allDividers)));