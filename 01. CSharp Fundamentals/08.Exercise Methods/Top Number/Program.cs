int n = int.Parse(Console.ReadLine());
TopNumbersInRangeToN(n);

static void TopNumbersInRangeToN(int n)
{
    for (int i = 1; i <= n; i++)
    {
        bool isSumOfDigitsDivisibleByEight = SumDigits(i);
        bool oddDigitsFound = oddDigitsFinder(i);
        if (oddDigitsFound==true && isSumOfDigitsDivisibleByEight==true)
        {
            Console.WriteLine(i);

        }
    }
}

static bool SumDigits(int i)
{
    int sum = 0;
    while (i > 0)
    {
        int currNum = i % 10;
        sum += currNum;
        i /= 10;
    }
    if (sum % 8 == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}
static bool oddDigitsFinder(int i)
{
    while (i > 0)
    {
        int currNum = i % 10;
        i /= 10;
        if (currNum % 2 == 1)
        {

            return true;

        }
        else
        {
            continue;
        }
       

    }
    return false;


}