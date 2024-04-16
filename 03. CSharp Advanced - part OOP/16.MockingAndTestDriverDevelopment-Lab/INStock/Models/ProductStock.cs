using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> _products;
        public ProductStock()
        {
            _products = new List<IProduct>();
        }
        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                yield return _products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get => _products.Count;
        }

        public IProduct this[int index]
        {
            get => _products[index];
        }

        public bool Contains(IProduct product)
        {
            if (_products.Contains(product))
            {
                return true;
            }
            return false;
        }

        public void Add(IProduct product)
        {
            if (!_products.Any(p=>p.Label == product.Label))
            {
                _products.Add(product);
            }

            throw new ArgumentException("Ima veche produkt s tozi label.");
        }

        public bool Remove(IProduct product)
        {
            if (_products.Any(p=>p.Quantity 
                    == product.Quantity && p.Label 
                    == product.Label && p.Price 
                    == product.Price))
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index>_products.Count-1)
            {
                throw new IndexOutOfRangeException("Izvun granicite na masiva!");
            }
            return _products[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (_products.Any(p=>p.Label == label))
            {
                return _products.Find(p => p.Label == label);
            }

            throw new ArgumentException("Nqma takuv produkt");
        }

        public IProduct FindMostExpensiveProduct()
        {
            return _products.MaxBy(p => p.Price);
        }

        public IEnumerable<IProduct> FindAllInrangeAll(decimal lo, decimal hi)
        {
            var range = new List<IProduct>();
            foreach (IProduct product in _products)
            {
                if (product.Price >= lo && product.Price <= hi)
                {
                    range.Add(product);
                }
            }
            IEnumerable<IProduct> products = range.OrderByDescending(p => p.Price);
            return products;
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            IEnumerable<IProduct> products = _products.FindAll(p => p.Price == price);
            return products;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            IEnumerable<IProduct> products = _products.FindAll(p => p.Quantity == quantity);
            return products;
        }
    }
}
