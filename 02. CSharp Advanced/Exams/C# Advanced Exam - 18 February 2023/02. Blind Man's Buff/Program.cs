int[] sizeOfTheMatrix = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];
string[,] matrix = ReadMatrixFromConsole(rows, cols);
int playerRow = -1;
int playerCol = -1;
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        if (matrix[row,col] == "B")
        {
            playerRow = row;
            playerCol = col;
        }
    }
}
string input = string.Empty;
int movesCount = 0;
int playerTouched = 0;
while ((input = Console.ReadLine()) != "Finish")
{
    if (input == "up")
    {
        if (playerRow - 1 < 0)
        {
            continue;
        }
        else if (matrix[playerRow - 1, playerCol] == "O")
        {
            continue;
        }

        matrix[playerRow, playerCol] = "-";
        playerRow--;
    }
    else if (input == "down")
    {
        if (playerRow + 1 > rows-1)
        {
            continue;
        }
        else if (matrix[playerRow + 1, playerCol] == "O")
        {
            continue;
        }
        matrix[playerRow, playerCol] = "-";
        playerRow++;
    }
    else if (input == "left")
    {
        if (playerCol-1 < 0)
        {
            continue;
        }
        else if (matrix[playerRow, playerCol-1] == "O")
        {
            continue;
        }
        matrix[playerRow, playerCol] = "-";
        playerCol--;
    }
    else if (input == "right")
    {
        if (playerCol + 1 > cols-1)
        {
            continue;
        }
        else if (matrix[playerRow, playerCol + 1] == "O")
        {
            continue;
        }
        matrix[playerRow, playerCol] = "-";
        playerCol++;
    }

    if (matrix[playerRow, playerCol] == "-")
    {
        movesCount++;
    }
    else if (matrix[playerRow, playerCol] == "P")
    {
        playerTouched++;
        movesCount++;
        matrix[playerRow, playerCol] = "-";
        if (playerTouched == 3)
        {
            break;
        }
    }

}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {playerTouched} Moves made: {movesCount}");

static string[,] ReadMatrixFromConsole(int rows, int cols)
{
    string[,] matrix = new string[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        string[] newElements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = newElements[col];
        }
    }

    return matrix;
}