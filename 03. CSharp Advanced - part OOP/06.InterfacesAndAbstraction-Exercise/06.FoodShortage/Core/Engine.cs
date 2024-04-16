using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;
using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Interfaces;

namespace _03.Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IReader reader = new Reader();
            int numberOfLines = int.Parse(reader.ReadLine());
            var buyers = new HashSet<IBuyer>();
            IBuyer buyer = null;
            IWriter writer = new Writer();
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] data = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];
                    buyer = new Rebel(name,age,group);
                    buyers.Add(buyer);
                }
                else if (data.Length == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];
                    string birthdate = data[3];
                    buyer = new Citizen(name, age, group, birthdate);
                    buyers.Add(buyer);
                }

            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;
                if (buyers.Any(b=>b.Name == name))
                {
                    buyers.First(b=>b.Name==name).BuyFood();
                }
            }
            writer.WriteLine(buyers.Sum(b=>b.FoodId).ToString());
        }
    }
}
