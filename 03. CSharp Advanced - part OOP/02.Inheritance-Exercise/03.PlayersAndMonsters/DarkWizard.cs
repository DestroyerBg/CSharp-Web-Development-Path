using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public abstract class DarkWizard : Wizard
    {
        public DarkWizard(string username, int level) : base(username, level)
        {
        }
    }
}
