using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.FindById(drivingLicenseNumber) != null)
            {
                return $"{drivingLicenseNumber} is already registered in our platform.";
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);
            return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            string[] allowedCarTypes = new string[] { "PassengerCar", "CargoVan" };
            if (!allowedCarTypes.Contains(vehicleType))
            {
                return $"{vehicleType} is not accessible in our platform.";
            }
            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return $"{licensePlateNumber} belongs to another vehicle.";
            }

            IVehicle vehicle = null;
            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else if (vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            vehicles.AddModel(vehicle);
            return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            IReadOnlyCollection<IRoute> routesCollection = routes.GetAll();
            if (routes.GetAll().Any(r=>r.StartPoint == startPoint) && routes.GetAll().Any(r=>r.EndPoint == endPoint)
                && routesCollection.Any(r=>r.Length == length))
            {
                return $"{startPoint}/{endPoint} - {length} km is already added in our platform.";
            }
            if (routes.GetAll().Any(r => r.StartPoint == startPoint) && routes.GetAll().Any(r => r.EndPoint == endPoint))
            {
                IRoute routeSearch = routes.GetAll().First(r => r.StartPoint == startPoint 
                                                                && routesCollection.Any(r => r.EndPoint == endPoint));
                if (routeSearch.Length < length)
                {
                    return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
                }
                else if (routeSearch.Length > length)
                {
                    routeSearch.LockRoute();
                }
            }

            IRoute route = new Route(startPoint, endPoint, length, routesCollection.Count + 1);
            routes.AddModel(route);
            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            if (user.IsBlocked == true)
            {
                return $"User {drivingLicenseNumber} is blocked in the platform! Trip is not allowed.";
            }

            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            if (vehicle.IsDamaged == true)
            {
                return $"Vehicle {licensePlateNumber} is damaged! Trip is not allowed.";
            }

            IRoute route = routes.FindById(routeId);
            if (route.IsLocked == true)
            {
                return $"Route {routeId} is locked! Trip is not allowed.";
            }
            vehicle.Drive(route.Length);
            if (isAccidentHappened == true)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> vehiclesToRepair = vehicles.GetAll()
                .Where(v=>v.IsDamaged == true)
                .OrderBy(v=>v.Brand)
                .ThenBy(v=>v.Model)
                .Take(count)
                .ToList();
            foreach (var vehicle in vehiclesToRepair)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return $"{vehiclesToRepair.Count} vehicles are successfully repaired!";
        }

        public string UsersReport()
        {
            List<IUser> usersList = users.GetAll()
                .OrderByDescending(u => u.Rating)
                .ThenBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();
            StringBuilder result = new StringBuilder();
            result.AppendLine($"*** E-Drive-Rent ***");
            foreach (var user in usersList)
            {
                result.AppendLine(user.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
