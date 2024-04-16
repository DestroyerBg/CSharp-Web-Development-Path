var textiles = new Queue<int>
(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
 var medicaments = new Stack<int>
(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var healingItems = new Dictionary<string,int>();
healingItems.Add("Patch",0);
healingItems.Add("Bandage", 0);
healingItems.Add("MedKit", 0);
while (textiles.Any() && medicaments.Any())
{
    int currTextile = textiles.Dequeue();
    int currMedicament = medicaments.Pop();
    if (currTextile+currMedicament == 30)
    {
        healingItems["Patch"]++;
    }
    else if (currTextile + currMedicament == 40)
    {
        healingItems["Bandage"]++;
    }
    else if (currTextile + currMedicament == 100)
    {
        healingItems["MedKit"]++;
    }
    else if (currTextile + currMedicament > 100)
    {
        healingItems["MedKit"]++;
        if (medicaments.Any())
        {
            medicaments.Push(medicaments.Pop()+((currMedicament+currTextile)-100));
            continue;
        }
        
    }
    else
    {
        currMedicament += 10;
        medicaments.Push(currMedicament);
    }
}

if (!medicaments.Any() && !textiles.Any())
{
    Console.WriteLine($"Textiles and medicaments are both empty.");
}
else if (!medicaments.Any())
{
    Console.WriteLine($"Medicaments are empty.");
}
else if (!textiles.Any())
{
    Console.WriteLine($"Textiles are empty.");
}

foreach (var item in healingItems.OrderByDescending(n=>n.Value).ThenBy(a=>a.Key))
{
    if (item.Value >0)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

if (textiles.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ",textiles)}");
}
if (medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}
