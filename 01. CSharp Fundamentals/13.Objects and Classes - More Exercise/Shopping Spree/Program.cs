using System.Runtime.InteropServices;

namespace Shopping_Spree
{
    class Product
    {
        public Product(string productName, int productPrice)
        {
            Name = productName;
            Price= productPrice;
        }

        public string Name { get; set; }
        public int Price { get; set; }
    }

    class Person
    {
        public Person(string name, int money, List<Product> bagOfProducts)
        {
            Name = name;
            BagOfProducts = bagOfProducts;
            Money= money;
        }

        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> BagOfProducts { get; set; }
        public override string ToString()
        {
            if (BagOfProducts.Count>0)
            {
                string products = string.Join(", ", BagOfProducts.Select(n => n.Name)).ToString();
                return $"{Name} - {products}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] personInformation = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var productPrices = new Dictionary<string, int>();
            List<Person> allPeople = new List<Person>();
            for (int i = 0; i < personInformation.Length; i++)
            {
                string[] currPerson = personInformation[i].Split("=");
                string name= currPerson[0];
                int money = int.Parse(currPerson[1]);
                Person person = new Person(name, money, new List<Product>());
                allPeople.Add(person);

            }
            string[] productInformation = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < productInformation.Length; i++)
            {
                string[] currProduct = productInformation[i].Split("=");
                string name= currProduct[0];
                int price = int.Parse(currProduct[1]);
                productPrices.Add(name, price);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] arguments= input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name= arguments[0];
                string productName= arguments[1];
                if (allPeople.FirstOrDefault(x=>x.Name==name).Money>= productPrices[productName])
                {
                    Product product= new Product(productName, productPrices[productName]); 
                    allPeople.FirstOrDefault(x => x.Name==name).BagOfProducts.Add(product);
                    allPeople.FirstOrDefault(x => x.Name == name).Money-= productPrices[productName];
                    Console.WriteLine($"{name} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{name} can't afford {productName}");
                }
            }

            foreach (var person in allPeople)
            {
                Console.WriteLine($"{person.ToString()}");
            }

        }
    }
}