char charOne = char.Parse(Console.ReadLine());
char charTwo = char.Parse(Console.ReadLine());
PrintCharacterBetweenThem(charOne, charTwo);

static void PrintCharacterBetweenThem(char charOne, char charTwo)
{ 
    int asciiStartValue=(int)charOne;
    int asciiEndValue=(int)charTwo;
    if (asciiStartValue<asciiEndValue)
    {
        for (int i = asciiStartValue + 1; i < asciiEndValue; i++)
        {
            char currChar = (char)i;
            Console.Write($"{currChar} ");
        }
    }
    else if (asciiEndValue< asciiStartValue)
    {
        for (int i = asciiEndValue + 1; i < asciiStartValue; i++)
        {
            char currChar = (char)i;
            Console.Write($"{currChar} ");
        }
    }
    else
    {
        for (int i = asciiEndValue + 1; i <= asciiStartValue; i++)
        {
            char currChar = (char)i;
            Console.Write($"{currChar} ");
        }
    }
    


}