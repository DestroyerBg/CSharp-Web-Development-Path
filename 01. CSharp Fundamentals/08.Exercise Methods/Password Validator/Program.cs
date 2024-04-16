string password = Console.ReadLine().ToLower();
bool validationOne= CharactersLenghtValidator(password);
bool validationTwo= LettersAndDigitsVerify(password);
bool validationThree= DigitsCount(password);
if (validationOne==true && validationTwo==true && validationThree==true)
{
    Console.WriteLine("Password is valid");
}


static bool CharactersLenghtValidator(string password)
{
    if (password.Length >= 6 && password.Length <= 10)
    {
        return true;
    }
    else
    {
        Console.WriteLine("Password must be between 6 and 10 characters");
        return false;

    }

}
static bool LettersAndDigitsVerify(string password)
{
    bool isDigitsAndNumbersOnly = false;
    for (int i = 0; i < password.Length; i++)
    {
        
        int currChar = (int)password[i];
        if ((currChar >= 65 && currChar <= 90) || (currChar >= 97 && currChar <= 122) || (currChar >= 48 && currChar <= 57))
        {
            isDigitsAndNumbersOnly = true;
            continue;
        }
        else
        {
            isDigitsAndNumbersOnly = false;
            Console.WriteLine($"Password must consist only of letters and digits");
            break;

        }
        

    }
    if (isDigitsAndNumbersOnly == false)
    {
        return false;
    }
    else
    {
        return true;
    }
}
static bool DigitsCount(string password)
{
    int digitsCount = 0;
    bool isHasDigitsCountMinTwo = false;
    for (int i = 0; i < password.Length; i++)
    {
        int currChar = (int)password[i];
        if (currChar >= 48 && currChar <= 57)
        {
            digitsCount++;

        }
    }
    if (digitsCount >= 2)
    {
        isHasDigitsCountMinTwo = true;
    }
    else
    {
        Console.WriteLine("Password must have at least 2 digits");
        isHasDigitsCountMinTwo = false;
    }
    if (isHasDigitsCountMinTwo == false)
    {
    return false;
    }
    else
    {
        return true;
    }

}

