using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private List<int> interfaceStandards;

        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            interfaceStandards = new List<int>();
            BatteryLevel = BatteryCapacity;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                batteryCapacity = value;
                if (batteryCapacity < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }
            }
        }

        public int BatteryLevel { get; private set; }
        
        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards
        {
            get => interfaceStandards;
        }
        public void Eating(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                BatteryLevel += ConvertionCapacityIndex;
                if (BatteryLevel >= BatteryCapacity)
                {
                    BatteryLevel = BatteryCapacity;
                    break;
                }
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryLevel -= supplement.BatteryUsage;
            BatteryCapacity -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel-=consumedEnergy;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{GetType().Name} {Model}:");
            result.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            result.AppendLine($"--Current battery level: {BatteryLevel}");
            if (InterfaceStandards.Any())
            {
                string supplements = string.Join(" ", InterfaceStandards);
                result.AppendLine($"--Supplements installed: {supplements}");
            }
            else
            {
                result.AppendLine($"--Supplements installed: none");
            }
            return result.ToString().TrimEnd();
        }
    }
}
