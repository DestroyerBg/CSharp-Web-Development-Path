using System.Text.RegularExpressions;

namespace Furniture
{
    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity= quantity;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-z]+)<<(?<price>\d+|\d+\.\d+)!(?<quantity>\d+)";
            List<Furniture> furnitures = new List<Furniture>();
            string input = string.Empty;
            decimal totalPrice = 0m;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                foreach (Match matches in Regex.Matches(input,pattern))
                {
                    string name= matches.Groups["name"].Value;
                    decimal Price = decimal.Parse(matches.Groups["price"].Value);
                    int quantity = int.Parse(matches.Groups["quantity"].Value);
                    Furniture furniture= new Furniture(name, Price, quantity);
                    furnitures.Add(furniture);
                    totalPrice += furniture.Total();
                    

                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (var furniture in furnitures)
            {
                Console.WriteLine($"{furniture.Name}");
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");

        }
    }
}