int n=int.Parse(Console.ReadLine());
int biggerDivision = 0;
if (n % 2 == 0)
{
    biggerDivision = 2;

}
if (n % 3 == 0)
{
    biggerDivision = 3;

}
if (n % 6 == 0)
{
    biggerDivision = 6;

}
if (n % 7 == 0)
{
    biggerDivision = 7;

}
if (n % 10 == 0)
{
    biggerDivision = 10;

}
if (biggerDivision!=0)
{
    Console.WriteLine($"The number is divisible by {biggerDivision}");
}
else 
{
    Console.WriteLine("Not divisible");
}
