using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public interface ILieutenantGeneral : ISoldier
    {
        public IReadOnlyCollection<Private> Privates { get;}
    }
}
