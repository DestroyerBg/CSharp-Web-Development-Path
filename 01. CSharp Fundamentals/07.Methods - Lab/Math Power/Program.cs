double number =double.Parse(Console.ReadLine());
double power=double.Parse(Console.ReadLine());
double result= RaiseInPower(number, power);

static double RaiseInPower(double number, double power)
{ 
    double result=(double)Math.Pow(number, power);
    return result;


}
Console.WriteLine(result);