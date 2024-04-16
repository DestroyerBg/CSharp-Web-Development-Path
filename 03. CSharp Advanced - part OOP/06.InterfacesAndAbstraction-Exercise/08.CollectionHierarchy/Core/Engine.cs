using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.CollectionHierarchy.IO;
using _08.CollectionHierarchy.IO.Interfaces;
using _08.CollectionHierarchy.Models;
using _08.CollectionHierarchy.Models.Interfaces;

namespace _08.CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
        }
        public void Run()
        {
            var addedIndexes = new Dictionary<string, List<int>>()
            {
                { "AddCollection", new List<int>() },
                { "AddRemoveCollection", new List<int>() },
                { "MyList", new List<int>() }
            };
            var removed = new Dictionary<string, List<string>>()
            {
                { "AddCollection", new List<string>() },
                { "AddRemoveCollection", new List<string>() },
                { "MyList", new List<string>() }
            };
            string[] data = reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            IAddToCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            for (int i = 0; i < data.Length; i++)
            {
                addedIndexes["AddCollection"].Add(addCollection.Add(data[i]));
                addedIndexes["AddRemoveCollection"].Add(addRemoveCollection.Add(data[i]));
                addedIndexes["MyList"].Add(myList.Add(data[i]));
            }

            int removeOperation = int.Parse(reader.ReadLine());
            for (int i = 0; i < removeOperation; i++)
            {
                removed["AddRemoveCollection"].Add(addRemoveCollection.Remove());
                removed["MyList"].Add(myList.Remove());
            }

            writer.WriteLine(string.Join(" ", addedIndexes["AddCollection"]));
            writer.WriteLine(string.Join(" ", addedIndexes["AddRemoveCollection"]));
            writer.WriteLine(string.Join(" ", addedIndexes["MyList"]));

            writer.WriteLine(string.Join(" ", removed["AddRemoveCollection"]));
            writer.WriteLine(string.Join(" ", removed["MyList"]));
        }

    }
}
