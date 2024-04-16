using System.Text.RegularExpressions;

namespace Problem_2___Ad_Astra
{
    class Food
    {
        public Food(string foodName, string date, int calories)
        {
            FoodName = foodName;
            Date = date;
            Calories = calories;
        }

        public string FoodName { get; set; }
        public string Date { get; set; }
        public int Calories { get; set; }
        
        public override string ToString()
        {
            return $"Item: {FoodName}, Best before: {Date}, Nutrition: {Calories}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string foodPattern = @"(\#|\|)(?<foodName>[A-Za-z ]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            List<Food> foodList = new List<Food>();
            MatchCollection matchFoods = Regex.Matches(input, foodPattern);
            int total = 0;
            foreach (Match match in matchFoods)
            {
                string foodName = match.Groups["foodName"].Value;
                string foodDate = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                Food food = new Food(foodName, foodDate, calories);
                foodList.Add(food);
                total += calories;
            }

            Console.WriteLine($"You have food to last you for: {total/2000} days!");
            foreach (var food in foodList)
            {
                Console.WriteLine($"{food.ToString()}");
            }
        }
    }
}