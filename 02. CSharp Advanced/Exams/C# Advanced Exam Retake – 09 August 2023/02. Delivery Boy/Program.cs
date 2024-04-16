int[] sizeOfTheMatrix = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];  
char[,] matrix = ReadMatrixFromConsole(rows, cols);
int boyStartingRow = -1;
int boyStartingCol = -1;
int boyRow = -1;
int boyCol = -1;
for (int row = 0; row < rows; row++)
{ 
    for (int col = 0; col < cols; col++)
    {
        if (matrix[row,col] == 'B')
        {
            boyStartingRow = row;
            boyStartingCol = col;
            boyRow = row;
            boyCol = col;
        }
    }
}

while (true)
{
    string command = Console.ReadLine();
    if (command == "up")
    {
        if (boyRow -1 >=0)
        {
            if (matrix[boyRow-1,boyCol] == '*')
            {
                continue;
            }

            boyRow--;
        }
        else
        {
            Console.WriteLine($"The delivery is late. Order is canceled.");
            matrix[boyStartingRow, boyStartingCol] = ' ';
            PrintMatrix(matrix);
            return;
        }

    }
    else if (command == "down")
    {
        if (boyRow + 1 <= rows-1)
        {
            if (matrix[boyRow + 1, boyCol] == '*')
            {
                continue;
            }

            boyRow++;
        }
        else
        {
            Console.WriteLine($"The delivery is late. Order is canceled.");
            matrix[boyStartingRow, boyStartingCol] = ' ';
            PrintMatrix(matrix);
            return;
        }
    }
    else if (command == "left")
    {
        if (boyCol - 1 >= 0)
        {
            if (matrix[boyRow, boyCol-1] == '*')
            {
                continue;
            }

            boyCol--;
        }
        else
        {
            Console.WriteLine($"The delivery is late. Order is canceled.");
            matrix[boyStartingRow, boyStartingCol] = ' ';
            PrintMatrix(matrix);
            return;
        }
    }
    else if (command == "right")
    {
        if (boyCol + 1 <= cols-1)
        {
            if (matrix[boyRow, boyCol + 1] == '*')
            {
                continue;
            }

            boyCol++;
        }
        else
        {
            Console.WriteLine($"The delivery is late. Order is canceled.");
            matrix[boyStartingRow, boyStartingCol] = ' ';
            PrintMatrix(matrix);
            return;
        }

        
    }
    if (matrix[boyRow, boyCol] == '-')
    {
        matrix[boyRow, boyCol] = '.';
    }
    else if (matrix[boyRow, boyCol] == '.')
    {
        matrix[boyRow, boyCol] = '.';
    }
    else if (matrix[boyRow, boyCol] == 'P')
    {
        matrix[boyRow, boyCol] = 'R';
        Console.WriteLine($"Pizza is collected. 10 minutes for delivery.");
    }
    else if (matrix[boyRow, boyCol] == 'A')
    {
        matrix[boyRow, boyCol] = 'P';
        Console.WriteLine($"Pizza is delivered on time! Next order...");
        PrintMatrix(matrix);
        return;
    }
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