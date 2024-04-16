int n = int.Parse(Console.ReadLine());
int index = 1;
long factoriel = Factoriel(n, index);
Console.WriteLine(factoriel);
static long Factoriel(int n, int index)
{
    if (index == n)
    {
        return index;
    }

    int factor = index;
    index++;
    return factor * Factoriel(n, index);
}