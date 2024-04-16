double amountOfMoney = double.Parse(Console.ReadLine());
int countOfStudents = int.Parse(Console.ReadLine());
double priceForSingleSaber = double.Parse(Console.ReadLine());
double priceForSingleRobe = double.Parse(Console.ReadLine());
double priceForSingleBelt = double.Parse(Console.ReadLine());
int sabersQuantity = ((int)Math.Ceiling(countOfStudents * 1.1));
int robeQuantity = countOfStudents;
int beltQuantity = countOfStudents-countOfStudents / 6;
double totalPrice = priceForSingleSaber * sabersQuantity + priceForSingleRobe * countOfStudents + priceForSingleBelt * beltQuantity;


if (amountOfMoney >= totalPrice)
{
    Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
}
else
{ 
double difference=totalPrice- amountOfMoney;
    Console.WriteLine($"John will need {difference:f2}lv more. ");

}