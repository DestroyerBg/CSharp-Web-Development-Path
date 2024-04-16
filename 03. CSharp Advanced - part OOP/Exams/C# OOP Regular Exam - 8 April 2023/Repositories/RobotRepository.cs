using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }
        public IReadOnlyCollection<IRobot> Models() => robots.AsReadOnly();
        

        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public bool RemoveByName(string robotModel)
        {
            if (robots.Any(r=>r.Model == robotModel))
            {
                robots.Remove(robots.First(r => r.Model == robotModel));
                return true;
            }
            return false;
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            if (robots.Any(r=>r.InterfaceStandards.Any(i=> i == interfaceStandard)))
            {
                return robots.First(r => r.InterfaceStandards.Any(i => i == interfaceStandard));
            }
            return null;
        }
    }
}
