int[] sizeOfTheMatrix = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];
char[,] matrix = ReadMatrixFromConsole(rows, cols);
string commands = Console.ReadLine();
int playerStartRow = 0;
int playerStartCol = 0;
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        char currElement = matrix[row, col];
        if (currElement == 'P')
        {
            playerStartRow = row;
            playerStartCol = col;
        }
    }
}

for (int i = 0; i < commands.Length; i++)
{
    char currCommand = commands[i];
    int oldPlayerRow = playerStartRow;
    int oldPlayerCol = playerStartCol;
    if (currCommand == 'U')
    {
        playerStartRow--;
    }
    else if (currCommand == 'D')
    {
        playerStartRow++;
    }
    else if (currCommand == 'L')
    {
        playerStartCol--;
    }
    else if (currCommand == 'R')
    {
        playerStartCol++;
    }

    matrix[oldPlayerRow, oldPlayerCol] = '.';
    matrix = PopulateBunnies(matrix, rows, cols);
    if (playerStartRow < 0
        || playerStartRow >= rows
        || playerStartCol < 0
        || playerStartCol >= cols)
    {
        PrintMatrix(matrix);
        Console.WriteLine($"won: {oldPlayerRow} {oldPlayerCol}");
        break;
    }

    if (matrix[playerStartRow, playerStartCol] == 'B')
    {
        PrintMatrix(matrix);
        Console.WriteLine($"dead: {playerStartRow} {playerStartCol}");
        break;
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
static char[,] PopulateBunnies(char[,] matrix, int rows, int cols)
{
    char[,] tempMatrix = new char[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            tempMatrix[row, col] = matrix[row, col];
        }
    }
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            char currElement = matrix[row, col];
            if (currElement == 'B')
            {
                //горе
                if (row > 0)
                {
                    tempMatrix[row - 1, col] = 'B';
                }
                //долу
                if (row < rows - 1)
                {
                    tempMatrix[row + 1, col] = 'B';
                }
                //ляво
                if (col > 0)
                {
                    tempMatrix[row, col - 1] = 'B';
                }

                if (col < cols - 1)
                {
                    tempMatrix[row, col + 1] = 'B';
                }
            }
        }
    }

     
    return tempMatrix;
}




static char[,] ReadMatrixFromConsole(int rows, int cols)
{
    char[,] matrix = new char[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        char[] newElements = Console.ReadLine()
            .ToArray();
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = newElements[col];
        }
    }

    return matrix;
}
