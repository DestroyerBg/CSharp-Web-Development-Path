using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players = new List<IPlayer>();

        public IReadOnlyCollection<IPlayer> Models
        {
            get => players.AsReadOnly();
        }
        public void AddModel(IPlayer model)
        {
            players.Add(model);
        }

        public bool RemoveModel(string name)
        {
            if (players.Any(p=>p.Name == name))
            {
                players.Remove(players.Find(p => p.Name == name));
                return true;
            }
            return false;
        }

        public bool ExistsModel(string name)
        {
            return players.Any(p=>p.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            if (players.Any(p => p.Name == name))
            {
                return players.FirstOrDefault(p => p.Name == name);
            }
            return null;
        }
    }
}
