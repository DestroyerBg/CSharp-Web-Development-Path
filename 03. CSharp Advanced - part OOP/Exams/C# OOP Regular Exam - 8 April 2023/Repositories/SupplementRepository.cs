using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
             return supplements.AsReadOnly();
        } 
        

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            if (supplements.Any(s=>s.GetType().Name == typeName))
            {
                supplements.Remove(supplements.First(s => s.GetType().Name == typeName));
                return true;
            }
            return false;
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            if (supplements.Any(s => s.InterfaceStandard == interfaceStandard))
            {
                return supplements.First(s => s.InterfaceStandard == interfaceStandard);
            }
            return null;
        }
    }
}
