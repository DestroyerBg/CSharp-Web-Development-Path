string product = Console.ReadLine();
double quantity = double.Parse(Console.ReadLine());
CalculateTotal(quantity,product);
static void CalculateTotal(double quantity, string product)
{
	if (product== "coffee")
	{
		double total = 1.50 * quantity;
        Console.WriteLine($"{total:f2}");
    }
	else if (product== "water")
	{
        double total = 1.00 * quantity;
        Console.WriteLine($"{total:f2}");
    }
    else if (product == "coke")
    {
        double total = 1.40 * quantity;
        Console.WriteLine($"{total:f2}");
    }
    else if (product == "snacks")
    {
        double total = 2.00 * quantity;
        Console.WriteLine($"{total:f2}");
    }


}