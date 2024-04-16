using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

Func<double, double> addVat = numbers => numbers += numbers * 0.20;
double[] result = Console.ReadLine()
    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(addVat)
    .ToArray();
foreach (var number in result)
{
    Console.WriteLine($"{number:f2}");
}