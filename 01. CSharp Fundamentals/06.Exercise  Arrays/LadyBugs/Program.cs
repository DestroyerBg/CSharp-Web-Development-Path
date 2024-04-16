int sizeOfTheField = int.Parse(Console.ReadLine());
int[] ladyBugsStartIndexes = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] field = new int[sizeOfTheField];
for (int i = 0; i < ladyBugsStartIndexes.Length; i++)
{
    int currentIndex = ladyBugsStartIndexes[i];
    if (currentIndex >= 0 && currentIndex < field.Length)
    {
        field[currentIndex] = 1;
    }





}
string input=string.Empty;

while ((input = Console.ReadLine()) != "end")
{
    string[] command = input
        .Split();
        
    int index = int.Parse(command[0]);
    string direction = command[1];
    int flyStep = int.Parse(command[2]);
    int ladyBugEndPosition = 0;
    if (index < 0 || index > field.Length-1 || field[index] == 0 || flyStep == 0)
    {
        continue;
    }
    field[index] = 0;
    if (direction == "right")
    {
        
        ladyBugEndPosition = index + flyStep;
        if (ladyBugEndPosition > field.Length - 1)
        {
            continue;
        }
        if (field[ladyBugEndPosition]==1)
        {
            while (field[ladyBugEndPosition] == 1)
            {
                ladyBugEndPosition += flyStep;
                if (ladyBugEndPosition>field.Length-1)
                {
                    break;
                }
                
            }

        }
        if (ladyBugEndPosition <=field.Length-1)
        {
            
            field[ladyBugEndPosition] = 1;
        }
    }
    else if (direction == "left")
    {
       
        ladyBugEndPosition = index - flyStep;
        if (ladyBugEndPosition<0 || ladyBugEndPosition>field.Length-1)
        {
            continue;
        }
        if (field[ladyBugEndPosition]==1)
        {
            while (field[ladyBugEndPosition] == 1)
            {
               ladyBugEndPosition -= flyStep;
                if (ladyBugEndPosition<0)
                {
                    break;
                }
                    
            }
        }
        if (ladyBugEndPosition>=0)
        {
            field[ladyBugEndPosition] = 1;
        }
    }



}


for (int i = 0; i < field.Length; i++)
{
    Console.Write($"{field[i]} ");

}

