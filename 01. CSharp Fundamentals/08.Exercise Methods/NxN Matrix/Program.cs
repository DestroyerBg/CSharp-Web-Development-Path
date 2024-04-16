int n =int.Parse(Console.ReadLine());
NxNMatrix(n);

void NxNMatrix(int n)
{
    for (int i = 1; i <= n; i++)
    { 
    for (int j = 1; j <= n; j++) 
        {
            Console.Write($"{n} ");

        }
        Console.WriteLine();

    }
}