Console.WriteLine(VowelsCount());
static int VowelsCount()
{
    string text =Console.ReadLine().ToLower();
    int vowelsCount = 0;
    for (int i = 0; i < text.Length; i++)
    {
        if (text[i] =='a')
        {
            vowelsCount++;
        
        }
        else if (text[i] == 'e')
        {
            vowelsCount++;
        }
        else if (text[i] == 'i')
        {
            vowelsCount++;
        }
        else if (text[i] == 'o')
        {
            vowelsCount++;
        }
        else if (text[i] == 'u')
        {
            vowelsCount++;
        }


    }
    return vowelsCount;


}
