int n=int.Parse(Console.ReadLine());
string[] currSymbol = new string[2];
string[] zig = new string[n];
string[] zag = new string[n];

for (int i = 0; i < n; i++)
{
    
    currSymbol=Console
        .ReadLine()
        .Split()
        .ToArray();
    if (i % 2 == 0)
    {
        zig[i] = currSymbol[0];
        zag[i] = currSymbol[1];

    }
    else 
    {
        zig[i] = currSymbol[1];
        zag[i] = currSymbol[0];
    }

    

}
for (int i = 0; i < zig.Length; i++)
{
    Console.Write($"{zig[i]} ");

}
Console.WriteLine();
for (int i = 0; i < zag.Length; i++)
{
    Console.Write($"{zag[i]} ");
}

