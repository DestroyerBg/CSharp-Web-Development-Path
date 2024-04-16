int numberOfInputs = int.Parse(Console.ReadLine());
var numDictionary = new  Dictionary<int, int>();
for (int i = 0; i < numberOfInputs; i++)
{
    int number = int.Parse(Console.ReadLine());
    if (!numDictionary.ContainsKey(number))
    {
        numDictionary.Add(number, 0);
    }
    numDictionary[number]++;
}
int numberThatAppearsEvenTimes = numDictionary.FirstOrDefault(x=>x.Value%2==0).Key;
Console.WriteLine(numberThatAppearsEvenTimes);