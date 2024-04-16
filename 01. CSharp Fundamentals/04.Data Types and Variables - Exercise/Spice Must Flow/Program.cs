int startingYield=int.Parse(Console.ReadLine());
int days = 0;
int spice = 0;
while (startingYield >= 100)
{
    
    spice += startingYield;
    startingYield -= 10;
    days++;
    spice-= 26;
    

}
spice-= 26;
if (spice<0)
{ 
spice = 0;

}

Console.WriteLine(days);
Console.WriteLine(spice);