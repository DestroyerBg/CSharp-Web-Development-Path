using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;
using _07.MilitaryElite.IO.Interfaces;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Models.Enums;

namespace _03.Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IReader reader = new Reader();
            var privatesDictionary = new Dictionary<int, Private>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string instruction = data[0];
                    if (instruction == "Private")
                    {
                        string id = data[1];
                        string firstName = data[2];
                        string lastName = data[3];
                        decimal salary = decimal.Parse(data[4]);
                        GetPrivate(id, firstName, lastName, salary,privatesDictionary);
                    }
                    else if (instruction == "LieutenantGeneral")
                    {
                        string id = data[1];
                        string firstName = data[2];
                        string lastName = data[3];
                        decimal salary = decimal.Parse(data[4]);
                        GetLeutenantGeneral(id, firstName, lastName, salary, data, privatesDictionary);
                    }
                    else if (instruction == "Engineer")
                    {
                        string id = data[1];
                        string firstName = data[2];
                        string lastName = data[3];
                        decimal salary = decimal.Parse(data[4]);
                        string corps = data[5];
                        GetEngineer(id, firstName, lastName, salary, corps, data);
                    }
                    else if (instruction == "Commando")
                    {
                        string id = data[1];
                        string firstName = data[2];
                        string lastName = data[3];
                        decimal salary = decimal.Parse(data[4]);
                        string corps = data[5];
                        GetCommando(id, firstName, lastName, salary, corps,data);
                    }
                    else if (instruction == "Spy")
                    {
                        string id = data[1];
                        string firstName = data[2];
                        string lastName = data[3];
                        int codeNumber = int.Parse(data[4]);
                        GetSpy(id, firstName, lastName, codeNumber);
                    }

                }
                catch (Exception e)
                {
                }

            }

        }

         void GetSpy(string id, string firstName, string lastName, int codeNumber)
         {
             Spy spy = new Spy(id, firstName, lastName, codeNumber);
             Writer writer = new Writer();
             writer.WriteLine(spy.ToString());
             FileWriter fileWriter = new FileWriter();
             fileWriter.WriteLine(spy.ToString());
         }


        void GetPrivate(string id, string firstName, string lastName, 
            decimal salary, Dictionary<int,Private> privates)
        {
            IPrivate curr = new Private(id, firstName, lastName, salary);
            IWriter writer = new Writer();
            writer.WriteLine(curr.ToString());
            IFileWriter fileWriter = new FileWriter();
            fileWriter.WriteLine(curr.ToString());
            privates.Add(int.Parse(id),(Private)curr);
        }
        void GetEngineer(string id, string firstName, string lastName, decimal salary, string corps, string[] data)
        {
            var parts = new List<Repair>();
            for (int i = 6; i < data.Length; i+=2)
            {
                string partModel = data[i];
                int hoursToRepair = int.Parse(data[i+1]);
                Repair repair = new Repair(partModel,hoursToRepair);
                parts.Add(repair);
            }

            bool isValidCorps = Enum.TryParse<Corps>(corps, out Corps corp);
            if (!isValidCorps)
            {
                throw new Exception();
            }

            var engineer = new Engineer(id, firstName, lastName, salary, corp, parts);
            IWriter writer = new Writer();
            writer.WriteLine(engineer.ToString());
            IFileWriter fileWriter = new FileWriter();
            fileWriter.WriteLine(engineer.ToString());
        }

        void GetLeutenantGeneral(string id, string firstName, string lastName, decimal salary, 
             string[] data, Dictionary<int, Private> privatesDictionary)
         {
             var privates = new List<Private>();
            for (int i = 5; i < data.Length; i++)
            {
                int searchId = int.Parse(data[i]);
                Private priv = privatesDictionary[searchId];
                privates.Add(priv);
            }
            LieutenantGeneral general = new LieutenantGeneral(id,firstName,lastName,salary,privates);
            IWriter writer = new Writer();
            writer.WriteLine(general.ToString());
            IFileWriter writer2 = new FileWriter();
            writer2.WriteLine(general.ToString());

         }
        void GetCommando(string id, string firstName, string lastName, decimal salary, string corps, string[] data)
        {
            var missions = new List<Mission>();
            for (int i = 6; i < data.Length; i+=2)
            {
                string missionName = data[i];
                string missionState = data[i+1];
                bool isValidMission = Enum.TryParse<State>(missionState, out State state);
                if (!isValidMission)
                {
                    continue;
                }

                var mission = new Mission(missionName, state);
                missions.Add(mission);
            }
            bool isValidCorps = Enum.TryParse<Corps>(corps, out Corps corp);
            if (!isValidCorps)
            {
                throw new Exception();
            }

            Commando commando = new Commando(id, firstName, lastName, salary, corp, missions);
            Writer writer = new Writer();
            writer.WriteLine(commando.ToString());
            FileWriter writer2 = new FileWriter();
            writer2.WriteLine(commando.ToString());
        }


    }
}
