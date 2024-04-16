int n =int.Parse(Console.ReadLine());
PrintLine(n);
static void PrintLine(int n)
{
	for (int i = 1; i <= n; i++)
	{
		for (int k = 1; k <= i; k++)
		{
            Console.Write($"{k} ");
        }
        Console.WriteLine();
    }
	for (int i = n-1; i > 0; i--)
	{
		for (int k = 1; k <= i; k++)
		{
			Console.Write($"{k} ");
        }
        Console.WriteLine();
    }

}