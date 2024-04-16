using System.Numerics;

BigInteger number=BigInteger.Parse(Console.ReadLine());
BigInteger factoriel = 1;
for (int i = 1; i <= number; i++)
{
    factoriel *= i;
}

Console.WriteLine(factoriel);