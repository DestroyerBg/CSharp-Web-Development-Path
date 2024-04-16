int[] elements = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
bool isGreater = false;
int topInteger = 0;
int lastIndex = elements[elements.Length-1];
for (int i = 0; i < elements.Length; i++)
{
    for (int k = i+1; k < elements.Length; k++)
    {
        if (elements[i] > elements[k])
        {
            isGreater = true;
        }
        else if (elements[i] < elements[k])
        { 
            isGreater = false;
            break;
        
        }

    }
    if (isGreater==true ) 
    {
        topInteger = elements[i];
        Console.Write($"{topInteger} ");
        isGreater = false;
    
    }
}
if (isGreater == true)
{
    Console.Write($"{lastIndex} ");

}
if (isGreater == false)
{
    Console.Write($"{lastIndex} ");

}

