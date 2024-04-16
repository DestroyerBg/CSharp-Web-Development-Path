var reservations = new HashSet<string>();
var party = new HashSet<string>();
var dontCome = new HashSet<string>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "PARTY")
{
    if (input.Length == 8)
    {
        reservations.Add(input);
    }
}

while ((input = Console.ReadLine()) != "END")
{
    if (reservations.Contains(input))
    {
        party.Add(input);
    }
}

foreach (var guest in reservations)
{
    if (!party.Contains(guest))
    {
        dontCome.Add(guest);
    }
}
dontCome = dontCome.OrderByDescending(x => Char.IsDigit(x[0])).ToHashSet();
Console.WriteLine(dontCome.Count);
foreach (var entry in dontCome)
{
    Console.WriteLine(entry);
}