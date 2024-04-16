using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Vehicles.IO;
using _01.Vehicles.IO.Interfaces;
using _03.Raiding.Models;
using _03.Raiding.Models.Interfaces;

namespace _01.Vehicles.Core.Interfaces
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
        }

        public void Run()
        {
            var heroTypes = new List<string>()
            {
                {"Druid"},
                {"Paladin"},
                {"Rogue"},
                {"Warrior"}
            };
            int numberOfHeroes = int.Parse(reader.ReadLine());
            var raidGroup = new List<IBaseHero>();
            while (raidGroup.Count != numberOfHeroes)
            {
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();
                if (!heroTypes.Contains(heroType))
                {
                    writer.WriteLine($"Invalid hero!");
                    continue;
                }
                IBaseHero hero = CreateHero(heroName, heroType);
                raidGroup.Add(hero);

            }

            int bossPower = int.Parse(reader.ReadLine());
            int totalRaidPower = raidGroup.Sum(h => h.Power);
            foreach (var hero in raidGroup)
            {
                writer.WriteLine(hero.CastAbility());
            }
            if (totalRaidPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine($"Defeat...");
            }
        }

        private IBaseHero CreateHero(string name, string heroType)
        {
            IBaseHero hero = null;
            if (heroType == "Druid")
            {
                hero = new Druid(name);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
