using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;
using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;
using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Models.Interfaces;

namespace _03.Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IBirthdable inhabitant = null;
            IReader reader = new Reader();
            IWriter writer = new Writer();
            var inhabitats = new List<IBirthdable>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string instruction = data[0];
                if (instruction == "Citizen")
                {
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string birthDate = data[4];
                    inhabitant = new Citizen(name, age, id, birthDate);
                    inhabitats.Add(inhabitant);
                }
                else if (instruction == "Pet")
                {
                    string name = data[1];
                    string birthDate = data[2];
                    inhabitant = new Pet(name, birthDate);
                    inhabitats.Add(inhabitant);
                }

                inhabitant = null;
            }

            string searchYear = reader.ReadLine();
            var found = inhabitats.FindAll(s => s.BirthDate.EndsWith(searchYear));
            found.ForEach(d=>writer.WriteLine(d.BirthDate));
        }
    }
}
