using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.MilitaryElite.Models.Enums;
using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(
            string id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            Corps corps, 
            IReadOnlyCollection<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString() + $"{Environment.NewLine}Repairs:");
            foreach (var part in Repairs)
            {
                result.AppendLine($"{" ",2}{part.ToString()}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
