using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.MilitaryElite.Models.Enums;
using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(
            string id, 
            string firstName, 
            string lastName, 
            decimal salary,
        Corps corps, 
            IReadOnlyCollection<Mission> missions) : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<Mission> Missions { get; private set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Missions:");
            foreach (var mission in Missions)
            {
                result.AppendLine(mission.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
