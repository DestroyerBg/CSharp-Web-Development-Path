string input = string.Empty;
bool isSpecial = false;
double totalPrice = 0;
double taxes = 0;
while (true)
{
    input=Console.ReadLine();
    if (input == "special")
    {
        isSpecial = true;
        break;
    }
    else if (input == "regular")
    {
        break;
    }

    double currPartPrice = double.Parse(input);
    if (currPartPrice < 0)
    {
        Console.WriteLine($"Invalid price!");
        continue;
    }

    totalPrice += currPartPrice;
    taxes += currPartPrice * 0.20;


}

if (totalPrice==0)
{
    Console.WriteLine($"Invalid order!");
}
else
{
    double priceWithTaxes = totalPrice + taxes;
    if (isSpecial == true)
    {
        priceWithTaxes -= priceWithTaxes * 0.10;
        Console.WriteLine("Congratulations you've just bought a new computer!");
        Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
        Console.WriteLine($"Taxes: {taxes:f2}$");
        Console.WriteLine("-----------");
        Console.WriteLine($"Total price: {priceWithTaxes:f2}$");
    }
    else if (isSpecial==false)
    {
        Console.WriteLine("Congratulations you've just bought a new computer!");
        Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
        Console.WriteLine($"Taxes: {taxes:f2}$");
        Console.WriteLine("-----------");
        Console.WriteLine($"Total price: {priceWithTaxes:f2}$");
    }
}