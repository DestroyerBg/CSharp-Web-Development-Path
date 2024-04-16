List<int> bombNumbers = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
List<int> SpecialNumAndPower = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
int SpecialNum = SpecialNumAndPower[0];
int SpecialPower = SpecialNumAndPower[1];
while (bombNumbers.Contains(SpecialNum))
{
        int index = bombNumbers.IndexOf(SpecialNum);
        int leftToBomb = Math.Max(0, index - SpecialPower);
        int bombToRight=Math.Min(bombNumbers.Count - 1, index + SpecialPower);
        int range = bombToRight - leftToBomb + 1;
        bombNumbers.RemoveRange(leftToBomb,range);

}
int sum = 0;
for (int i = 0; i < bombNumbers.Count; i++)
{
    sum += bombNumbers[i];
}

Console.WriteLine($"{sum}");

