string stringToBeRepeated =Console.ReadLine();
int timesToRepeat =int.Parse(Console.ReadLine());

RepeatString( stringToBeRepeated,timesToRepeat);
static void RepeatString(string stringToBeRepeated, int timesToRepeat)
{
	for (int i = 1; i <= timesToRepeat; i++)
	{
        Console.Write($"{stringToBeRepeated}");
    }

}
   