var tools = new Queue<int>
(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var substance = new Stack<int>
(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var challenges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
while (tools.Any() && substance.Any() && challenges.Any())
{
    int currTool = tools.Dequeue();
    int currSubstance = substance.Pop();
    int multiply = currTool * currSubstance;
    if (challenges.Any(v=>v == multiply))
    {
        challenges.Remove(challenges.Find(v => v == multiply));
    }
    else
    {
        currTool++;
        tools.Enqueue(currTool);
        currSubstance--;
        if (currSubstance > 0)
        { 
            substance.Push(currSubstance);
        }
    }
}

if ((!tools.Any() || !substance.Any()) && challenges.Any())
{
    Console.WriteLine($"Harry is lost in the temple. Oblivion awaits him.");
}

if (!challenges.Any())
{
    Console.WriteLine($"Harry found an ostracon, which is dated to the 6th century BCE.");
}

if (tools.Any())
{
    Console.WriteLine($"Tools: {string.Join(", ",tools)}");
}

if (substance.Any())
{
    Console.WriteLine($"Substances: {string.Join(", ", substance)}");
}
if (challenges.Any())
{
    Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
}
