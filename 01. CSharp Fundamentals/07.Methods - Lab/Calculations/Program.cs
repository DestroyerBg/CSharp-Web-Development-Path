using System.Transactions;

string mathOperation = Console.ReadLine();
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());

if (mathOperation == "add")
{
    AddMethod(number1, number2);

}
else if (mathOperation == "multiply")
{
    MultiplyMethod(number1, number2);


}
else if (mathOperation == "subtract")
{
    SubstractMethod(number1, number2);

}
else if (mathOperation == "divide")
{
    DivideMethod(number1, number2);

}
static void AddMethod(int  number1, int number2)
{ 
    int result=number1+number2;
    Console.WriteLine(result);

}
static void MultiplyMethod(int number1, int number2)
{
    int result = number1 * number2;
    Console.WriteLine(result);
}
static void SubstractMethod(int number1, int number2)
{
    int result = number1 - number2;
    Console.WriteLine(result);
}
static void DivideMethod(int number1, int number2)
{
    int result = number1 / number2;
    Console.WriteLine(result);
}




