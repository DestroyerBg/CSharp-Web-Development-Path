int n=int.Parse(Console.ReadLine());
int newLiters = 0;
int sumLiters = 0;
for (int i = 1; i <= n; i++)
{ 
newLiters=int.Parse((Console.ReadLine()));
    sumLiters += newLiters;
    if (newLiters>255 || sumLiters>255)
    {
        Console.WriteLine("Insufficient capacity!");
        sumLiters-=newLiters;
        continue;
    }
    


}
Console.WriteLine(sumLiters);