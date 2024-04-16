using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection: IRemoveFromCollection, IAddToCollection
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Insert(0,item);
            return 0;
        }
        public string Remove()
        {
            string itemToReturn = string.Empty;
            if (collection.Any())
            {
                itemToReturn = collection[collection.Count-1];
                collection.RemoveAt(collection.Count-1);
            }
            return itemToReturn;
        }

    }
}
