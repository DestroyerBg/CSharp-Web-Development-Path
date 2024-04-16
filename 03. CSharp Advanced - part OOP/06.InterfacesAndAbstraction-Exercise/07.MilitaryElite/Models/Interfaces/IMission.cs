using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.MilitaryElite.Models.Enums;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        public string Name { get;}
        public State State { get; }
        public void CompleteMission();
    }
}
