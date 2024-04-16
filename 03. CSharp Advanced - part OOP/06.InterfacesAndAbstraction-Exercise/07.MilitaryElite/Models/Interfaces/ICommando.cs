using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07.MilitaryElite.Models.Enums;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface ICommando : ISoldier
    {
        public IReadOnlyCollection<Mission> Missions { get;}
    }
}
