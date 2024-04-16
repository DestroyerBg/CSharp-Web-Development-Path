using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INStock.Contracts;

namespace INStock.Models
{
    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }
        public string Label { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public int CompareTo(IProduct other)
        {
            return Quantity.CompareTo(other.Quantity);
        }
    }
}
