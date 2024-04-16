
int n1 =int.Parse(Console.ReadLine());
int n2=int.Parse(Console.ReadLine());
int n3=int.Parse(Console.ReadLine());
int n1PlusN2 = FirstTwoResult(n1, n2);
int resultMinusN3 = SubstractResultMinusThirth(n1PlusN2, n3);
Console.WriteLine(resultMinusN3);
static int FirstTwoResult(int n1, int n2)
{
    int result = n1 + n2;
    return result;
}
static int SubstractResultMinusThirth(int n1PlusN2, int n3)
{
    int result= n1PlusN2 - n3;
    return result;
}
