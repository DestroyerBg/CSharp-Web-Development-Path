int size = int.Parse(Console.ReadLine());
string[] instructions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
char[,] matrix = ReadMatrixFromConsole(size, size);
int startPositionRow = -1;
int startPositionCol = -1;
int amountOfCoal = 0;
for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        char currElement = matrix[row, col];
        if (currElement == 's')
        {
            startPositionRow = row;
            startPositionCol = col;
        }
        else if (currElement == 'c')
        {
            amountOfCoal++;
        }
    }
}

int foundCoal = 0;
int currPositionRow = startPositionRow;
int currPositionCol = startPositionCol;
for (int i = 0; i < instructions.Length; i++)
{
    string currInstruction = instructions[i];
    if (currInstruction == "up")
    {
        if (currPositionRow - 1 >=0 && currPositionRow-1<size)
        {
            currPositionRow--;
            if (matrix[currPositionRow,currPositionCol] == 'c')
            {
                foundCoal++;
                matrix[currPositionRow, currPositionCol] = '*';
                if (foundCoal == amountOfCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currPositionRow}, {currPositionCol})");
                    return;
                }
            }
            else if (matrix[currPositionRow, currPositionCol] == 'e')
            {
                Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                return;
            }
        }
    }
    else if (currInstruction == "right")
    {
        if (currPositionCol+1 >=0 && currPositionCol+1 <size)
        {
            currPositionCol++;
            if (matrix[currPositionRow, currPositionCol] == 'c')
            {
                matrix[currPositionRow, currPositionCol] = '*';
                foundCoal++;
                if (foundCoal == amountOfCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currPositionRow}, {currPositionCol})");
                    return;
                }
            }
            else if (matrix[currPositionRow, currPositionCol] == 'e')
            {
                Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                return;
            }
        }
    }
    else if (currInstruction == "left")
    {
        if (currPositionCol - 1 >= 0 && currPositionCol - 1 < size)
        {
            currPositionCol--;
            if (matrix[currPositionRow, currPositionCol] == 'c')
            {
                foundCoal++;
                matrix[currPositionRow, currPositionCol] = '*';
                if (foundCoal == amountOfCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currPositionRow}, {currPositionCol})");
                    return;
                }
            }
            else if (matrix[currPositionRow, currPositionCol] == 'e')
            {
                Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                return;
            }
        }
    }
    else if (currInstruction == "down")
    {
        if (currPositionRow + 1 >= 0 && currPositionRow + 1 < size)
        {
            currPositionRow++;
            if (matrix[currPositionRow, currPositionCol] == 'c')
            {
                foundCoal++;
                matrix[currPositionRow, currPositionCol] = '*';
                if (foundCoal == amountOfCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currPositionRow}, {currPositionCol})");
                    return;
                }
            }
            else if (matrix[currPositionRow, currPositionCol] == 'e')
            {
                Console.WriteLine($"Game over! ({currPositionRow}, {currPositionCol})");
                return;
            }
        }
    }
}

Console.WriteLine($"{Math.Abs(amountOfCoal-foundCoal)} coals left. ({currPositionRow}, {currPositionCol})");
static char[,] ReadMatrixFromConsole(int rows, int cols)
{
    char[,] matrix = new char[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        string[] newElements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = char.Parse(newElements[col]);
        }
    }

    return matrix;
}

