int n=int.Parse(Console.ReadLine());
string model;
double radius = 0;
int height = 0;
double biggerKeg = double.MinValue;
string biggestKeg=string.Empty;
for (int i = 1; i <= n; i++)
{
     model=Console.ReadLine();
    radius=double.Parse(Console.ReadLine());
    height=int.Parse(Console.ReadLine());
    double volume= Math.PI*Math.Pow(radius, 2)*height;
    if (volume>biggerKeg)
    {
        biggerKeg = volume;
        biggestKeg = model;
    }
}
Console.WriteLine(biggestKeg);