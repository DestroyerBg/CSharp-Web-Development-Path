int size = int.Parse(Console.ReadLine());
int[,] matrix = ReadMatrixFromConsole(size, size);
string[] commands = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
for (int i = 0; i < commands.Length; i++)
{
    string[] currCommand = commands[i]
        .Split(",")
        .ToArray();
    int row = int.Parse(currCommand[0]);
    int col = int.Parse(currCommand[1]);
    Explode(matrix, row, col, size);
}

int sum = 0;
int aliveCels = 0;
for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if (matrix[row, col] > 0)
        {
            aliveCels++;
            sum += matrix[row, col];
        }
    }
}
Console.WriteLine($"Alive cells: {aliveCels}");
Console.WriteLine($"Sum: {sum}");
PrintMatrix(matrix);

void PrintMatrix(int[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write($"{matrix[row, col]} ");
        }

        Console.WriteLine();
    }
}
static int[,] ReadMatrixFromConsole(int rows, int cols)
{
    int[,] matrix = new int[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        int[] newElements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = newElements[col];
        }
    }

    return matrix;
}

static int[,] Explode(int[,] matrix, int row, int col, int size)
{
    int valueOfBomb = matrix[row, col];
    if (valueOfBomb > 0)
    {
        //горе
        if (row - 1 >= 0 && row - 1 < size)
        {
            if (matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] -= valueOfBomb;
            }
        }
        //долу
        if (row + 1 >= 0 && row + 1 < size)
        {
            if (matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] -= valueOfBomb;
            }
        }
        //ляво
        if (col - 1 >= 0 && col - 1 < size)
        {
            if (matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] -= valueOfBomb;
            }
        }
        //дясно
        if (col + 1 >= 0 && col + 1 < size)
        {
            if (matrix[row, col + 1] > 0)
            {
                matrix[row, col + 1] -= valueOfBomb;
            }
        }
        //диагонал горе-дясно
        if (row - 1 >= 0 && row - 1 < size && col + 1 >= 0 && col + 1 < size)
        {
            if (matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] -= valueOfBomb;
            }
        }
        //диагонал горе-ляво
        if (row - 1 >= 0 && row - 1 < size && col - 1 >= 0 && col - 1 < size)
        {
            if (matrix[row - 1, col - 1] > 0)
            {
                matrix[row - 1, col - 1] -= valueOfBomb;
            }
        }
        //диагонал долу-ляво
        if (row + 1 >= 0 && row + 1 < size && col - 1 >= 0 && col - 1 < size)
        {
            if (matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] -= valueOfBomb;
            }
        }
        //диагонал долу-дясно
        if (row + 1 >= 0 && row + 1 < size && col + 1 >= 0 && col + 1 < size)
        {
            if (matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] -= valueOfBomb;
            }
        }
        matrix[row, col] = 0;
        return matrix;
    }

    return matrix;
}