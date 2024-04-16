using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            if (vehicles.Any(u => u.LicensePlateNumber == identifier))
            {
                vehicles.Remove(vehicles.Find(u => u.LicensePlateNumber == identifier));
                return true;
            }
            return false;
        }

        public IVehicle FindById(string identifier)
        {
            if (vehicles.Any(u => u.LicensePlateNumber == identifier))
            {
                return vehicles.Find(u => u.LicensePlateNumber == identifier);
            }
            return null;
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return vehicles.AsReadOnly();
        }
    }
}
