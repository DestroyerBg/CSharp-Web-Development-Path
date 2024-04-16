using System.Runtime.InteropServices;

namespace Orders
{
    class Item
    {
        public Item(string product,decimal startPrice, decimal quantity)
        {
            Product = product;
            StartPrice = startPrice;
            Quantity = quantity;
        }
        public string Product { get; set; }
        public decimal StartPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice => StartPrice * Quantity;

        public void UpdatePrice(decimal price, decimal quantity)
        {
            StartPrice=price;
            Quantity+=quantity;
        }
           

        public override string ToString()
        {
            return $"{Product} -> {TotalPrice:f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Item>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productData =input
                    .Split(" ")
                    .ToArray();
                string product = productData[0];
                decimal price = decimal.Parse(productData[1]);
                decimal quantity = decimal.Parse(productData[2]);
                if (!products.ContainsKey(product))
                {
                    Item newItem = new Item(product,price, quantity);
                    products.Add(product, newItem);


                }
                else
                {
                    products[product].UpdatePrice(price, quantity); 
                }


            }

            foreach (var pair in products)
            {
                Console.WriteLine($"{pair.Value}");
            }
        }
    }
}