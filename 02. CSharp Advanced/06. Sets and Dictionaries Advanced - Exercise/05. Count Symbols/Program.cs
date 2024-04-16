var characterCounter = new SortedDictionary<char,int>();
string input = Console.ReadLine();
for (int i = 0; i < input.Length; i++)
{
    char currChar = input[i];
    if (!characterCounter.ContainsKey(currChar))
    {
        characterCounter.Add(currChar, 0);
    }
    characterCounter[currChar]++;
}

foreach (var character in characterCounter)
{
    Console.WriteLine($"{character.Key}: {character.Value} time/s");
}