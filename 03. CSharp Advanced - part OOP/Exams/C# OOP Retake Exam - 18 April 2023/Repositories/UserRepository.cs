using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            if (users.Any(u=>u.DrivingLicenseNumber == identifier))
            {
                users.Remove(users.Find(u => u.DrivingLicenseNumber == identifier));
                return true;
            }
            return false;
        }

        public IUser FindById(string identifier)
        {
            if (users.Any(u => u.DrivingLicenseNumber == identifier))
            {
                return users.Find(u => u.DrivingLicenseNumber == identifier);
            }
            return null;
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return users.AsReadOnly();
        }
    }
}
