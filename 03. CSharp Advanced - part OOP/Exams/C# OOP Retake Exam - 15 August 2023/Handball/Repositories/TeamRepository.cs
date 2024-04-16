using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams = new List<ITeam>();

        public IReadOnlyCollection<ITeam> Models
        {
            get => teams.AsReadOnly();
        }
        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool RemoveModel(string name)
        {
            if (teams.Any(t=>t.Name == name))
            {
                teams.Remove(teams.Find(t => t.Name == name));
                return true;
            }
            return false;
        }

        public bool ExistsModel(string name)
        {
            if (teams.Any(t => t.Name == name))
            {
                return true;
            }
            return false;
        }

        public ITeam GetModel(string name)
        {
            if (teams.Any(t => t.Name == name))
            {
                return teams.FirstOrDefault(t=>t.Name == name);
            }
            return null;
        }
    }
}
