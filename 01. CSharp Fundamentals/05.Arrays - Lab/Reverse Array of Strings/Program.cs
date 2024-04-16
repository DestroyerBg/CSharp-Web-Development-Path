string[] charCollection=Console
    .ReadLine()
    .Split(' ')
    .ToArray();
for (int i = 0; i < charCollection.Length / 2; i++)
{
    var oldElement = charCollection[i];
    charCollection[i] = charCollection[charCollection.Length - 1 - i];
    charCollection[charCollection.Length - 1 - i] = oldElement;
}
Console.WriteLine(string.Join(" ", charCollection));