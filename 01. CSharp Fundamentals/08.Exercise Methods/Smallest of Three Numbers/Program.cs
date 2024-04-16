Console.WriteLine(SmallestNumber());
static double SmallestNumber()
{
    int numberOne =int.Parse(Console.ReadLine());
    int numberTwo = int.Parse(Console.ReadLine());
    int numberThree = int.Parse(Console.ReadLine());
    int smallestNumber = int.MaxValue;
    if (numberOne < smallestNumber)
    { 
    smallestNumber = numberOne;
    
    }
    if (numberTwo < smallestNumber) 
    { 
    smallestNumber=numberTwo;
    
    
    }
    if (numberThree < smallestNumber) 
    { 
    smallestNumber= numberThree;
    
    }
    return smallestNumber;

}


