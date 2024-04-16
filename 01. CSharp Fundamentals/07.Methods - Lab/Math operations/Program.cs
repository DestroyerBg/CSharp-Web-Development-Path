int numberOne = int.Parse(Console.ReadLine());
string mathOperation = Console.ReadLine();
int numberTwo = int.Parse(Console.ReadLine());
Console.WriteLine(Calculator(numberOne, mathOperation, numberTwo));
static double Calculator(int numberOne, string mathOperation, int numberTwo)
{
    double result = 0;
    if (mathOperation == "+")
    {
        result = numberOne + numberTwo;

    }
    else if (mathOperation == "-")
    {
        result = numberOne - numberTwo;

    }
    else if (mathOperation == "*")
    {
        result = numberOne * numberTwo;

    }
    else if (mathOperation == "/")
    {
        result = numberOne / numberTwo;

    }
    return result;

}





