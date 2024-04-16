using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class AddCollection : IAddToCollection
    {
        private List<string> collection;

        public AddCollection()
        {
            collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count-1;
        }
    }
}
