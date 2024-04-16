using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private RobotRepository robots;
        private SupplementRepository supplements;

        public Controller()
        {
            robots = new RobotRepository();
            supplements = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            string[] validRobots = new string[] { "DomesticAssistant", "IndustrialAssistant" };
            if (!validRobots.Contains(typeName))
            {
                return $"Robot type {typeName} cannot be created.";
            }

            IRobot robot = null;
            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == "IndustrialAssistant")
            {
                robot = new IndustrialAssistant(model);
            }
            robots.AddNew(robot);
            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            string[] validSupplements = new string[] { "SpecializedArm", "LaserRadar" };
            if (!validSupplements.Contains(typeName))
            {
                return $"{typeName} is not compatible with our robots.";
            }
            ISupplement supplement = null;
            if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == "LaserRadar")
            {
                supplement = new LaserRadar();
            }
            supplements.AddNew(supplement);
            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            List<IRobot> selectedRobots = robots.Models()
                .Where(r=>r.Model == model)
                .ToList();
            List<IRobot> notUpgraded =
                selectedRobots.Where(r => r.InterfaceStandards.All(i => i != supplement.InterfaceStandard)).ToList();
            var robotToUpgrade = notUpgraded.FirstOrDefault();
            if (robotToUpgrade == null)
            {
                return $"All {model} are already upgraded!";
            }
            robotToUpgrade.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
            return $"{model} is upgraded with {supplementTypeName}.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> searchRobots = robots.Models()
                .Where(r => r.InterfaceStandards.Any(i=>i == intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel)
                .ToList();
            if (searchRobots.Count == 0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            int sum = searchRobots.Sum(s => s.BatteryLevel);
            if (sum < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - sum} more power needed.";
            }

            int robotCounter = 0;
            foreach (var robot in searchRobots)
            {
                robotCounter++;
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else if (robot.BatteryLevel < totalPowerNeeded)
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }
            }

            return $"{serviceName} is performed successfully with {robotCounter} robots.";
        }


        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> feedRobots = robots.Models()
                .Where(r=>r.BatteryLevel*2 < r.BatteryCapacity)
                .Where(r=>r.Model == model)
                .ToList();
            int robotsFed = 0;
            foreach (var robot in feedRobots)
            {
                robot.Eating(minutes);
                robotsFed++;
            }

            return $"Robots fed: {robotsFed}";

        }


        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach (var robot in robots.Models().OrderByDescending(r=>r.BatteryLevel).ThenBy(r=>r.BatteryCapacity))
            {
                result.AppendLine(robot.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
