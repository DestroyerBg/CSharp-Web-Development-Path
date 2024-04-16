List<string> sentence= Console
    .ReadLine()
    .Split()
    .ToList();
for (int i = 0; i < sentence.Count; i++)
{
    Random rnd= new Random();
    int randomNum = rnd.Next(0, sentence.Count);
    string temp = sentence[i];
    sentence[i] = sentence[randomNum];
    sentence[randomNum] = temp;
    
}

for (int i = 0; i < sentence.Count; i++)
{
    Console.WriteLine($"{sentence[i]}");
}