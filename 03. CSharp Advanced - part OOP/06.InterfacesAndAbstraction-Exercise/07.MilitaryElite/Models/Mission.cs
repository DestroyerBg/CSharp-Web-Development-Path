using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.MilitaryElite.Models.Enums;
using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string name, State state)
        {
            Name = name;
            State = state;
        }
        public string Name { get; private set; }
        public State State { get; private set; }
        public void CompleteMission()
        {
            State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {Name} State: {State}";
        }
    }
}
