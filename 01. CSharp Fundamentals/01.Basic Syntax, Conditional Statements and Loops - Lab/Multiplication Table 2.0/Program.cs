int n = int.Parse(Console.ReadLine());
int multiplayer=int.Parse(Console.ReadLine());
for (int i = multiplayer; i <= 10; i++)
{
    Console.WriteLine($"{n} X {i} = {n * i}");
}
if (multiplayer > 10)
{
    Console.WriteLine($"{n} X {multiplayer} = {n * multiplayer}");
}
