string word = Console.ReadLine();
PrintMiddleCharacter(word);
    static void PrintMiddleCharacter(string word)
{
    int middleChar = word[((word.Length - 1) / 2)];
    int middleCharPlusOne= word[((word.Length - 1) / 2)+1];
    if (word.Length%2==0)
    {
        Console.WriteLine($"{(char)(middleChar)}{(char)(middleCharPlusOne)}");
    }
    else
    {
        Console.WriteLine($"{(char)middleChar}");
    }

}