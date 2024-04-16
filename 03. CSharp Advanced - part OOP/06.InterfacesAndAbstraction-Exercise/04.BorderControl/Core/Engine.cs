using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;
using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;

namespace _03.Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IIdentifier inhabitant = null;
            IReader reader = new Reader();
            IWriter writer = new Writer();
            var inhabitats = new List<IIdentifier>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (data.Length  == 3) 
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    inhabitant = new Citizen(name, age, id);
                    inhabitats.Add(inhabitant);
                }
                else if (data.Length == 2)
                {
                    string model = data[0];
                    string id = data[1];
                    inhabitant = new Robot(model, id);
                    inhabitats.Add(inhabitant);
                }

                inhabitant = null;
            }

            string searchId = reader.ReadLine();
            var detained = inhabitats.FindAll(s => s.Id.EndsWith(searchId));
            detained.ForEach(d=>writer.WriteLine(d.Id));
        }
    }
}
