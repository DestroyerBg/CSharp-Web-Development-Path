string input = string.Empty;
double insertMoney = 0;
double totalMoney = 0;
double nutsPrice = 2.0;
double waterPrice = 0.7;
double crispsPrice = 1.5;
double sodaPrice = 0.8;
double cokePrice = 1.0;
while ((input = Console.ReadLine()) != "Start")
{
    insertMoney = double.Parse(input);
    if (insertMoney == 0.1)
    {
        totalMoney += insertMoney;
        continue;
    }
    else if (insertMoney == 0.2)
    {
        totalMoney += insertMoney;
        continue;
    }
    else if (insertMoney == 0.5)
    {
        totalMoney += insertMoney;
        continue;
    }
    else if (insertMoney == 1)
    {
        totalMoney += insertMoney;
        continue;
    }
    else if (insertMoney == 2)
    {
        totalMoney += insertMoney;
        continue;
    }
    else
    {
        Console.WriteLine($"Cannot accept {insertMoney}");
        insertMoney = 0;
        continue;

    }
}


    while ((input = Console.ReadLine()) != "End")
    {
        if (input == "Nuts")
        {
            if (nutsPrice > totalMoney)
            {
                Console.WriteLine("Sorry, not enough money");
                continue;
            }

            else
            {
                totalMoney -= nutsPrice;
                Console.WriteLine("Purchased nuts");
                continue;

            }
        }
        else if (input == "Water")
        {
            if (waterPrice > totalMoney)
            {
                Console.WriteLine("Sorry, not enough money");
                continue;
            }
            else
            {
                totalMoney -= waterPrice;
                Console.WriteLine("Purchased water");
                continue;

            }
        }
        else if (input == "Crisps")
        {
            if (crispsPrice > totalMoney)
            {
                Console.WriteLine("Sorry, not enough money");
                continue;
            }
            else
            {
                totalMoney -= crispsPrice;
                Console.WriteLine("Purchased crisps");
                continue;

            }
        }
    

    
    else if (input == "Soda")
    {
        if (sodaPrice > totalMoney)
        {
            Console.WriteLine("Sorry, not enough money");
            continue;
        }
        else
        {
            totalMoney -= sodaPrice;
            Console.WriteLine("Purchased soda");
            continue;

        }
    }
    else if (input == "Coke")
    {
        if (cokePrice > totalMoney)
        {
            Console.WriteLine("Sorry, not enough money");
            continue;
        }
        else
        {
            totalMoney -= cokePrice;
            Console.WriteLine("Purchased coke");
            continue;

        }
    }





    else
    {
        Console.WriteLine("Invalid product");
        continue;

    }


    }
Console.WriteLine($"Change: {totalMoney:f2}");



    
    
    


