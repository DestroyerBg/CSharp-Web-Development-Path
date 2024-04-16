double quantityOfFoodInKilograms = double.Parse(Console.ReadLine()) * 1000;
double quantityOfHayInKilograms = double.Parse(Console.ReadLine()) * 1000;
double quantityCoverInKilograms = double.Parse(Console.ReadLine()) * 1000;
double weight = double.Parse(Console.ReadLine()) * 1000;
bool noFood=false;
for (int i = 1; i <= 30; i++)
{
    quantityOfFoodInKilograms -= 300;
    if (i % 2 == 0)
    {
        quantityOfHayInKilograms -= quantityOfFoodInKilograms * 0.05;

    }

    if (i % 3 == 0)
    {
        quantityCoverInKilograms -=    weight/3;
    }

    if (quantityOfFoodInKilograms <= 0 || quantityCoverInKilograms <= 0 || quantityOfHayInKilograms <= 0)
    {
        noFood = true;
        break;
    }
}

if (noFood==true)
{
    Console.WriteLine("Merry must go to the pet store!");
}
else
{
    Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityOfFoodInKilograms/1000:f2}, Hay: {quantityOfHayInKilograms/1000:f2}, Cover: {quantityCoverInKilograms/1000:f2}.");
}
