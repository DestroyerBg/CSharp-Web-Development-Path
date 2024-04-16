int[] sizeOfTheMatrix = Console.ReadLine()
    .Split(",")
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];
char[,] matrix = ReadMatrixFromConsole(rows, cols);
int mouseStartRow = -1;
int mouseStartCol = -1;
int cheeseCount = 0;
int collectedCheese = 0;
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (matrix[row,col] == 'M')
        {
            mouseStartRow = row; 
            mouseStartCol = col;
        }
        else if (matrix[row, col] == 'C')
        {
            cheeseCount++;
        }
    }
}
int mouseRow = mouseStartRow;
int mouseCol = mouseStartCol;
string input = string.Empty;
while ((input = Console.ReadLine()) != "danger")
{
    if (input == "up")
    {
        if (mouseRow-1 < 0)
        {
            Console.WriteLine($"No more cheese for tonight!");
            PrintMatrix(matrix);
            matrix[mouseRow, mouseCol] = 'M';
            return;
        }

        if (matrix[mouseRow-1,mouseCol] == '@')
        {
            continue;
        }
        mouseRow--;
        matrix[mouseStartRow, mouseStartCol] = '*';
    }
    else if (input == "down")
    {
        if (mouseRow+1 > rows-1)
        {
            matrix[mouseRow, mouseCol] = 'M';
            Console.WriteLine($"No more cheese for tonight!");
            PrintMatrix(matrix);
            return;
        }
        if (matrix[mouseRow + 1, mouseCol] == '@')
        {
            continue;
        }

        mouseRow++;
        matrix[mouseStartRow, mouseStartCol] = '*';
    }
    else if (input == "left")
    {
        if (mouseCol-1 < 0)
        {
            matrix[mouseRow, mouseCol] = 'M';
            Console.WriteLine($"No more cheese for tonight!");
            PrintMatrix(matrix);
            return;
        }
        if (matrix[mouseRow, mouseCol-1] == '@')
        {
            continue;
        }
        mouseCol--;
        matrix[mouseStartRow, mouseStartCol] = '*';
    }
    else if (input == "right")
    {
        if (mouseCol + 1 > cols-1)
        {
            matrix[mouseRow, mouseCol] = 'M';
            Console.WriteLine($"No more cheese for tonight!");
            PrintMatrix(matrix);
            return;
        }
        if (matrix[mouseRow, mouseCol + 1] == '@')
        {
            continue;
        }
        mouseCol++;
        matrix[mouseStartRow, mouseStartCol] = '*';
    }
    if (matrix[mouseRow, mouseCol] == 'C')
    {
        collectedCheese++;
        matrix[mouseRow, mouseCol] = '*';
        if (collectedCheese == cheeseCount)
        {
            matrix[mouseRow, mouseCol] = 'M';
            Console.WriteLine($"Happy mouse! All the cheese is eaten, good night!");
            PrintMatrix(matrix);
            return;
        }
    }
    else if (matrix[mouseRow, mouseCol] == 'M')
    {
        continue;
    }
    else if (matrix[mouseRow, mouseCol] == '@')
    {
        continue;
    }
    else if (matrix[mouseRow, mouseCol] == 'T')
    {
        matrix[mouseRow, mouseCol] = 'M';
        Console.WriteLine($"Mouse is trapped!");
        PrintMatrix(matrix);
        return;
    }
    else if (matrix[mouseRow,mouseCol] == '*')
    {
        continue;
    }
}

if (input == "danger")
{
    matrix[mouseRow, mouseCol] = 'M';
    Console.WriteLine($"Mouse will come back later!");
    PrintMatrix(matrix);
    return;
}

void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write($"{matrix[row, col]}");
        }

        Console.WriteLine();
    }
}
static char[,] ReadMatrixFromConsole(int rows, int cols)
{
    char[,] matrix = new char[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        string newElements = Console.ReadLine();
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = newElements[col];
        }
    }

    return matrix;
}