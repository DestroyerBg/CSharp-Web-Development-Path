using System.Diagnostics;

int countOfOrders=int.Parse(Console.ReadLine());
double totalForThatOrder = 0;
double total = 0;

for (int i = 1; i <= countOfOrders; i++)
{ 
    double pricePerCapsule=double.Parse(Console.ReadLine());
    int days=int.Parse(Console.ReadLine());
    int capsulesCount=int.Parse(Console.ReadLine());
    totalForThatOrder= pricePerCapsule*days*capsulesCount;
    Console.WriteLine($"The price for the coffee is: ${totalForThatOrder:f2}");
    total += totalForThatOrder;
    totalForThatOrder= 0;
}
Console.WriteLine($"Total: ${total:f2}");