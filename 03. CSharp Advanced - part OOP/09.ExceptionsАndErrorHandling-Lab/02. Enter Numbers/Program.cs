using System.Globalization;

var nums = new List<int>();
while (nums.Count != 10)
{
    string input = Console.ReadLine();
    try
    {
        bool isNumber = int.TryParse(input, out int result);
        if (isNumber)
        {
            if (nums.Count == 0)
            {
                if (result <= 1 || result >= 100)
                {
                    throw new ArgumentException($"Your number is not in range 1 - 100!");
                }
            }
            else if (nums.Count > 0)
            {
                int currNum = nums.Last();
                if (result <= currNum || result >= 100)
                {
                    throw new ArgumentException($"Your number is not in range {currNum} - 100!");
                }

            }
            nums.Add(result);
        }
        else
        {
            throw new ArgumentException($"Invalid Number!");
        }
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine(string.Join(", ", nums));