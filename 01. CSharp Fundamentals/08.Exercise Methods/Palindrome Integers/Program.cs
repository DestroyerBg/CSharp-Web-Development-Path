string input;
while ((input = Console.ReadLine()) != "END")
{
    int number = int.Parse(input);
    bool valid = IsPalindrome(number);
    if (valid == true)
    {
        Console.WriteLine("true");

    }
    else
    {
        Console.WriteLine("false");
    }
    valid = false;
}
static bool IsPalindrome(int number)
{
    string numToString = number.ToString();
    char[] chars = numToString.ToCharArray();
    string palindrome = string.Empty;
    for (int i = chars.Length - 1; i > -1; i--)
    {
        palindrome += chars[i];
    }
    if (palindrome == numToString)
    {
        return true;
    }
    else
    {
        return false;

    }



}