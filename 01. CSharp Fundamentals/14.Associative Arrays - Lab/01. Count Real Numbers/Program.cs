namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var countNumber = new SortedDictionary<double, int>();
            double[] numbers = Console
                .ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();
            foreach (var number in numbers)
            {
                if (!countNumber.ContainsKey(number))
                {
                    countNumber.Add(number, 0);
                }
                countNumber[number]++;
            }

            foreach (var count in countNumber)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}