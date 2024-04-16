int n=int.Parse(Console.ReadLine());

int sum = 0;
for (int i = 1; i <= n; i++)
{
	int numberToDivide = i;
	while (numberToDivide>0)
	{
		int currNumber = numberToDivide % 10;
		numberToDivide = numberToDivide / 10;
		sum += currNumber;
	}
	if (sum == 5 || sum == 7 || sum == 11)
	{
		Console.WriteLine($"{i} -> True");

	}
	else
	{
        Console.WriteLine($"{i} -> False");

    }
	sum = 0;
}
