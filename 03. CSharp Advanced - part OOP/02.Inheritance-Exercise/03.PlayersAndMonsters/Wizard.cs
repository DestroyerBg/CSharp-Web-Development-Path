using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public abstract class Wizard : Hero
    {
        public Wizard(string username, int level) : base(username, level)
        {
        }
    }
}
