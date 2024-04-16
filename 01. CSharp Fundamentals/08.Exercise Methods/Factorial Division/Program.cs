double numberOne =double.Parse(Console.ReadLine());
double numberTwo= double.Parse(Console.ReadLine());
Console.WriteLine($"{CalculateFactorielDivision(numberOne, numberTwo):f2}");

static double CalculateFactorielDivision(double NumberOne, double NumberTwo)
{
    double factorielOne = 1; 
    double factorielTwo=1;
    for (int i = 1; i <= NumberOne; i++)
    { 
    factorielOne *= i;
    
    }
    for (int i = 1; i <= NumberTwo; i++)
    {
        factorielTwo *= i;
    }
    return factorielOne/factorielTwo;

}
