using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }

        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }

        }

        public IReadOnlyCollection<Product> Products
        {
            get => products.AsReadOnly();
        }

        public string BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                products.Add(product);
                Money-=product.Cost;
                return $"{Name} bought {product.Name}";
            }

            return $"{Name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            if (products.Any())
            {
                return $"{Name} - {string.Join(", ",products.Select(p=>p.Name))}";
            }

            return $"{Name} - Nothing bought";
        }
    }
}
