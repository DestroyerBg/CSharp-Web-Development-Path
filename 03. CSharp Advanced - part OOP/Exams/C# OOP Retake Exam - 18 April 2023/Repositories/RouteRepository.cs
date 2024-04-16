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
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            if (routes.Any(u => u.RouteId == int.Parse(identifier)))
            {
                routes.Remove(routes.Find(u => u.RouteId == int.Parse(identifier)));
                return true;
            }
            return false;
        }

        public IRoute FindById(string identifier)
        {
            if (routes.Any(u => u.RouteId == int.Parse(identifier)))
            {
                return routes.Find(u => u.RouteId == int.Parse(identifier));
            }
            return null;
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return routes.AsReadOnly();
        }
    }
}
