using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name,int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }
        public string Name { get;set; }
        public int StorageCapacity { get; private set; }
        public List<Shoe> Shoes { get; private set; }
        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count < StorageCapacity)
            {
                Shoes.Add(shoe);
                return($"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.");
            }

            return $"No more space in the storage room.";
        }

        public int RemoveShoes(string material)
        {
            int count = 0;
            foreach (var shoe in Shoes)
            {
                if (shoe.Material == material)
                {
                    count++;
                }
            }

            Shoes.RemoveAll(m => m.Material == material);
            return count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            var foundShoes = new List<Shoe>();
            foreach (var shoe in Shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    foundShoes.Add(shoe);
                }
            }
            return foundShoes;
        }

        public Shoe GetShoeBySize(double size)
        {
            Shoe findShoe = Shoes.First(s => s.Size == size);
            return findShoe;
        }

        public string StockList(double size, string type)
        {
            var foundShoes = new List<Shoe>();
            foreach (var shoe in Shoes)
            {
                if (shoe.Size == size && shoe.Type == type) 
                {
                    foundShoes.Add(shoe);
                }
            }

            if (foundShoes.Any())
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoe in foundShoes)
                {
                    result.AppendLine(shoe.ToString());
                }
                return result.ToString().TrimEnd();
            }

            return $"No matches found!";
        }
    }
}
