int number =int.Parse(Console.ReadLine());
int evenSum= GetSumOfEvenDigits(number);
int oddSum= GetSumOfOddDigits(number);
GetMultipleOfEvenAndOddDigits(evenSum, oddSum);

static int GetSumOfEvenDigits(int number)
{
    int evenSum = 0;
    number=Math.Abs(number);
    while (number > 0)
    {
        int currNum = number % 10;
        number /= 10;
        if (currNum%2==0)
        {
            evenSum += Math.Abs(currNum);
        }
        
    
    
    }
    
    return evenSum;



}
static int GetSumOfOddDigits(int number)
{
    int oddSum = 0;
    number=Math.Abs(number);
    while (number > 0)
    {
        int currNum = number % 10;
        number /= 10;
        if (currNum % 2 == 1)
        {
            oddSum += Math.Abs(currNum);
        }



    }

    return oddSum;
}
static void GetMultipleOfEvenAndOddDigits(int evenSum, int oddSum)
{
    Console.WriteLine(evenSum*oddSum);

}