using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName,decimal salary, IReadOnlyCollection<Private> privates) 
            : base(id, firstName, lastName,salary)
        {
            Privates = privates;
        }
        public decimal Salary { get; private set; }
        
        public IReadOnlyCollection<Private> Privates { get; private set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Privates:");
            foreach (var member in Privates)
            {
                result.AppendLine($"{" ",2}{member.ToString()}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
