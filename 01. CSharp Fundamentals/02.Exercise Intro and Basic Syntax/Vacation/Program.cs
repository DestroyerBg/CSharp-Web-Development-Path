int countOfPeople=int.Parse(Console.ReadLine());
string typeOfGroup=Console.ReadLine();
string day=Console.ReadLine();
double price = 0;
if (typeOfGroup == "Students")
{
	if (day == "Friday")
	{
		price = 8.45;
	}
	else if (day == "Saturday")
	{
		price = 9.80;
	}
	else if (day == "Sunday")
	{
		price = 10.46;

	}
    if (countOfPeople>=30)
    {
        price -= price * 0.15;
    }
}
else if (typeOfGroup == "Business")
{
    if (day == "Friday")
    {
        price = 10.90;
    }
    else if (day == "Saturday")
    {
        price = 15.60;
    }
    else if (day == "Sunday")
    {
        price = 16;

    }
    if (countOfPeople>=100)
    {
        countOfPeople = countOfPeople - 10;
    }

}
else if (typeOfGroup == "Regular")
{
    if (day == "Friday")
    {
        price = 15;
    }
    else if (day == "Saturday")
    {
        price = 20;
    }
    else if (day == "Sunday")
    {
        price = 22.50;

    }
    if (countOfPeople>=10 && countOfPeople<=20)
    {
        price -= price * 0.05;
    }
    

}
double totalPrice = price * countOfPeople;
Console.WriteLine($"Total price: {totalPrice:f2}");


