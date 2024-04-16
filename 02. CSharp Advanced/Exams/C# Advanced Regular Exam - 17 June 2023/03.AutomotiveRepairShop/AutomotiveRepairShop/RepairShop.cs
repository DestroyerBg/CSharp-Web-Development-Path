using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; private set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count<Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            if (Vehicles.Any(v=>v.VIN == vin))
            {
                var searchVehicle = Vehicles.Find(v => v.VIN == vin);
                Vehicles.Remove(searchVehicle);
                return true;
            }
            return false;
        }
        public int GetCount() => Vehicles.Count;

        public Vehicle GetLowestMileage()
        {
            return Vehicles.MinBy(m => m.Mileage);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
            {
                result.AppendLine($"{vehicle.ToString()}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
