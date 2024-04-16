int sizeOfTheMatrix = int.Parse(Console.ReadLine());
char[,] matrix = ReadMatrixFromConsole(sizeOfTheMatrix, sizeOfTheMatrix);
int submarineRow = -1;
int submarineCol = -1;
for (int row = 0; row < sizeOfTheMatrix; row++)
{
    for (int col = 0; col < sizeOfTheMatrix; col++)
    {
        if (matrix[row, col] == 'S')
        {
            submarineRow = row;
            submarineCol = col;
        } 
    }
}

int damageCount = 0;
int destroyedCruiserCount = 0;
while (true)
{
    string command = Console.ReadLine();
    matrix[submarineRow, submarineCol] = '-';
    if (command == "up")
    {
        if (submarineRow - 1 < 0)
        {
            continue;
        }

        submarineRow--;
    }
    else if (command == "down")
    {
        if (submarineRow + 1 > sizeOfTheMatrix-1)
        {
            continue;
        }
        submarineRow++;
    }
    else if (command == "left")
    {
        if (submarineCol - 1 < 0)
        {
            continue;
        }
        submarineCol--;
    }
    else if (command == "right")
    {
        if (submarineCol + 1 > sizeOfTheMatrix - 1)
        {
            continue;
        }
        submarineCol++;
    }

    if (matrix[submarineRow, submarineCol] == '-')
    {
        continue;
    }
    else if (matrix[submarineRow, submarineCol] == '*')
    {
        damageCount++;
        if (damageCount == 3)
        {
            matrix[submarineRow, submarineCol] = 'S';
            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
            PrintMatrix(matrix);
            return;
        }
        matrix[submarineRow, submarineCol] = '-';
    }
    else if (matrix[submarineRow, submarineCol] == 'C')
    {
        destroyedCruiserCount++;
        if (destroyedCruiserCount == 3)
        {
            matrix[submarineRow, submarineCol] = 'S';
            Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            PrintMatrix(matrix);
            return;
        }
        matrix[submarineRow, submarineCol] = '-';
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
         
