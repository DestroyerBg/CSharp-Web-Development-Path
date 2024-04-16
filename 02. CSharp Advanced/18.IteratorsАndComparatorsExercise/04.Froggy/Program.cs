using _04.Froggy;

int[] path = Console.ReadLine()
    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
var frogWay = new Lake(path);
var frogFinalPath = new List<int>();
foreach (var stone in frogWay)
{
    frogFinalPath.Add(stone);
}

Console.WriteLine(string.Join(", ", frogFinalPath));