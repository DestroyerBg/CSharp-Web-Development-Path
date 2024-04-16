using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : IAddToCollection, IRemoveFromCollection
    {
        private List<string> collection;

        public MyList()
        {
            collection = new List<string>();
        }
        public int Used => collection.Count;
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string itemToReturn = string.Empty;
            if (collection.Any())
            {
                itemToReturn = collection[0];
                collection.RemoveAt(0);
            }
            return itemToReturn;
        }
    }
}
