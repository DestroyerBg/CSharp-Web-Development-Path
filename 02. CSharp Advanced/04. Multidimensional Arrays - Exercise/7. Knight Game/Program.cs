int sizeOfTheMatrix = int.Parse(Console.ReadLine());
char[,] matrix = ReadMatrixFromConsole(sizeOfTheMatrix);
if (sizeOfTheMatrix < 3)
{
    Console.WriteLine(0);
    return;
}
int removedKnights = 0;
while (true)
{
    int maxAttackedKnights = 0;
    int maxAttackRow = 0;
    int maxAttackCol = 0;
    for (int row = 0; row < sizeOfTheMatrix; row++)
    {
        for (int col = 0; col < sizeOfTheMatrix; col++)
        {
            char currElement = matrix[row, col];
            if (currElement == 'K')
            {
                int currKnightAttacked = CalculateCountOfAttackedKnights(matrix, row, col, sizeOfTheMatrix);
                if (currKnightAttacked > maxAttackedKnights)
                {
                    maxAttackedKnights = currKnightAttacked;
                    maxAttackRow = row;
                    maxAttackCol = col;
                }
            }

        }
    }

    if (maxAttackedKnights == 0)
    {
        break;
    }
    else
    {
        matrix[maxAttackRow, maxAttackCol] = '0';
        removedKnights++;

    }

}

Console.WriteLine(removedKnights);

static char[,] ReadMatrixFromConsole(int sizeOfTheMatrix)
{
    char[,] matrix = new char[sizeOfTheMatrix, sizeOfTheMatrix];
    for (int row = 0; row < sizeOfTheMatrix; row++)
    {
        char[] newElements = Console.ReadLine()
            .ToArray();
        for (int col = 0; col < sizeOfTheMatrix; col++)
        {
            matrix[row, col] = newElements[col];
        }
    }

    return matrix;
}

static int CalculateCountOfAttackedKnights(char[,] matrix, int row, int col, int sizeOfTheMatrix)
{
    int count = 0;
    int size = sizeOfTheMatrix;
    //2 нагоре и 1 надясно -> ред - 2, колона + 1
    if (IsValid(row - 2, col + 1, sizeOfTheMatrix))
    {
        if (matrix[row - 2, col + 1] == 'K')
        {
            count++;
        }
    }
    //2 нагоре и 1 наляво -> ред - 2, кол - 1
    if (IsValid(row - 2, col - 1, sizeOfTheMatrix))
    {
        if (matrix[row - 2, col - 1] == 'K')
        {
            count++;
        }
    }
    //2 надолу и 1 наляво -> ред + 2, колона - 1
    if (IsValid(row + 2, col - 1, sizeOfTheMatrix))
    {
        if (matrix[row + 2, col - 1] == 'K')
        {
            count++;
        }
    }
    //2 надолу и 1 надясно -> ред + 2, колона + 1
    if (IsValid(row + 2, col + 1, sizeOfTheMatrix))
    {
        if (matrix[row + 2, col + 1] == 'K')
        {
            count++;
        }
    }
    //2 надясно и 1 надолу 0 -> ред + 1, колона + 2
    if (IsValid(row + 1, col + 2, sizeOfTheMatrix))
    {
        if (matrix[row + 1, col + 2] == 'K')
        {
            count++;
        }
    }
    //2 надясно и 1 нагоре->ред - 1, колона + 2
    if (IsValid(row - 1, col + 2, sizeOfTheMatrix))
    {
        if (matrix[row - 1, col + 2] == 'K')
        {
            count++;
        }
    }
    // 2 наляво и 1 нагоре -> ред - 1, колона - 2
    if (IsValid(row - 1, col - 2, sizeOfTheMatrix))
    {
        if (matrix[row - 1, col - 2] == 'K')
        {
            count++;
        }
    }
    // 2 наляво и 1 надолу -> ред - 2, колона + 2
    if (IsValid(row + 1, col - 2, sizeOfTheMatrix))
    {
        if (matrix[row + 1, col - 2] == 'K')
        {
            count++;
        }
    }
    return count;
}

static bool IsValid(int row, int col, int sizeOfTheMatrix)
{
    if (row >= 0 && row < sizeOfTheMatrix && col >= 0 && col < sizeOfTheMatrix)
    {
        return true;
    }
    return false;
}
